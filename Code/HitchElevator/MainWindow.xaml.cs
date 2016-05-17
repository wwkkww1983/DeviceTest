using Common;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common.NotifyBase;
using HitchElevator.Core;
using HitachiLift;
using System.Windows.Media.Animation;

namespace HitchElevator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        private AccessISPort _access = null;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Loaded += MainWindow_Loaded;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            ClosePort();
            base.OnClosing(e);
        }

        public static readonly DependencyProperty BarcodeFloorProperty =
            DependencyProperty.Register("BarcodeFloor", typeof(string), typeof(MainWindow), new PropertyMetadata("楼层:"));
        public string BarcodeFloor
        {
            get { return (string)GetValue(BarcodeFloorProperty); }
            set { SetValue(BarcodeFloorProperty, value); }
        }

        private void AddComboxItem(ComboBox cmb, string[] ports)
        {
            foreach (var port in ports)
            {
                cmb.Items.Add(new ComboBoxItem { Content = port });
            }
        }

        public void Log(string obj, params object[] arg)
        {
            this.Dispatcher.Invoke(() =>
            {
                listbox.Items.Add(string.Format(obj, arg));
            });
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var ComPorts = System.IO.Ports.SerialPort.GetPortNames();
            AddComboxItem(cmbIS, ComPorts);
            AddComboxItem(cmbSelecter, ComPorts);

            if (cmbIS.Items.Count > 0)
                cmbIS.SelectedIndex = 0;
            if (cmbSelecter.Items.Count > 0)
                cmbSelecter.SelectedIndex = 0;

            for (int i = 1; i <= 32; i++)
            {
                cmbFloors.Items.Add(i);
            }
            cmbFloors.SelectedIndex = 7;

            SerialPortOperate.Window = this;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (cmbIS.Text == cmbSelecter.Text)
            {
                MessageBox.Show("不能为相同串口!");
                return;
            }
            _access = new AccessISPort();
            _access.SetCallBack(OnReadBarCode);
            _access.Open(cmbIS.Text);

            SerialPortOperate.Open(cmbSelecter.Text);
            btnOpen.IsEnabled = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClosePort();
            btnOpen.IsEnabled = true;
            Log("串口关闭");
        }

        private void ClosePort()
        {
            if (_access != null)
            {
                _access.Close();
                _access = null;
            }
            SerialPortOperate.ClosePort();
        }

        private void OnReadBarCode(string barcode)
        {
            var floor = barcode.ToInt32();
            SendToSelector(floor);
        }

        private void SendToSelector(int floor)
        {
            var animation = OpacityAnimation();
            tbBarcode.BeginAnimation(Label.OpacityProperty, animation);

            byte bx = 0x00;
            var b41 = (byte)(bx | floor);
            var handBuffer = Funs.InitArray(8, 0x00);
            var total = Package.CardDataSendToLiftPackage(0, handBuffer, b41);
            BarcodeFloor = "楼层：" + floor;
            var bsend = SerialPortOperate.SendData(total);
            if (bsend)
            {
                Log("自动权限层：{0} {1}", b41.ToHex(), floor);
                Log("长度：{0}", total.Length);
                Log("数据：{0}", total.ToHex());
            }
        }

        /// <summary>
        /// 手动选层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHandFloor_Click(object sender, RoutedEventArgs e)
        {
            var floor = cmbFloors.Text.ToInt32();
            SendToSelector(floor);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            listbox.Items.Clear();
        }

        private DoubleAnimation OpacityAnimation()
        {
            DoubleAnimation opacity = new DoubleAnimation(1, (Duration)TimeSpan.FromSeconds(2));
            opacity.From = 0.1;
            return opacity;
        }
    }
}
