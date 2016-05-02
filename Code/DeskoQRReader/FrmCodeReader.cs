﻿using Common;
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

namespace QRReader
{
    /// <summary>
    /// 德国Desko二维码阅读器
    /// </summary>
    public partial class FrmCodeReader : FrmBase
    {
        private bool _isStop = false;
        private SerialPort _serial = null;
        private string _sourceByte = "02 5D 51 31 68 74 74 70 3A 2F 2F 77 77 77 2E 63 68 69 6E 61 62 65 73 6F 2E 63 6F 6D 2F 03";
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
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            _serial = new SerialPort(cmbPorts.Text, 9600, Parity.None, 8, StopBits.One);
            try
            {
                _serial.Open();
                ThreadPool.QueueUserWorkItem(ReadComm);
                btnOpen.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            var buffer = _sourceByte.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray();
            PrintCode(buffer, buffer.Length);
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
                var codeStr = Encoding.UTF8.GetString(buffer, 4, pos - 5);
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
}
