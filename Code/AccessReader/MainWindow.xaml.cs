using AccessReader.Code;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccessReader
{
    /// <summary>
    /// Access IS
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.DataContext = this;
            _nfc = new NFCSerialPort();
        }

        public string BarCode
        {
            get { return (string)GetValue(BarCodeProperty); }
            set { SetValue(BarCodeProperty, value); }
        }

        public static readonly DependencyProperty BarCodeProperty =
            DependencyProperty.Register("BarCode", typeof(string), typeof(MainWindow), new PropertyMetadata("请刷二维码"));

        private void AddComboxItem(ComboBox cmb, string[] ports)
        {
            foreach (var port in ports)
            {
                cmb.Items.Add(new ComboBoxItem { Content = port });
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            AddComboxItem(cmbBarcodePorts, ports);
            AddComboxItem(cmbNFCPorts, ports);
            if (ports.Length == 0)
            {
                btnBarOpen.IsEnabled = false;
                btnNFC.IsEnabled = false;
            }
            else
            {
                cmbBarcodePorts.SelectedIndex = 0;
                cmbNFCPorts.SelectedIndex = 0;
            }
        }

        private BarcodeSerialPort _barcode = null;
        private NFCSerialPort _nfc = null;
        private void btnBarOpen_Click(object sender, RoutedEventArgs e)
        {
            if (_barcode == null)
            {
                _barcode = new BarcodeSerialPort();
            }
        }

        private void btnNFC_Click(object sender, RoutedEventArgs e)
        {
            if (_nfc == null)
            {
                _nfc = new NFCSerialPort();
            }
            _nfc.Open(cmbNFCPorts.Text);
        }

        private void Log(object obj)
        {
            System.Diagnostics.Debug.WriteLine(obj.ToString());
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                txt.Text += obj.ToString() + Environment.NewLine;
            }));
        }

        private void PrintCode(byte[] buffer)
        {
            var arr = buffer.Where(s => s > 0).Select(s => s.ToString("X2")).ToArray();
            var hex = string.Join(" ", arr);
            Log(hex);
            this.Dispatcher.Invoke(new Action(() =>
            {
                var code = System.Text.Encoding.ASCII.GetString(buffer);
                var pos = code.IndexOf((char)0);
                code = code.Remove(pos);
                BarCode = code;
                Log(code);
            }));
        }

        private byte[] GetData(string str)
        {
            var len = str.Split(' ').Length;
            str = string.Format(prefix, len) + str;
            str = str.Replace("h", "").Trim();
            var arr = str.Split(' ');
            var buffer = arr.Select(SelectTobyte).ToArray();
            return buffer;
        }

        private byte SelectTobyte(string str)
        {
            if (str == "00" || str == "0" || string.IsNullOrEmpty(str))
                return 0;

            var b = Convert.ToByte(str, 16);
            return b;
        }


        int CMD = 0;
        private const string prefix = "6fh {0} 00h 00h 00h 00h 00h 00h 00h 00h ";
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var str = "";
            //获取卡类
            str = "00h 00h";
            var data = GetData(str);
            _nfc.CMD = 1;
            _nfc.Write(data.ToArray());
        }

        private void btnMifareType_Click(object sender, RoutedEventArgs e)
        {
            //装载密码
            var str = "00h 02h FFh FFh FFh FFh FFh FFh";
            var data = GetData(str);
            _nfc.CMD = 2;
            _nfc.Write(data.ToArray());
        }

        private void Authenticateblock(string blocknumber)
        {
            //04 44 keyA
            //14 54 keyB
            var str = "00 04 " + blocknumber;
        }

        private void ReadBlock(string blocknumber)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txt.Clear();
        }
    }
}
