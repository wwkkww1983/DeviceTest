using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace KanNaD_C2000
{
    /// <summary>
    /// 使用说明
    /// 1、搜索到设备后，将设备设置为服务器模式
    /// 2、设置工作模式为：服务器模式
    /// 3、设置侦听端口为：9876
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Loaded += MainWindow_Loaded;
        }

        TcpClient tcp = new TcpClient();
        NetworkStream nws = null;

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tcp.Connect(IPAddress.Parse("192.168.1.71"), 9877);
            nws = tcp.GetStream();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            List<byte> list = new List<byte>();
            list.Add(00);
            list.Add(01);

            list.Add(00);
            list.Add(00);

            list.Add(00);
            list.Add(08);

            list.Add(0xFF);
            list.Add(0x0F);

            list.Add(00);
            list.Add(0x64);

            list.Add(00);
            list.Add(02);

            list.Add(01);
            list.Add(01);


            var data = list.ToArray();
            nws.Write(data, 0, data.Length);

            byte[] buffer = new byte[128];
            var len = nws.Read(buffer, 0, buffer.Length);
            Console.WriteLine("read len->" + len);

            for (int i = 0; i < len; i++)
            {
                Console.Write(buffer[i].ToString("X2") + " ");
            }
            Console.WriteLine("");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            List<byte> list = new List<byte>();
            list.Add(00);
            list.Add(01);

            list.Add(00);
            list.Add(00);

            list.Add(00);
            list.Add(08);

            list.Add(0xFF);
            list.Add(0x0F);

            list.Add(00);
            list.Add(0x64);

            list.Add(00);
            list.Add(02);

            list.Add(01);
            list.Add(00);

            var data = list.ToArray();
            nws.Write(data, 0, data.Length);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            List<byte> list = new List<byte>();
            list.Add(00);
            list.Add(01);

            list.Add(00);
            list.Add(00);

            list.Add(00);
            list.Add(08);

            list.Add(0xFF);
            list.Add(0x0F);

            list.Add(00);
            list.Add(0x64);

            list.Add(00);
            list.Add(02);

            list.Add(01);
            list.Add(02);


            var data = list.ToArray();
            nws.Write(data, 0, data.Length);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            List<byte> list = new List<byte>();
            list.Add(00);
            list.Add(01);

            list.Add(00);
            list.Add(00);

            list.Add(00);
            list.Add(08);

            list.Add(0xFF);
            list.Add(0x0F);

            list.Add(00);
            list.Add(0x64);

            list.Add(00);
            list.Add(02);

            list.Add(01);
            list.Add(03);


            var data = list.ToArray();
            nws.Write(data, 0, data.Length);
        }

        private void Loop_click(object sender, RoutedEventArgs e)
        {
            //btn.Visibility = Visibility.Collapsed;

            Task.Factory.StartNew(() =>
            {
                Button1_Click(null, null);
                this.Dispatcher.Invoke(() => { lblResult.Content = "1开"; });
                System.Threading.Thread.Sleep(1500);
                Button2_Click(null, null);
                this.Dispatcher.Invoke(() => { lblResult.Content = "1关"; });

                System.Threading.Thread.Sleep(1500);
                Button3_Click(null, null);
                this.Dispatcher.Invoke(() => { lblResult.Content = "2开"; });

                System.Threading.Thread.Sleep(1500);
                Button2_Click(null, null);
                this.Dispatcher.Invoke(() => { lblResult.Content = "2关"; });
            });
        }
    }
}
