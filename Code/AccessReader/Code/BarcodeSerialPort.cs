using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using Common;

namespace AccessReader.Code
{
    /// <summary>
    /// 
    /// </summary>
    public class BarcodeSerialPort
    {
        private bool _isStop = false;
        private SerialPort _serial = null;
        private Action<string> _onReadeBarcode = null;
        public BarcodeSerialPort(Action<string> barcodeCallback)
        {
            _onReadeBarcode = barcodeCallback;
        }

        public bool Open(string portname)
        {
            _serial = new SerialPort(portname, 19200, Parity.None, 8, StopBits.One);
            try
            {
                _serial.Open();
                ThreadPool.QueueUserWorkItem(ReadComm);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Write(byte[] data)
        {
            if (_serial != null && _serial.IsOpen)
            {
                _serial.Write(data, 0, data.Length);
            }
        }

        public void Close()
        {
            _isStop = true;
            if (_serial != null && _serial.IsOpen)
            {
                _serial.Close();
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
                    {
                        System.Diagnostics.Debug.WriteLine((char)stx);
                        continue;
                    }
                    byte b = 0;
                    while ((b = (byte)_serial.ReadByte()) > 0)
                    {
                        if (b == 0x03)
                            break;
                        buffer[pos] = b;
                        pos++;
                    }
                    PrintCode(buffer);
                }
                catch
                {
                    Console.WriteLine("串口关闭");
                }
            }
        }

        private void PrintCode(byte[] buffer)
        {
            var code = buffer.ToUTF8String();
            if (_onReadeBarcode != null)
            {
                _onReadeBarcode(code);
            }
        }
    }
}
