using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Honeywell3580
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmMain : FrmBase
    {
        bool _stop = false;
        SerialPort _serialPort = null;
        List<char> _barcodeList = new List<char>();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
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
            //Honeywell 3580扫描抢默认波特率为 9600
            //YJ-HF500      扫描抢默认波特率为 115200
            _serialPort = new SerialPort(cmbPorts.Text, 115200, Parity.None, 8, StopBits.One);
            try
            {
                _serialPort.Open();
                ThreadPool.QueueUserWorkItem(ReadComm);
                btnOpen.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadComm(object obj)
        {
            while (!_stop)
            {
                byte b = 0;
                try
                {
                    while ((b = (byte)_serialPort.ReadByte()) > 0)
                    {
                        if (b == 13)
                        {
                            var barcode = new string(_barcodeList.ToArray());
                            PrintCode(barcode);
                            _barcodeList.Clear();
                        }
                        else
                        {
                            _barcodeList.Add((char)b);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("关闭串口");
                }
            }
        }

        private void PrintCode(string barcode)
        {
            Action act = () =>
            {
                rtbCode.AppendText(DateTime.Now + " " + barcode + Environment.NewLine);
            };
            Invoke(act);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _stop = true;
            if (_serialPort != null && _serialPort.IsOpen)
                _serialPort.Close();
        }
    }
}
