using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace AccessReader.Code
{
    public class NFCSerialPort
    {
        private bool _isStop = false;
        private SerialPort _serial = null;
        public int CMD
        {
            get;
            set;
        }

        public void Log(string str)
        {
        }

        public bool Open(string portname)
        {
            _serial = new SerialPort(portname, 115200, Parity.None, 8, StopBits.One);
            try
            {
                _serial.Open();
                ThreadPool.QueueUserWorkItem(ReadCommIC);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Write(byte[] buffer)
        {
            if (_serial != null && _serial.IsOpen)
            {
                _serial.Write(buffer, 0, buffer.Length);
            }
        }

        private void ReadCommIC(object obj)
        {
            while (!_isStop)
            {
                try
                {
                    byte[] buffer = new byte[128];
                    var stx = (byte)_serial.ReadByte();
                    if (stx == 0x50)
                    {
                        var b1 = (byte)_serial.ReadByte();
                        var b2 = (byte)_serial.ReadByte();
                        if (b1 == 1)
                            Log("进入");
                        else
                            Log("离开");
                        if (b2 == 0x01)
                            Log("SO14443-4 A");
                        else if (b2 == 0x03)
                            Log("Mifare Classic 1K");
                        else
                            Log("其它类型:" + buffer[2]);

                        continue;
                    }
                    else
                    {
                        if (stx == 0x80)
                            Log("出现，未授权");
                        else if (stx == 0xC0)
                            Log("出现，已授权");
                        var len = (byte)_serial.ReadByte();
                        //读取剩余字节
                        var data = readAll(8 + len);
                        var backData = new byte[len];
                        Array.Copy(data, 8, backData, 0, len);
                        Log("读卡器返回, len=" + len + " " + GetHex(backData));
                        if (CMD == 1)
                        {
                            //get mefiare type
                            if (backData[2] == 0x03)
                            {
                                var arr = new byte[4];
                                Array.Copy(backData, 3, arr, 0, 4);
                                var uid = BitConverter.ToUInt32(arr, 0);
                                Log("卡类=Mifare Classic 1K  卡数据=" + string.Join(" ", arr.Select(s => s.ToString("X2"))) + " 序列号 UID=" + uid);
                            }
                            else if (backData[2] == 0x04)
                                Log("Mifare Classic 4K");
                            else if (backData[2] == 0x05)
                                Log("Mifare Ultralight");
                        }
                        else if (CMD == 2)
                        {
                            //load media key
                            if (len == 4)
                            {
                                if (backData[2] == 0x90 && data[3] == 0x00)
                                {
                                    Log("设置密码成功");
                                }
                            }
                        }
                        else if (CMD == 3)
                        {
                            if (backData[3] == 0x90 && backData[4] == 0x00)
                            {
                                Log("块=" + backData[2] + "授权成功");
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("串口关闭");
                }
            }
        }

        private byte[] readAll(int len)
        {
            var data = new byte[len];
            var pos = 0;
            var readlen = len - pos;
            while ((pos = _serial.Read(data, pos, readlen)) > 0)
            {
                if (pos == len)
                    break;
                pos += pos;
                readlen = len - pos;
            }
            return data;
        }

        private string GetHex(byte[] buffer)
        {
            var str = string.Join(" ", buffer.Where(s => s >= 0).Select(s => s.ToString("X2") + "h").ToArray());
            return str;
        }
    }
}
