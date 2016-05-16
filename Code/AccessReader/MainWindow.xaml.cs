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
        private bool _isStop = false;
        private SerialPort _serial = null;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.DataContext = this;
        }

        public string BarCode
        {
            get { return (string)GetValue(BarCodeProperty); }
            set { SetValue(BarCodeProperty, value); }
        }

        public static readonly DependencyProperty BarCodeProperty =
            DependencyProperty.Register("BarCode", typeof(string), typeof(MainWindow), new PropertyMetadata("请刷二维码"));

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cmbPorts.Items.Add(ports.FirstOrDefault());
            if (cmbPorts.Items.Count == 0)
            {
                btnOpen.IsEnabled = false;
            }
            cmbPorts.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //二维码波特率为19200
            _serial = new SerialPort(cmbPorts.Text, 19200, Parity.None, 8, StopBits.One);
            try
            {
                _serial.Open();
                ThreadPool.QueueUserWorkItem(ReadComm);
                btnOpen.IsEnabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReadComm(object obj)
        {
            while (!_isStop)
            {
                try
                {
                    var pos = 0;
                    byte[] buffer = new byte[128];
                    var stx = (byte)_serial.ReadByte();
                    if (stx != 0x02)
                        continue;
                    byte b = 0;
                    while ((b = (byte)_serial.ReadByte()) > 0)
                    {
                        if (b == 0x03)
                            break;
                        buffer[pos] = b;
                        pos++;
                    }
                    PrintCode(buffer);
                }
                catch
                {
                    Console.WriteLine("串口关闭");
                }
            }
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
            var b = Convert.ToByte("6f", 16);
            str = str.Replace("h", "").Trim();
            var arr = str.Split(' ');
            var buffer = arr.Select(tobyte).ToArray();
            return buffer;
        }

        private byte tobyte(string str)
        {
            if (str == "00" || str == "0" || string.IsNullOrEmpty(str))
                return 0;

            var b = Convert.ToByte(str, 16);
            return b;
        }

        private void btnIC_Click(object sender, RoutedEventArgs e)
        {
            _serial = new SerialPort(cmbPorts.Text, 115200, Parity.None, 8, StopBits.One);
            try
            {
                _serial.Open();
                ThreadPool.QueueUserWorkItem(ReadCommIC);
                btnIC.IsEnabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetHex(byte[] buffer)
        {
            var str = string.Join(" ", buffer.Where(s => s >= 0).Select(s => s.ToString("X2") + "h").ToArray());
            return str;
        }

        int CMD = 0;
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var str = "";
            //获取卡类
            str = "6fh 02h 00h 00h 00h 00h 00h 00h 00h 00h 00h 00h";
            CMD = 1;
            var data = GetData(str);
            _serial.Write(data.ToArray(), 0, data.Length);
        }

        private void ReadCommIC(object obj)
        {
            while (!_isStop)
            {
                try
                {
                    var pos = 0;
                    byte[] buffer = new byte[128];
                    var stx = (byte)_serial.ReadByte();
                    if (stx == 0x50)
                    {
                        var b1 = (byte)_serial.ReadByte();
                        var b2 = (byte)_serial.ReadByte();
                        if (b1 == 1)
                            Log("进入");
                        else
                            Log("离开");
                        if (b2 == 0x01)
                            Log("SO14443-4 A");
                        else if (b2 == 0x03)
                            Log("Mifare Classic 1K");
                        else
                            Log("其它类型:" + buffer[2]);

                        continue;
                    }
                    else
                    {
                        var len = (byte)_serial.ReadByte();
                        Log("读卡器返回, len=" + len);
                        var data = readAll(8 + len);
                        var cardData = new byte[len];
                        Array.Copy(data, 8, cardData, 0, len);
                        var hex = GetHex(cardData);
                        Log(hex);
                        if (CMD == 1)
                        {
                            if (cardData[2] == 0x03)
                            {
                                var arr = new byte[4];
                                Array.Copy(cardData, 3, arr, 0, 4);
                                var uid = BitConverter.ToUInt32(arr, 0);
                                Log("卡类=Mifare Classic 1K  卡数据=" + string.Join(" ", arr.Select(s => s.ToString("X2"))) + " UID=" + uid);
                            }
                            else if (cardData[2] == 0x04)
                                Log("Mifare Classic 4K");
                            else if (cardData[2] == 0x05)
                                Log("Mifare Ultralight");
                        }
                        else if (CMD == 2)
                        {
                            if( len ==4)
                            {
                                if (cardData[2] == 0x90 && data[3] == 0x00)
                                {
                                    Log("设置密码成功");
                                }
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("串口关闭");
                }
            }
        }


        private byte[] readAll(int len)
        {
            var data = new byte[len];
            var pos = 0;
            var readlen = len - pos;
            while ((pos = _serial.Read(data, pos, readlen)) > 0)
            {
                if (pos == len)
                    break;
                pos += pos;
                readlen = len - pos;
            }
            return data;
        }

        private void btnMifareType_Click(object sender, RoutedEventArgs e)
        {
            //装载密码
            CMD = 2;
            var str = "6fh 08h 00h 00h 00h 00h 00h 00h 00h 00h 00h 02h FFh FFh FFh FFh FFh FFh";
            var data = GetData(str);
            _serial.Write(data.ToArray(), 0, data.Length);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txt.Clear();
        }
    }
}
