using System;
using System.Collections;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SR_104
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort serial = null;
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var ports = SerialPort.GetPortNames().OrderBy(s => s).ToArray();
            cmbPorts.ItemsSource = ports;
            cmbPorts.SelectedIndex = 0;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            serial = new SerialPort(cmbPorts.Text, 9600, Parity.None, 8, StopBits.One);
            serial.Open();
            btnOpen.IsEnabled = false;
            btnClose.IsEnabled = true;
            btnDispose.IsEnabled = true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            BitArray ba = new BitArray(8);
            if (cb1.IsChecked.Value)
                ba[0] = true;

            if (cb2.IsChecked.Value)
                ba[1] = true;

            ba[4] = true;

            byte[] data = new byte[1];
            ba.CopyTo(data, 0);
            Console.WriteLine(data.First().ToString("X2"));
            if (serial != null && serial.IsOpen)
            {
                serial.Write(data, 0, data.Length);
            }
        }

        private void btnDispose_Click(object sender, RoutedEventArgs e)
        {
            BitArray ba = new BitArray(8);
            if (cb1.IsChecked.Value)
                ba[0] = true;

            if (cb2.IsChecked.Value)
                ba[1] = true;

            ba[5] = true;

            byte[] data = new byte[1];
            ba.CopyTo(data, 0);
            Console.WriteLine(data.First().ToString("X2"));
            if (serial != null && serial.IsOpen)
            {
                serial.Write(data, 0, data.Length);
            }
        }
    }
}
