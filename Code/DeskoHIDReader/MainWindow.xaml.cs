using HIDSdk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeskoHIDReader
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string vid_in = "0c2e";
        private const string pid_in = "";

        private const string vid_out = "0c2f";
        private const string pid_out = "";

        private const byte DataPos = 8;
        private const byte ETX = 0x03;

        private HidDevice _deviceIn = null;
        private HidDevice _deviceOut = null;
        private delegate void ReadHandlerDelegate(HidReport report);

        private const string heartbitpackage = "09 5D 5A 36 43 42 52 45 4E 41 30 06 2E";

        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("QRCode", typeof(string), typeof(MainWindow));

        public static readonly DependencyProperty DataBufferProperty =
            DependencyProperty.Register("DataBuffer", typeof(string), typeof(MainWindow));
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
            this.DataContext = this;

            this.Left = 0;
            this.Top = 0;
            this.Width = SystemParameters.PrimaryScreenWidth;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (_deviceIn != null && _deviceIn.IsOpen)
            {
                _deviceIn.CloseDevice();
            }
            if (_deviceOut != null && _deviceOut.IsOpen)
            {
                _deviceOut.CloseDevice();
            }
            base.OnClosing(e);
        }

        public string QRCode
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        public string DataBuffer
        {
            get { return (string)GetValue(DataBufferProperty); }
            set { SetValue(DataBufferProperty, value); }
        }

        private void RefreshDevice()
        {
            _deviceIn = HidDevices.Enumerate().FirstOrDefault(s => s.DevicePath.Contains(vid_in));
            _deviceOut = HidDevices.Enumerate().FirstOrDefault(s => s.DevicePath.Contains(vid_out));
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDevice();

            if (_deviceIn != null)
            {
                RegisterHidDevice(_deviceIn);
            }
            if (_deviceOut != null)
            {
                RegisterHidDevice(_deviceOut);
            }
        }

        private void RegisterHidDevice(HidDevice device)
        {
            device.OpenDevice();
            device.MonitorDeviceEvents = true;
            device.Inserted += Device_Inserted;
            device.Removed += Device_Removed;
            device.ReadReport(ReadProcess);
        }

        void Device_Removed()
        {
            Debug.WriteLine("Disconnected");
        }

        void Device_Inserted()
        {
            Debug.WriteLine("connected");
        }

        private void ReadProcess(HidReport report)
        {
            this.Dispatcher.BeginInvoke(new ReadHandlerDelegate(ReadHandler), new object[] { report });
        }

        List<byte[]> packages = new List<byte[]>();
        private void ReadHandler(HidReport report)
        {
            var data = String.Join(" ", report.Data.Select(d => d.ToString("X2")));
            DataBuffer = string.Concat(data, "->", report.Data.Length);
            if (data.StartsWith(heartbitpackage))
            {
                Debug.WriteLine(data);
                Debug.WriteLine("heartBit");
            }
            else
            {
                var buffer = report.Data;
                if (buffer.All(s => s == 0))
                {
                    Debug.WriteLine("Disconnected");
                    _deviceIn.CloseDevice();
                    return;
                }
                else
                {
                    if (buffer.Last() == 0x01)
                    {
                        //多包二维码(第一包)
                        Debug.WriteLine(buffer.First());
                        packages.Add(report.Data);
                    }
                    else
                    {
                        if (packages.Count == 0)
                        {
                            //单包二维码
                            Debug.WriteLine(buffer.First());
                            var end = Array.IndexOf<byte>(buffer, ETX);
                            if (end > -1)
                            {
                                var dataLen = end - DataPos;
                                byte[] total = new byte[128];
                                Array.Copy(buffer, DataPos, total, 0, dataLen);
                                Debug.WriteLine(data);
                                var code = ToAscii(total);
                                QRCode = code + "->" + code.Length;
                                Debug.WriteLine(code);
                            }
                            else
                            {
                                Debug.WriteLine(data);
                            }
                        }
                        else
                        {
                            Debug.WriteLine(buffer.First());
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
                            var code = ToAscii(total);
                            QRCode = code + "->" + code.Length;
                            Debug.WriteLine(code);
                        }
                    }
                }
            }
            _deviceIn.ReadReport(ReadProcess);
        }

        private static string ToAscii(byte[] buffer)
        {
            var code = Encoding.ASCII.GetString(buffer);
            code = code.Remove(code.IndexOf((char)0));
            return code;
        }
    }
}
