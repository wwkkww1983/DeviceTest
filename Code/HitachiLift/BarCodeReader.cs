using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;
using Common;

namespace HitachiLift
{
    public class BarCodeReader
    {
        string _portName = "";
        SerialPort _serialPort = null;
        bool _stop = false;
        List<char> _barcodeList = new List<char>();
        public bool Open(string portName, int baudRate = 9600)
        {
            try
            {
                _portName = portName;
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
                            CommData.CardCode = barcode.ToInt32();
                            Log(barcode);
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

        public void Close()
        {
            _stop = true;
        }


        private static void Log(string log, params object[] p)
        {
            Debug.WriteLine(string.Format(log, p));
        }
    }
}
