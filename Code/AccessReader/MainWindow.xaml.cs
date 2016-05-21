using AccessReader.Code;
using Common;
using Common.NotifyBase;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccessReader
{
    /// <summary>
    /// AccessIS三合一
    /// </summary>
    public partial class MainWindow
    {
        private NFCSerialPort _nfc = null;
        private BarcodeSerialPort _barcode = null;
        int CMD = 0;
        //messagetype   0 1
        //datalen       4 4
        //slot Id       5 1
        //seq           6 1
        //bwi           7 1
        //levelparameter8 2
        private const string prefix_mifare = "6fh {0} 00h 00h 00h 00h 00h 00h 00h 00h ";
        private const string prefix_nfc = "6fh {0} 00h 00h 00h FFh 00h 00h 00h 00h ";
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
            DependencyProperty.Register("BarCode", typeof(string), typeof(MainWindow), new PropertyMetadata(""));

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

        private void btnBarOpen_Click(object sender, RoutedEventArgs e)
        {
            if (_barcode == null)
            {
                _barcode = new BarcodeSerialPort((code) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        BarCode = code;
                    });
                });
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
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                txt.Text += obj.ToString() + Environment.NewLine;
            }));
        }

        private byte[] CompositeMifareData(string str)
        {
            var len = str.Split(' ').Length;
            str = string.Format(prefix_mifare, len) + str;
            str = str.Replace("h", "").Trim();
            var arr = str.Split(' ');
            var buffer = arr.Select(SelectTobyte).ToArray();
            return buffer;
        }

        private byte SelectTobyte(string str)
        {
            var b = Convert.ToByte(str, 16);
            return b;
        }

        private void SendDataToNFC(int cmd, byte[] data)
        {
            _nfc.CMD = cmd;
            _nfc.Write(data.ToArray());
        }
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            //获取卡类
            var str = "00h 00h";
            var data = CompositeMifareData(str);
            SendDataToNFC(1, data);
        }

        private void btnMifareType_Click(object sender, RoutedEventArgs e)
        {
            //装载密码
            var str = "00h 02h FFh FFh FFh FFh FFh FFh";
            var data = CompositeMifareData(str);
            SendDataToNFC(2, data);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txt.Clear();
        }

        private void btnMifare_Click(object sender, RoutedEventArgs e)
        {
            new MifareWindow().Show();
        }


        #region NFC package

        private byte[] CompositeNFCData(string str)
        {
            var len = str.Split(' ').Length;
            str = string.Format(prefix_nfc, len) + str;
            str = str.Replace("h", "").Trim();
            var arr = str.Split(' ');
            var buffer = arr.Select(SelectTobyte).ToArray();
            return buffer;
        }

        private void btnFireware_Click(object sender, RoutedEventArgs e)
        {
            //
            var str = "00";
            var data = CompositeNFCData(str);
            SendDataToNFC(0, data);
        }

        private void btnLoader_Click(object sender, RoutedEventArgs e)
        {
            //
            var str = "01";
            var data = CompositeNFCData(str);
            SendDataToNFC(0, data);
        }

        private void btnNFCSerialNumber_Click(object sender, RoutedEventArgs e)
        {
            //
            var str = "03";
            var data = CompositeNFCData(str);
            SendDataToNFC(0, data);
        }

        private void btnNFCGetTiming_Click(object sender, RoutedEventArgs e)
        {
            //
            var str = "06 00 08";
            var data = CompositeNFCData(str);
            SendDataToNFC(0, data);
        }

        private void btnEnterSleep_Click(object sender, RoutedEventArgs e)
        {
            //
            var str = "07";
            var data = CompositeNFCData(str);
            SendDataToNFC(0, data);
        }

        private void btnExitSleep_Click(object sender, RoutedEventArgs e)
        {
            //
            var str = "09";
            var data = CompositeNFCData(str);
            SendDataToNFC(0, data);
        }

        private void btnKernel_Click(object sender, RoutedEventArgs e)
        {
            //
            var str = "0B";
            var data = CompositeNFCData(str);
            SendDataToNFC(0, data);
        }

        private void btnMediaSerialNumber_Click(object sender, RoutedEventArgs e)
        {
            //
            var str = "0D";
            //return
            //1 command code
            //2 media type  1[ISO14443-4A] 2[ISO14443-4B] 3[1K] 4[4] 5[Ultraligth] 6[Mifare plus]
            //3 follow bytes
            var data = CompositeNFCData(str);
            SendDataToNFC(0, data);
        }

        private void btnDisableMediaArrival_Click(object sender, RoutedEventArgs e)
        {
            //
            var str = "0E FF 01";
            var data = CompositeNFCData(str);
            SendDataToNFC(0, data);
        }

        private void btnChangeBaud_Click(object sender, RoutedEventArgs e)
        {
            //
            var str = "10 04 55 5A A5 AA";
            var data = CompositeNFCData(str);
            SendDataToNFC(0, data);
        }
        #endregion
    }
}
