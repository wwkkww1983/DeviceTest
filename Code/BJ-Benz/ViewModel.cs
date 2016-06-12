using Common.NotifyBase;
using HIDSdk;
using SerialQRReaders;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BJ_Benz
{
    class ViewModel : PropertyNotifyObject
    {
        private const string vid = "0c2e";
        private const string intdeviceId = "3130ad03";
        private HidDevice _deviceIn = null;
        private delegate void ReadHandlerDelegate(HidReport report);


        private AccessQRReader _accessQRReader = null;
        private NFCSerialPort _nfcReader = null;
        public ViewModel()
        {
            DeskoHIDReaderStatus = "未连接";

            Ports1 = SerialPort.GetPortNames().OrderBy(s => s).ToArray();
            Ports2 = SerialPort.GetPortNames().OrderBy(s => s).ToArray();

            IsMifareSerialButtonEnable = true;
            IsQRSerialButtonEnable = true;
        }

        public string DeskoHIDReaderStatus
        {
            get { return this.GetValue(s => s.DeskoHIDReaderStatus); }
            set { this.SetValue(s => s.DeskoHIDReaderStatus, value); }
        }

        public string QRCode
        {
            get { return this.GetValue(s => s.QRCode); }
            set { this.SetValue(s => s.QRCode, value); }
        }


        public string ICSerialNumber
        {
            get { return this.GetValue(s => s.ICSerialNumber); }
            set { this.SetValue(s => s.ICSerialNumber, value); }
        }


        public bool IsQRSerialButtonEnable
        {
            get { return this.GetValue(s => s.IsQRSerialButtonEnable); }
            set { this.SetValue(s => s.IsQRSerialButtonEnable, value); }
        }



        public bool IsMifareSerialButtonEnable
        {
            get { return this.GetValue(s => s.IsMifareSerialButtonEnable); }
            set { this.SetValue(s => s.IsMifareSerialButtonEnable, value); }
        }


        private SimpleCommand _openGateCommand;
        public SimpleCommand OpenGateCommand
        {
            get
            {
                if (_openGateCommand == null)
                {
                    _openGateCommand = new SimpleCommand((p) =>
                    {
                        if (p == "1")
                        {
                            IPCAPI.F75111_SetDigitalOutput(0x04);
                        }
                        else
                        {
                            IPCAPI.F75111_SetDigitalOutput(0x08);
                        }
                        Thread.Sleep(100);
                        //复位
                        IPCAPI.F75111_SetDigitalOutput(0);

                    });
                }
                return _openGateCommand;
            }
        }

        private string _qrPortname = "";
        private SimpleCommand _accessQRCommand;
        public SimpleCommand AccessQRCommand
        {
            get
            {
                if (_accessQRCommand == null)
                {
                    _accessQRCommand = new SimpleCommand((p) =>
                    {
                        if (p == _mifarePortname)
                        {
                            MessageBox.Show("不能同时打开相同串口!");
                            return;
                        }
                        if (_accessQRReader.Open(p))
                        {
                            _qrPortname = p;
                            IsQRSerialButtonEnable = false;
                        }
                    });
                }
                return _accessQRCommand;
            }
        }

        private string _mifarePortname = "";
        private SimpleCommand _accessMifareCommand;
        public SimpleCommand AccessMifareCommand
        {
            get
            {
                if (_accessMifareCommand == null)
                {
                    _accessMifareCommand = new SimpleCommand((p) =>
                    {
                        if (p == _qrPortname)
                        {
                            MessageBox.Show("不能同时打开相同串口!");
                            return;
                        }
                        if (_accessQRReader.Open(p))
                        {
                            _mifarePortname = p;
                            IsMifareSerialButtonEnable = false;
                        }
                    });
                }
                return _accessMifareCommand;
            }
        }


        public string[] Ports1 { get; set; }

        public string[] Ports2 { get; set; }

        public void Init()
        {
            var flag1 = IPCAPI.F75111_Init();
            if (flag1 == 0)
            {
                //MessageBox.Show("初始化主板失败!");
            }

            var list = HidDevices.Enumerate().Where(s => s.DevicePath.Contains(vid)).ToList();
            _deviceIn = list.FirstOrDefault(s => s.DevicePath.Contains(intdeviceId.ToLower()));
            if (_deviceIn != null)
            {
                _deviceIn.OpenDevice();
                _deviceIn.MonitorDeviceEvents = true;
                _deviceIn.Inserted += () => { DeskoHIDReaderStatus = "已连接"; };
                _deviceIn.Removed += () => { DeskoHIDReaderStatus = "未连接"; };
                _deviceIn.ReadReport(ReadInProcess);
            }

            _accessQRReader = new AccessQRReader((data) =>
            {
                QRCode = data;
            });

            _nfcReader = new NFCSerialPort((data) =>
            {
                ICSerialNumber = data;
            });
        }

        private void ReadInProcess(HidReport report)
        {
            Application.Current.Dispatcher.BeginInvoke(new ReadHandlerDelegate(ReadInHandler), new object[] { report });
        }

        private void ReadInHandler(HidReport report)
        {
            Parsecode(report, true);
            _deviceIn.ReadReport(ReadInProcess);
        }

        private const byte DataPos = 8;
        private const byte ETX = 0x03;
        private const string heartbitpackage = "09 5D 5A 36 43 42 52 45 4E 41 30 06 2E";
        private List<byte[]> packages = new List<byte[]>();
        private void Parsecode(HidReport report, bool flag)
        {
            var data = String.Join(" ", report.Data.Select(d => d.ToString("X2")));
            if (data.StartsWith(heartbitpackage))
            {
                //"heartBit";
            }
            else
            {
                var buffer = report.Data;
                if (buffer.All(s => s == 0))
                {
                    //"Disconnected";
                    return;
                }
                else
                {
                    if (buffer.Last() == 0x01)
                    {
                        //多包二维码(第一包)
                        packages.Add(report.Data);
                    }
                    else
                    {
                        if (packages.Count == 0)
                        {
                            //单包二维码
                            var end = Array.IndexOf<byte>(buffer, ETX);
                            if (end > -1)
                            {
                                var dataLen = end - DataPos;
                                byte[] total = new byte[128];
                                Array.Copy(buffer, DataPos, total, 0, dataLen);
                                QRCode = ToAscii(total);
                            }
                        }
                        else
                        {
                            var package1 = packages.First().ToArray();
                            var package2 = buffer;

                            byte[] total = new byte[128];
                            //第一包结尾 73 00 01
                            var len = package1.Length - DataPos - 3;
                            //第一包从8个字节开始
                            Array.Copy(package1, DataPos, total, 0, len);
                            var end = Array.IndexOf<byte>(package2, ETX);
                            if (end > -1)
                            {
                                var pos = len;
                                //第二包从第4字节开始
                                len = end - 4;
                                Array.Copy(package2, 4, total, pos, len);
                            }
                            packages.Clear();
                            QRCode = ToAscii(total);
                        }
                    }
                }
            }
        }

        private static string ToAscii(byte[] buffer)
        {
            var code = Encoding.ASCII.GetString(buffer);
            code = code.Remove(code.IndexOf((char)0));
            return code;
        }


        public void Dispose()
        {
            if (_deviceIn != null)
            {
                _deviceIn.CloseDevice();
            }

            if (_accessQRReader != null)
            {
                _accessQRReader.Close();
            }

            if (_nfcReader != null)
            {
                _nfcReader.Close();
            }
        }
    }
}
