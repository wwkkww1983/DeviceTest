using Common.Log;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Common
{
    public static class Utility
    {
        //64 SoftWare\Wow6432Node\Microsoft\Windows\CurrentVersion\\Run
        const string keyName = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        //[RegistryPermission(SecurityAction.PermitOnly, Read=keyName, Write = keyName)]
        public static bool runWhenStart(bool started, string exeName, string path)
        {
            RegistryKey key = null;
            try
            {
                key = Registry.LocalMachine.OpenSubKey(keyName, true);//打开注册表子项
                if (key == null)
                {
                    //如果该项不存在，则创建该子项
                    key = Registry.LocalMachine.CreateSubKey(keyName);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Info("设置开机启动失败：" + ex.Message);
                return false;
            }
            if (started == true)
            {
                try
                {
                    key.SetValue(exeName, path);//设置为开机启动
                    key.Close();
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    key.DeleteValue(exeName);//取消开机启动
                    key.Close();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public static List<string> SerialPorts()
        {
            var ports = SerialPort.GetPortNames().ToList();
            if (ports.Count > 0)
            {
                ports = ports.OrderBy(s => s.Length).ToList();
            }
            ports.Insert(0, "None");
            return ports;
        }

        public static string GetHostIpAddress()
        {
            var hostname = Dns.GetHostName();
            var ipAddress = Dns.GetHostAddresses(hostname);
            foreach (IPAddress ip in ipAddress)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }

        public static string OpenFileDialog()
        {
            var filter = "Jpg文件|*.jpg|Png文件|*.png";
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = filter;
            dialog.Title = "选择文件";
            var dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
                return dialog.FileName;
            else
                return string.Empty;
        }

        /// <summary>
        /// 将图片文件转换成BitmapSource
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <returns></returns>
        public static System.Windows.Media.Imaging.BitmapSource ToBitmapSource(string sFilePath)
        {
            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(sFilePath,
                System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    fs.Dispose();

                    System.Windows.Media.Imaging.BitmapImage bitmapImage =
                        new System.Windows.Media.Imaging.BitmapImage();
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = ms;
                        bitmapImage.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                        bitmapImage.Freeze();
                    }
                    return bitmapImage;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public static BitmapSource BitmapToBitmapSource(System.Drawing.Bitmap bitmap)
        {
            try
            {
                IntPtr ptr = bitmap.GetHbitmap();
                BitmapSource result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ptr, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                DeleteObject(ptr);
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static System.Drawing.Image CutImage(System.Drawing.Image source, int left, int top, int width, int height)
        {
            var rect = new System.Drawing.Rectangle { X = left, Y = top, Width = width, Height = height };

            System.Drawing.Bitmap destImage = new System.Drawing.Bitmap(width, height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(destImage);
            g.Clear(System.Drawing.Color.Transparent);
            g.DrawImage(source,
                new System.Drawing.Rectangle { X = 0, Y = 0, Width = width, Height = height },
                rect,
                System.Drawing.GraphicsUnit.Pixel);

            g.Save();
            g.Dispose();

            return destImage;
        }

        public static string GUID()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string GetWeekOfDay()
        {
            string[] weekDay = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = weekDay[(int)DateTime.Now.DayOfWeek].ToString();
            return week;
        }
    }
}
