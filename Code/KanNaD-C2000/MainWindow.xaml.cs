using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
            //tcp.Connect(IPAddress.Parse("192.168.1.71"), 9877);
            //nws = tcp.GetStream();

            serial = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            serial.Open();

            ThreadPool.QueueUserWorkItem(WhileRead);
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

        private void WhileRead(object arg)
        {
            while (true)
            {
                var b = 0;
                while ((b = serial.ReadByte()) >= 0)
                {
                    Console.Write(b.ToString("X2") + " ");
                }
            }
        }

        SerialPort serial = null;
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            var data = SerialData(1);
            serial.Write(data, 0, data.Length);

            Thread.Sleep(1000);

            data = SerialData(0);
            serial.Write(data, 0, data.Length);
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            var data = SerialData(2);
            serial.Write(data, 0, data.Length);

            Thread.Sleep(1000);

            data = SerialData(0);
            serial.Write(data, 0, data.Length);
        }


        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            var data = SerialData(3);
            serial.Write(data, 0, data.Length);

            Thread.Sleep(1000);

            data = SerialData(0);
            serial.Write(data, 0, data.Length);
        }

        private byte[] SerialData(byte data)
        {
            List<byte> list = new List<byte>();
            //地址
            list.Add(01);
            //功能码
            list.Add(0x0F);
            //起始地址
            list.Add(00);
            list.Add(0x64);
            //寄存器个数
            list.Add(00);
            list.Add(02);
            //数据长度
            list.Add(01);
            //数据
            list.Add(data);

            list.Add(0);
            list.Add(0);

            byte[] crc = new byte[2];
            GetCRC(list.ToArray(), ref crc);

            Console.WriteLine(crc[0].ToString("X2"));
            Console.WriteLine(crc[1].ToString("X2"));

            list[list.Count - 2] = crc[0];
            list[list.Count - 1] = crc[1];

            var buffer = list.ToArray();
            return buffer;
        }

        private void GetCRC(byte[] message, ref byte[] CRC)
        {
            //Function expects a modbus message of any length as well as a 2 byte CRC array in which to 
            //return the CRC values:

            ushort CRCFull = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;
            char CRCLSB;

            for (int i = 0; i < (message.Length) - 2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ message[i]);

                for (int j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }
            CRC[1] = CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
            CRC[0] = CRCLow = (byte)(CRCFull & 0xFF);
        }
    }
}
