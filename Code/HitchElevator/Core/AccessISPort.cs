using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
namespace HitchElevator.Core
{
    /// <summary>
    /// AccessIS 三合一设备二维码
    /// </summary>
    public class AccessISPort
    {
        private bool _isStop = false;
        private SerialPort _serial = null;
        private Action<string> _onReadebarcode = null;
        public static MainWindow Window = null;
        public void Open(string portname)
        {
            //二维码波特率为19200
            _serial = new SerialPort(portname, 19200, Parity.None, 8, StopBits.One);
            try
            {
                _serial.Open();
                Window.Log("二维码串口打开=" + portname);
                ThreadPool.QueueUserWorkItem(ReadComm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetCallBack(Action<string> callback)
        {
            _onReadebarcode = callback;
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
                }
            }
        }

        private void PrintCode(byte[] buffer)
        {
            var code = System.Text.Encoding.UTF8.GetString(buffer).Replace("楼", "").Trim();
            var pos = code.IndexOf((char)0);
            code = code.Remove(pos);
            if (_onReadebarcode != null)
            {
                _onReadebarcode(code);
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
    }
}
