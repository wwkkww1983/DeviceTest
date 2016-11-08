using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;
using Common;

namespace Honeywell3580
{
    /// <summary>
    /// 霍尼韦尔和优解二维码阅读器
    /// </summary>
    /// <remarks>
    /// Honeywell 3580扫描抢默认波特率为 9600
    /// YJ-HF500      扫描抢默认波特率为 115200
    /// </remarks>
    public class BarCodeReader : IDisposable
    {
        private bool _stop = false;
        private SerialPort _serialPort = null;
        private List<char> _barcodeList = new List<char>();
        public bool Open(string portName, ReaderType reader)
        {
            try
            {
                var baudRate = 9600;
                if (reader == ReaderType.Honeywell)
                    baudRate = 9600;
                else if (reader == ReaderType.YJ)
                    baudRate = 115200;

                _serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
                _serialPort.Open();

                ThreadPool.QueueUserWorkItem(ReadComm);
                return true;
            }
            catch (Exception ex)
            {
                Log("串口打开失败：" + ex.Message);
                return false;
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
                            Log(barcode);
                            _barcodeList.Clear();
                        }
                        else
                        {
                            _barcodeList.Add((char)b);
                            Log(b + " " + ((char)b).ToString());
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("关闭串口");
                }
            }
        }


        private void Log(string log, params object[] p)
        {
            Context.Log.Write(string.Format(log, p));
        }

        public void Dispose()
        {
            _stop = true;
            if (_serialPort != null)
                _serialPort.Close();
        }
    }

    public enum ReaderType
    {
        /// <summary>
        /// 
        /// </summary>
        Honeywell,
        /// <summary>
        /// 优解
        /// </summary>
        YJ
    }
}
