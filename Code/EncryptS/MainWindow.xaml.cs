using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security;
using System.Security.Cryptography;
namespace EncryptS
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string GetEncode(byte[] buffer)
        {
            //var str = Encoding.UTF8.GetString()
            var sb = new StringBuilder();
            foreach (var b in buffer)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            var bufferIn = Encoding.UTF8.GetBytes(txtSource.Text);
            var bufferOut = sha1.ComputeHash(bufferIn);

            var str = GetEncode(bufferOut);
            txtEncode.Text = str.Length + " " + str;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
           SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();

            var bufferIn = Encoding.UTF8.GetBytes(txtSource.Text);
            var bufferOut = sha256.ComputeHash(bufferIn);

            var str = GetEncode(bufferOut);
            txtEncode.Text = str.Length + " " + str;
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            SHA384CryptoServiceProvider sha384 = new SHA384CryptoServiceProvider();

            var bufferIn = Encoding.UTF8.GetBytes(txtSource.Text);
            var bufferOut = sha384.ComputeHash(bufferIn);

            var str = GetEncode(bufferOut);
            txtEncode.Text = str.Length + " " + str;
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            SHA512CryptoServiceProvider sha = new SHA512CryptoServiceProvider();

            var bufferIn = Encoding.UTF8.GetBytes(txtSource.Text);
            var bufferOut = sha.ComputeHash(bufferIn);

            var str = GetEncode(bufferOut);
            txtEncode.Text = str.Length + " " + str;
        }
    }
}
