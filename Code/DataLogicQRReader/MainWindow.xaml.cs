using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Common;

namespace DataLogicQRReader
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        private byte ETX = 0x0D;
        private bool _isStop = false;
        private Thread _thread = null;
        private SerialPort _serial = null;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cmbPorts.ItemsSource = ports;
            cmbPorts.SelectedIndex = 0;
            btnOpen.IsEnabled = (ports.Length > 0);
        }

        private void Log(string obj, params object[] arg)
        {
            this.Dispatcher.Invoke(() =>
            {
                tbLog.AppendText((string.Format(obj, arg) + Environment.NewLine));
            });
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            _serial = new SerialPort(cmbPorts.Text, 9600, Parity.None, 8, StopBits.One);
            _serial.Open();

            _thread = new Thread(Read);
            _thread.Start();
            btnOpen.IsEnabled = false;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbLog.Clear();
        }

        private void Read()
        {
            while (!_isStop)
            {
                try
                {
                    var b = (byte)0;
                    List<byte> buffer = new List<byte>();
                    while ((b = (byte)_serial.ReadByte()) > 0)
                    {
                        buffer.Add(b);
                        if (b == ETX)
                            break;
                    }
                    ParseBarcode(buffer);
                }
                catch
                {
                    Log("读取数据异常");
                }
            }
        }

        private void ParseBarcode(List<byte> buffer)
        {
            var data = new byte[buffer.Count - 1];
            Array.Copy(buffer.ToArray(), 0, data, 0, data.Length);
            var code = data.ToUTF8String();
            Log("二维码数据:" + buffer.ToArray().ToHex());
            Log("二维码编号:" + code);
        }
    }
}
