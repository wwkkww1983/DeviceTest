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
                        MifareInOrLeave(b1, b2);
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
                        Log("读卡器返回, len=" + len + " " + backData.ToHex());
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

        private void MifareInOrLeave(byte b1, byte b2)
        {
            var slot = b1 & 0xF0;
            var mediaStatus = b1 & 0x0F;
            if (mediaStatus == 1)
            {
                Log("进入, 读取序列号...");
                _getSerialNumberTick = new FuncTimeout();
                _getSerialNumberTick.StartLoop(500, () =>
                {
                    var sendData = MifarePackage.GetSendData("00 00");
                    CMD = 1;
                    Write(sendData);
                });
            }
            else
            {
                Log("离开");
                StopAuto();
            }

            ShowICType(b2);
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
                Log("NFC Media Serial Number=" + hex);
            }
            else if (echocode == 0x0B)
            {
                Log("kernel version=" + backData[1].ToHex() + " " + backData[2].ToHex());
            }
            else if (echocode == 0x0D)
            {
                ShowICType(backData[1]);

                var seialnumberlen = backData[2];
                Log("serialnumberlen=" + seialnumberlen);

                var arr = new byte[4];
                Array.Copy(backData, 3, arr, 0, 4);
                var uid = BitConverter.ToUInt32(arr, 0);
                Log("卡类=Mifare Classic 1K  卡数据=" + arr.ToHex() + " 序列号 UID=" + uid);
            }
        }
        private void MifareResponse(byte[] backData, int len)
        {

            if (CMD == 1)
            {
                //get mefiare type
                ShowICType(backData[2]);
                if (backData[2] == 0x03)
                {
                    ShowResponseCode(backData, "读卡成功");
                    StopAuto();
                    var arr = new byte[4];
                    Array.Copy(backData, 3, arr, 0, 4);
                    var uid = BitConverter.ToUInt32(arr, 0);
                    var uidhex = string.Join("", arr.Select(s => s.ToHex()));
                    Log("卡类=Mifare Classic 1K  卡数据=" + uidhex + " 序列号 UID=" + uid);
                    _dataBack(uidhex);
                }
            }
            else if (CMD == 2)
            {
                //load media key
                if (len == 4)
                {
                    ShowResponseCode(backData, "设置密码成功");
                }
            }
            else if (CMD == 3)
            {
                //Authociate block
                ShowResponseCode(backData, "块=" + backData[2] + "授权成功");
            }
            else if (CMD == 4)
            {
                //write block
                ShowResponseCode(backData, "块=" + backData[2] + "写成功");
            }
            else if (CMD == 5)
            {
                //read block
                ShowResponseCode(backData, "块=" + backData[2] + "读成功");
            }
        }

        private void ShowICType(byte b)
        {
            if (b == 0x01)
                Log("SO14443-4 A");
            else if (b == 0x02)
                Log("SO14443-4 B");
            else if (b == 0x03)
                Log("Mifare Classic 1K");
            else if (b == 0x4)
                Log("Mifare Classic 4K");
            else if (b == 0x5)
                Log("Mifare Ultralight");
            else if (b == 0x06)
                Log("Mifare Plus");
            else if (b == 0x09)
                Log("NFC Type 1 Tag");
            else
                Log("其它类型:" + b);
        }

        private string GetMifareFailureCode(byte b)
        {
            if (b == 0x80)
                return "Missing parameters";
            else if (b == 0x81)
                return "Invalid command header; command header is not [0x00]";
            else if (b == 0x82)
                return "Invalid command";
            else if (b == 0x83)
                return "Authentication failed";
            else if (b == 0x84)
                return "Read block failed";
            else if (b == 0x85)
                return "Write block failed";
            else if (b == 0x86)
                return "Restore value block failed (this is an internal command failure)";
            else if (b == 0x87)
                return "Create value block failed";
            else if (b == 0x88)
                return "Increment value block failed";
            else if (b == 0x89)
                return "Decrement value block failed";
            else if (b == 0x8A)
                return "Transfer value block failed (this is an internal command failure)";
            else if (b == 0x8B)
                return "MIFARE Ultralight-C Authentication Part 1 failed";
            else if (b == 0x8C)
                return "MIFARE Ultralight-C Authentication Part 2 failed";
            else
                return "MIFARE direct transceive failed";
        }

        private void ShowResponseCode(byte[] backData, string okmsg)
        {
            var len = backData.Length;
            var lastByte1 = backData.Last();
            var lastByte2 = backData[len - 2];
            if (lastByte1 == 0x00 && lastByte2 == 0x90)
            {
                Log(okmsg);
            }
            else
            {
                Log(string.Format("Code [{1}][{2}] {3}", lastByte2, lastByte1, GetMifareFailureCode(lastByte1)));
            }
        }

        private void StopAuto()
        {
            if (_getSerialNumberTick != null)
            {
                _getSerialNumberTick.Stop();
                _getSerialNumberTick = null;
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
