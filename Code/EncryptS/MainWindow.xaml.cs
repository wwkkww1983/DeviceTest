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
            //http://www.cr173.com/html/17773_1.html
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
            Encode(sha1);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider();
            Encode(sha);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            SHA384CryptoServiceProvider sha = new SHA384CryptoServiceProvider();
            Encode(sha);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            SHA512CryptoServiceProvider sha = new SHA512CryptoServiceProvider();
            Encode(sha);
        }

        private void Encode(HashAlgorithm sha)
        {
            var bufferIn = Encoding.UTF8.GetBytes(txtSource.Text);
            var bufferOut = sha.ComputeHash(bufferIn);

            var str = Convert.ToBase64String(bufferOut, 0, bufferOut.Length);

            str = GetEncode(bufferOut);
            txtEncode.Text = str.Length + " " + str;
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
            Encode(md);
        }
    }
}
