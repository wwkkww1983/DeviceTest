using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HIDSdk;
using System.Diagnostics;

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

        private const byte DataStartPos = 8;
        private const byte ETX = 0x03;

        private HidDevice _deviceIn = null;
        private HidDevice _deviceOut = null;
        private delegate void ReadHandlerDelegate(HidReport report);
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.DataContext = this;
        }

        public string QRCode
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Code.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("QRCode", typeof(string), typeof(MainWindow));



        public string DataBuffer
        {
            get { return (string)GetValue(DataBufferProperty); }
            set { SetValue(DataBufferProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataBuffer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataBufferProperty =
            DependencyProperty.Register("DataBuffer", typeof(string), typeof(MainWindow));



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
                _deviceIn.OpenDevice();
                _deviceIn.MonitorDeviceEvents = true;
                _deviceIn.Inserted += Device_Inserted;
                _deviceIn.Removed += Device_Removed;
                _deviceIn.ReadReport(ReadProcess);
            }

            if (_deviceOut != null)
            {
                _deviceOut.OpenDevice();
                _deviceOut.MonitorDeviceEvents = true;
                _deviceOut.Inserted += Device_Inserted;
                _deviceOut.Removed += Device_Removed;
                _deviceOut.ReadReport(ReadProcess);
            }
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

        private void ReadHandler(HidReport report)
        {
            var empty = "09 5D 5A 36 43 42 52 45 4E 41 30 06 2E";
            var data = String.Join(" ", report.Data.Select(d => d.ToString("X2")));
            DataBuffer = data + "->" + report.Data.Length;
            if (data.StartsWith(empty))
            {
                Debug.WriteLine("心跳" + report.ReadStatus);
            }
            else
            {
                var buffer = report.Data;
                if (buffer.All(s => s == 0))
                {
                    Debug.WriteLine("断开");
                    _deviceIn.CloseDevice();
                    return;
                }
                else
                {
                    var end = Array.IndexOf<byte>(buffer, ETX);
                    if (end > -1)
                    {
                        var dataLen = end - DataStartPos;
                        var xdata = new byte[dataLen];
                        Array.Copy(buffer, DataStartPos, xdata, 0, dataLen);
                        Debug.WriteLine(data);
                        var code = Encoding.ASCII.GetString(xdata);
                        QRCode = code + "->" + code.Length;
                        Debug.WriteLine(code);
                    }
                    else
                    {
                        Debug.WriteLine(data);
                    }
                }
            }
            _deviceIn.ReadReport(ReadProcess);
        }
    }
}
