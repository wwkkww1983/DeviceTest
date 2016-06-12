using AccessReader.Code;
using Common;
using Common.NotifyBase;
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

        private DataViewModel _data = null;
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

            _data = new DataViewModel();
            this.DataContext = _data;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cmbBarcodePorts.ItemsSource = ports;
            cmbNFCPorts.ItemsSource = ports;
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

        private void Log(string str)
        {
            this.Dispatcher.Invoke(() =>
            {
                txt.Text += str + Environment.NewLine;
            });
        }

        private void btnBarOpen_Click(object sender, RoutedEventArgs e)
        {
            if (_barcode == null)
            {
                _barcode = new BarcodeSerialPort((code) =>
                {
                    _data.Barcode = code;
                });
                _barcode.Open(cmbBarcodePorts.Text);

                btnBarOpen.IsEnabled = false;
            }
        }

        private void btnNFC_Click(object sender, RoutedEventArgs e)
        {
            if (_nfc == null)
            {
                _nfc = new NFCSerialPort(Log);
            }
            _nfc.Open(cmbNFCPorts.Text);
            btnNFC.IsEnabled = false;
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

        #region BarCode Query
        private static byte[] CompositeBarcode(string data)
        {
            byte[] prefix_barcode = new byte[3] { 0x16, 0x4D, 0x0D };
            var buffer = System.Text.Encoding.UTF8.GetBytes(data);
            var list = new List<byte>();
            list.AddRange(prefix_barcode);
            list.AddRange(buffer);

            buffer = list.ToArray();
            return buffer;
        }

        private void btnQueryAISINF_Click(object sender, RoutedEventArgs e)
        {
            var data = CompositeBarcode("AISINF?");
            _barcode.Write(data);
        }

        private void btnQueryAISBAU_Click(object sender, RoutedEventArgs e)
        {
            var data = CompositeBarcode("AISBAU?");
            _barcode.Write(data);
        }
        #endregion

        private void btnMifareType_Click(object sender, RoutedEventArgs e)
        {
            //获取卡类
            var str = "00h 00h";
            var data = CompositeMifareData(str);
            SendDataToNFC(1, data);
        }

        private void btnLoadKey_Click(object sender, RoutedEventArgs e)
        {
            //装载密码
            var str = "00h 02h 1 2 3 4 5 6";
            var data = CompositeMifareData(str);
            SendDataToNFC(2, data);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txt.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuthenticate_Click(object sender, RoutedEventArgs e)
        {
            //new MifareWindow().Show();

            //var str = "00h 02h 1 2 3 4 5 6";
            //var data = CompositeMifareData(str);
            //SendDataToNFC(2, data);
            //Thread.Sleep(500);

            var str = "00h 04h 1";
            var data = CompositeMifareData(str);
            SendDataToNFC(3, data);
        }

        private void btnWriteBlock_Click(object sender, RoutedEventArgs e)
        {
            var str = "00h 48h 1 1 2 3 4 5 6 7 8 9 A B C D E F 10";
            var data = CompositeMifareData(str);
            SendDataToNFC(4, data);
        }

        private void btnReadBlock_Click(object sender, RoutedEventArgs e)
        {

            var str = "00h 02h 1 2 3 4 5 6";
            var data = CompositeMifareData(str);
            SendDataToNFC(2, data);
            Thread.Sleep(500);

            var str1 = "00h 06h 2";
            var data1 = CompositeMifareData(str1);
            SendDataToNFC(5, data1);
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

        private string GetTag(int len)
        {
            var str = "";
            for (var i = 0; i < len; i++)
            {
                str += "00 ";
            }
            str = str.Trim();
            return str;
        }

        private void btnFireware_Click(object sender, RoutedEventArgs e)
        {
            //
            var str = "00";
            //var tag = GetTag(63);
            //str = str + " " + tag;
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
