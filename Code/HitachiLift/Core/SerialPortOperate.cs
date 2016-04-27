using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Common;

namespace HitachiLift
{
    /// <summary>
    /// 串口操作类
    /// </summary>
    public static class SerialPortOperate
    {
        private static bool _isWork = true;
        private static SerialPort _port = null;
        private const byte _bFrameStart = 0xAC;
        private const byte _bFrameEnd = 0xCA;
        private static Thread _thread = null;

        public static FrmLift Window = null;
        private static string _portName = "com1";

        public static bool Open(string portName, int baudRate = 9600)
        {
            try
            {
                _portName = portName;
                _port = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
                _port.Open();
                return true;
            }
            catch (Exception ex)
            {
                Log("串口打开失败：" + ex.Message);
                return false;
            }
        }

        public static void DoReceive()
        {
            _isWork = true;
            _thread = new Thread(Receive);
            _thread.Start();
        }

        private static void Receive()
        {
            while (_isWork)
            {
                try
                {
                    var frame = _port.ReadByte();
                    if (frame != _bFrameStart)
                        continue;

                    var data = ReadData(_port);
                    if (Xor(data))
                    {
                        //校验成功
                        ParsePackage(data);
                    }
                }
                catch (Exception ex)
                {
                    Log("处理异常:" + ex.Message);
                }
            }
        }

        private static byte[] ReadData(SerialPort port)
        {
            List<byte> data = new List<byte>();
            data.Add(_bFrameStart);

            byte b = 0;
            while ((b = (byte)port.ReadByte()) != _bFrameEnd)
            {
                data.Add(b);
            }
            data.Add(_bFrameEnd);
            return data.ToArray();
        }

        private static bool Xor(byte[] data)
        {
            var xor = 0x00;
            var xorIndex = data.Length - 2;
            var sendXor = data[xorIndex];
            for (var i = 0; i < xorIndex; i++)
            {
                xor ^= data[i];
            }
            var equal = (xor == sendXor);
            return equal;
        }

        public static void ClosePort()
        {
            _isWork = false;
            if (_port != null && _port.IsOpen)
            {
                _port.Close();
            }
            Thread.Sleep(100);
            if (_thread != null &&
                _thread.ThreadState == System.Threading.ThreadState.Running)
            {
                _thread.Abort();
                _thread = null;
            }
        }

        public static void SendData(byte[] data)
        {
            if (_port != null && _port.IsOpen)
            {
                _port.Write(data, 0, data.Length);
            }
            else
            {
                Log("串口未打开");
            }
        }

        public static void ParsePackage(byte[] data)
        {
            var packageType = data[1];
            switch (packageType)
            {
                case 0x5A: //选择器->读卡器  查询包
                    if (data[2] == 0xFF && data[3] == 0xFF && data[4] == 0xFF && data[5] == 0xFF)
                    {
                        if (CommData.CardCode == 0)
                        {
                            //无卡
                            var back = Package.NoCard_Package();
                            Log("无卡包--->");
                            Log("长度：{0}", back.Length);
                            Log("数据：{0}", back.ToHex());
                            SendData(back);
                        }
                        else
                        {
                            //有卡(带卡权限)
                            Log("有卡包--->");
                            var handBuffer = new byte[8];
                            var floors = (byte)new Random().Next(1, 63);
                            var back = Package.CardDataSendToLiftPackage(CommData.CardCode, handBuffer, floors);
                            Log("楼层=" + floors);
                            SendData(back);
                        }
                    }
                    else
                    {
                        //确认包
                        //返回无卡数据包
                        var back = Package.NoCard_Package();
                        SendData(back);
                        //收到选层器确认包后，清空卡号结束本次回话
                        CommData.CardCode = 0;
                    }
                    break;
                case 0x5B: //选择器->读卡器  变更波特率
                    ChangeBaud(data);
                    break;
                case 0x5C: //设备有卡数据包
                    GetCardFloor(data);
                    break;
                case 0x5E: //选择器->读卡器  查询闸机状态
                    if (data[2] == 0xFF && data[3] == 0xFF && data[4] == 0xFF && data[5] == 0xFF)
                    {
                        //闸机状态
                        const byte Gate_Exit = 0x00;
                        const byte Gate_OK = 0xFF;
                        const byte Gate_Error = 0x01;
                        var back = Package.GateState_Package(Gate_Error);
                        Log("返回闸机状态--->");
                        Log("长度：{0}", back.Length);
                        Log("数据：{0}", back.ToHex());
                        SendData(back);
                    }
                    else
                    {
                        //闸机卡片权限
                        var cardBytes = new byte[4];
                        Array.Copy(data, 2, cardBytes, 0, 4);
                        //发送时，高字节数据在前
                        Array.Reverse(cardBytes);
                        var _currentCardID = BitConverter.ToInt32(cardBytes, 0);
                        Log("确认卡片权限，卡号：" + _currentCardID);
                        if (_currentCardID > 0)
                        {
                            const byte open = 0x00;
                            const byte no_open = 0x01;
                            const byte open_error = 0xFF;
                            const byte data_error = 0x02;
                            var back = Package.ConfrmGateCard_Package(_currentCardID, open);
                            Log("返回闸机卡片权限--->");
                            Log("卡ID：{0}", _currentCardID);
                            Log("长度：{0}", back.Length);
                            Log("数据：{0}", back.ToHex());
                            SendData(back);
                            _currentCardID = 0x00;
                        }
                    }
                    break;
            }
        }

        private static void GetCardFloor(byte[] data)
        {
            var cardBytes = new byte[4];
            Array.Copy(data, 2, cardBytes, 0, 4);
            //发送时，高字节数据在前
            Array.Reverse(cardBytes);
            var currentCardID = BitConverter.ToInt32(cardBytes, 0);
            Log("确认卡片权限，卡号：" + currentCardID);

            var handFloor = new byte[8];
            Array.Copy(data, 6, handFloor, 0, 8);
            bool hand = handFloor.Any(s => s != 0xFF);
            if (hand)
            {
                Log("手动权限层有数据");
            }
            else
            {
                var autoByte = data[41];
                if (autoByte > 0)
                {
                    var userType = (autoByte >> 6) & 0x03;
                    if (userType == 0)
                        Log("普通");
                    else if (userType == 1)
                        Log("vip");
                    else if (userType == 2)
                        Log("残疾人");
                    else if (userType == 3)
                        Log("高级vip");

                    var fs = autoByte & 0x3F;
                    Log("自动楼层, floor->" + fs);
                }
            }
        }

        private static void ChangeBaud(byte[] data)
        {
            var baudBytes = new byte[4];
            Array.Copy(data, 2, baudBytes, 0, 4);
            //发送时，高字节数据在前
            Array.Reverse(baudBytes);
            var baudRate = BitConverter.ToInt32(baudBytes, 0);
            //串口
            ClosePort();
            Log("设置波特率：{0}", baudRate);
            if (Open(_portName, baudRate))
            {
                Log("波特率设置成功");
                DoReceive();
            }

            var back = Package.ConfrmBaudRate_Package(baudRate);
            Log("确认波特率--->");
            Log("长度：{0}", back.Length);
            Log("数据：{0}", back.ToHex());
            SendData(back);
        }

        private static void Log(string log, params object[] p)
        {
            Window.Log(log, p);
        }
    }
}
