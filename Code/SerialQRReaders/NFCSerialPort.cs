using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using Common;
namespace SerialQRReaders
{
    public class NFCSerialPort
    {
        private bool _isStop = false;
        private SerialPort _serial = null;
        private Action<string> _dataBack = null;

        private FuncTimeout _getSerialNumberTick = null;
        public int CMD
        {
            get;
            set;
        }

        public NFCSerialPort(Action<string> dataBack)
        {
            _dataBack = dataBack;
        }

        public void Log(string str)
        {
            Console.WriteLine(str);
            _dataBack(str);
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

                        var slot = b1 & 0xF0;
                        var mediaStatus = b1 & 0x0F;
                        if (mediaStatus == 1)
                        {
                            Log("进入");
                            _getSerialNumberTick = new FuncTimeout();
                            _getSerialNumberTick.StartLoop(500, () =>
                            {
                                var sendData = MifarePackage.Data("00 00");
                                CMD = 1;
                                Write(sendData);
                            });
                        }
                        else
                        {
                            Log("离开");
                            StopAuto();
                        }


                        if (b2 == 0x01)
                            Log("SO14443-4 A");
                        else if (b2 == 0x03)
                            Log("Mifare Classic 1K");
                        else
                            Log("其它类型:" + b2);

                        continue;
                    }
                    else
                    {
                        //if (stx == 0x80)
                        //    Log("出现，未授权");
                        //else if (stx == 0xC0)
                        //    Log("出现，已授权");
                        var len = (byte)_serial.ReadByte();
                        //读取剩余字节
                        var data = readAll(8 + len);
                        var backData = new byte[len];
                        Array.Copy(data, 8, backData, 0, len);
                        Log("读卡器返回, len=" + len + " " + GetHex(backData));
                        if (CMD == 0)
                        {
                            NFCResponse(backData);
                        }
                        else
                        {
                            MifareResponse(backData, len);
                        }
                    }
                }
                catch
                {
                    //Console.WriteLine("串口关闭");
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


        private void NFCResponse(byte[] backData)
        {
            var echocode = backData[0];
            if (echocode == 0)
            {
                Log("firmware version=" + backData[1].ToHex() + backData[2].ToHex());
            }
            else if (echocode == 1)
            {
                Log("bootloader version=" + backData[1].ToHex() + " " + backData[2].ToHex());
            }
            else if (echocode == 3)
            {
                var serialNumber = new byte[20];
                Array.Copy(backData, 1, serialNumber, 0, 20);
                var hex = serialNumber.ToHex();
                Log("NFC Serial Number=" + hex);
            }
            else if (echocode == 0x0B)
            {
                Log("kernel version=" + backData[1].ToHex() + " " + backData[2].ToHex());
            }
            else if (echocode == 0x0D)
            {
                if (backData[1] == 03)
                    Log("mediatype=MIFARE Classic 1K");
                else if (backData[1] == 04)
                    Log("mediatype=MIFARE Classic 4K");
                else
                    Log("mediatype=" + backData[1]);

                var seialnumberlen = backData[2];
                Log("serialnumberlen=" + seialnumberlen);

                var arr = new byte[4];
                Array.Copy(backData, 3, arr, 0, 4);
                var uid = BitConverter.ToUInt32(arr, 0);
                Log("卡类=Mifare Classic 1K  卡数据=" + string.Join(" ", arr.Select(s => s.ToString("X2"))) + " 序列号 UID=" + uid);
            }
        }
        private void MifareResponse(byte[] backData, int len)
        {
            if (CMD == 1)
            {
                //get mefiare type
                if (backData[2] == 0x03)
                {
                    StopAuto();
                    var arr = new byte[4];
                    Array.Copy(backData, 3, arr, 0, 4);
                    var uid = BitConverter.ToUInt32(arr, 0);
                    var uidhex = string.Join("", arr.Select(s => s.ToHex()));
                    Log("卡类=Mifare Classic 1K  卡数据=" + uidhex + " 序列号 UID=" + uid);
                    _dataBack(uidhex);
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
                    if (backData[2] == 0x90 && backData[3] == 0x00)
                    {
                        Log("设置密码成功");
                    }
                }
            }
            else if (CMD == 3)
            {
                //
                if (backData[3] == 0x90 && backData[4] == 0x00)
                {
                    Log("块=" + backData[2] + "授权成功");
                }
            }
            else if (CMD == 4)
            {
                if (backData[3] == 0x90 && backData[4] == 0x00)
                {
                    Log("块=" + backData[2] + " 写成功");
                }
                else
                {
                    Log(string.Format("Response Code={0}, Block={1}, Code={2} {3}",
                        backData[1], backData[2], backData[3], backData[4]));
                }
            }
            else if (CMD == 5)
            {
                if (backData[3] == 0x90 && backData[4] == 0x00)
                {
                    Log("块=" + backData[2] + " 读成功");
                }
                else
                {
                    Log(string.Format("Response Code={0}, Block={1}, Code={2} {3}",
                        backData[1], backData[2], backData[3], backData[4]));
                }
            }
        }

        private void StopAuto()
        {
            if (_getSerialNumberTick != null)
            {
                _getSerialNumberTick.Stop();
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
