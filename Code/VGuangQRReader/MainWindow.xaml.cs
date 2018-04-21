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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VGuangQRReader
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Test vm = null;
        public MainWindow()
        {
            InitializeComponent();

            vm = new Test();
            this.DataContext = vm;
        }

        private SerialPort port = null;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
            port.Open();
            ThreadPool.QueueUserWorkItem(Read);
        }


        private void Read(object arg)
        {
            while (true)
            {
                int b = 0;
                List<byte> buffer = new List<byte>();
                while ((b = port.ReadByte()) > 0)
                {
                    if (b != 13)
                    {
                        buffer.Add((byte)b);
                    }
                    else
                    {
                        var array = buffer.ToArray();
                        var code = System.Text.Encoding.UTF8.GetString(array);
                        Console.WriteLine("QRcode->" + DateTime.Now.ToString("HH:mm:ss") + " " + code);
                        buffer.Clear();
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vm.LastVehicle = true;
            vm.LastVehicle = false;
            vm.TipContent = "最后一张";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var single = "55AA22010002DE";
            var interval = "55AA220300030200DF";

            port.Write("55AA25010000DB");
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            vm.FirstVehicle = false;
        }
    }
}
