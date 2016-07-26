using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace QRReader
{
    /// <summary>
    /// 德国Desko二维码阅读器
    /// 两种通讯方式：
    /// 一、串口接口
    /// 二、USB接口，但需要安装虚拟串口驱动
    /// </summary>
    public partial class FrmCodeReader : FrmBase
    {
        private bool _isStop = false;
        private SerialPort _serial = null;
        private CommunicationType _cType = CommunicationType.Com;

        public FrmCodeReader()
        {
            InitializeComponent();
        }

        private void FrmQRCodeReader_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cmbPorts.DataSource = ports;
            if (cmbPorts.Items.Count == 0)
            {
                btnOpen.Enabled = false;
                btnVirtualComPort.Enabled = false;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            _cType = CommunicationType.Com;
            OpenComPort();
        }

        private void btnVirtualComPort_Click(object sender, EventArgs e)
        {
            _cType = CommunicationType.VirtualCom;
            OpenComPort();
        }

        private void OpenComPort()
        {
            _serial = new SerialPort(cmbPorts.Text, 9600, Parity.None, 8, StopBits.One);
            try
            {
                _serial.Open();
                ThreadPool.QueueUserWorkItem(ReadComm);
                if (_cType == CommunicationType.Com)
                    btnOpen.Enabled = false;
                else
                    btnVirtualComPort.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReadComm(object obj)
        {
            while (!_isStop)
            {
                try
                {
                    var pos = 0;
                    byte[] buffer = new byte[128];
                    var stx = (byte)_serial.ReadByte();
                    if (stx != 0x02)
                        continue;

                    buffer[pos] = stx;
                    pos++;
                    byte b = 0;
                    while ((b = (byte)_serial.ReadByte()) > 0)
                    {
                        buffer[pos] = b;
                        pos++;
                        if (b == 0x03)
                            break;
                    }
                    PrintCode(buffer, pos);
                }
                catch
                {
                    Console.WriteLine("串口关闭");
                }
            }
        }

        private void PrintCode(byte[] buffer, int pos)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < pos; i++)
            {
                sb.Append(buffer[i] + " ");
            }
            Invoke(new Action(() =>
            {
                rtbCode.AppendText(sb.ToString());
                rtbCode.AppendText("\n");

                var codeStr = "";
                if (_cType == CommunicationType.Com)
                {
                    codeStr = Encoding.UTF8.GetString(buffer, 4, pos - 5);
                }
                else
                {
                    codeStr = Encoding.UTF8.GetString(buffer, 2, pos - 4);
                }
                rtbCode.AppendText(DateTime.Now + " " + codeStr);
                rtbCode.AppendText("\n");
            }));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _isStop = true;
            if (_serial != null)
            {
                if (_serial.IsOpen)
                    _serial.Close();
            }
            base.OnFormClosing(e);
        }
    }

    /// <summary>
    /// 通讯方式
    /// </summary>
    public enum CommunicationType
    {
        /// <summary>
        /// 串口
        /// </summary>
        Com,
        /// <summary>
        /// 虚拟串口
        /// </summary>
        VirtualCom
    }
}
