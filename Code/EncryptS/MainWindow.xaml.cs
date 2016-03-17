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
using System.IO;
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

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            var t = X.EncryptDES(txtSource.Text);
            txtEncode.Text = t;
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            var t = X.DecryptDES(txtEncode.Text);
            txtSource.Text = t;
        }
    }


    static class X
    {
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        public static string EncryptDES(string encryptString, string encryptKey = "yangshaojie")
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串 keleyi.com
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey = "yangshaojie")
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }
    }
}
