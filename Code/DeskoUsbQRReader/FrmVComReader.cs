using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DeskoUsbQRReader
{
    /// <summary>
    /// Desko Usb虚拟串口二维码阅读器
    /// 1.安装虚拟串口
    /// </summary>
    public partial class FrmVComReader : FrmBase
    {
        public FrmVComReader()
        {
            InitializeComponent();
        }

        private void log(string str)
        {
            Debug.WriteLine(str);
            Action act = () =>
            {
                rtbCode.AppendText(DateTime.Now + " " + str);
                rtbCode.AppendText("\n");
            };
            if (InvokeRequired)
                Invoke(act);
            else
                act();
        }

        SerialPort _serial = null;
        bool _isStop = false;
        static object expectResponseMutex = new object();
        private void FrmVComReader_Load(object sender, EventArgs e)
        {

        }

        void _serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //lock (expectResponseMutex)
            //{
                string str = _serial.ReadExisting();
                //Monitor.PulseAll(expectResponseMutex);
                var num = str.IndexOf('\u0002');
                var num2 = str.IndexOf('\u0003');
                var num3 = str.IndexOf('\r');
                log(num + " " + num2 + " " + num3);

                if (num != -1)
                    str = str.Substring(num + 2, (num3 - num - 2));
                log(str);
            //}
        }

        private void Read()
        {
            //while (!_isStop)
            //{
            //    try
            //    {
            //        var pos = 0;
            //        byte[] buffer = new byte[128];
            //        var stx = (byte)_serial.ReadByte();
            //        if (stx != 0x02)
            //            continue;

            //        buffer[pos] = stx;
            //        pos++;
            //        byte b = 0;
            //        while ((b = (byte)_serial.ReadByte()) > 0)
            //        {
            //            buffer[pos] = b;
            //            pos++;
            //            if (b == 0x03)
            //                break;
            //        }
            //        PrintCode(buffer);
            //    }
            //    catch
            //    {
            //        Console.WriteLine("串口关闭");
            //    }
            //}
        }

        private void PrintCode(byte[] buffer)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < buffer.Length; i++)
            {
                sb.Append(buffer[i] + " ");
            }
            Invoke(new Action(() =>
            {
                var codeStr = Encoding.UTF8.GetString(buffer, 2, buffer.Length - 3);
                log(DateTime.Now + " " + sb.ToString());
                log(DateTime.Now + " " + codeStr);
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _serial = new SerialPort("COM34", 19200, Parity.None, 8, StopBits.One);
            _serial.Open();
            _serial.RtsEnable = true;
            _serial.ReceivedBytesThreshold = 1;
            _serial.DataReceived += _serial_DataReceived;
            log("port open");
            //new Thread(Read).Start();

            //_serial.Write("DESKO.CONTROL.ENABLE=1");
            lock (expectResponseMutex)
            {
                if (Monitor.Wait(expectResponseMutex, 1000))
                {
                    log("qrreader is ok");
                }
            }
        }
    }
}
