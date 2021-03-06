﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Common
{
    public static class FunExtends
    {
        #region Byte方法扩展
        /// <summary>
        /// 字节转换为16进制
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string ToHex(this byte b)
        {
            return b.ToString("X2");
        }
        /// <summary>
        /// 字节数字转为为16进制字符串
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string ToHex(this byte[] buffer)
        {
            var sb = new StringBuilder();
            foreach (var b in buffer)
            {
                sb.Append(b.ToHex() + " ");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 16进制转换为字节
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte FromHexToByte(this string str)
        {
            byte b = 0;
            try
            {
                b = Convert.ToByte(str, 16);
            }
            catch { }
            return b;
        }
        /// <summary>
        /// 字符串转换为字节
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte ToByte(this string str)
        {
            byte b = 0;
            byte.TryParse(str, out b);
            return b;
        }
        /// <summary>
        /// 字节转换为位组
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static BitArray ToBitArray(this byte b)
        {
            return new BitArray(new byte[] { b });
        }
        #endregion

        #region Int16方法扩展
        public static byte[] ToBytes(this Int16 val)
        {
            var bytes = BitConverter.GetBytes(val);
            Array.Reverse(bytes);
            //var bytes = new byte[2];
            //bytes[0] = ((val & 0xFF00) >> 8).ToByte();
            //bytes[1] = (val & 0xFF).ToByte();
            return bytes;
        }
        #endregion

        #region Int32方法扩展
        /// <summary>
        /// 16进制转换为Int32
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int HexToInt32(this string str)
        {
            var b = 0;
            try
            {
                b = Convert.ToInt32(str, 16);
            }
            catch { }
            return b;
        }
        /// <summary>
        /// 字符转换Int32
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static UInt32 ToUInt32(this string str)
        {
            UInt32 ret = 0;
            UInt32.TryParse(str, out ret);
            return ret;
        }
        /// <summary>
        /// 字符转换Int32
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt32(this string str)
        {
            var ret = 0;
            Int32.TryParse(str, out ret);
            return ret;
        }
        /// <summary>
        /// 字符串转为Int64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Int64 ToInt64(this string str)
        {
            Int64 ret = 0;
            Int64.TryParse(str, out ret);
            return ret;
        }
        /// <summary>
        /// 数值对象转换为Int32
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt32(this object obj)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte ToByte(this int val)
        {
            return (byte)val;
        }
        /// <summary>
        /// 返回4字节数组
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static byte[] ToByte4(this int i)
        {
            byte[] buffer = new byte[4];
            buffer[3] = (byte)(i & 0xFF);
            buffer[2] = (byte)(i >> 8 & 0xFF);
            buffer[1] = (byte)(i >> 16 & 0xFF);
            buffer[0] = (byte)(i >> 24 & 0xFF);
            return buffer;
        }
        public static byte[] ToByte4(this UInt32 i)
        {
            byte[] buffer = new byte[4];
            buffer[3] = (byte)(i & 0xFF);
            buffer[2] = (byte)(i >> 8 & 0xFF);
            buffer[1] = (byte)(i >> 16 & 0xFF);
            buffer[0] = (byte)(i >> 24 & 0xFF);
            return buffer;
        }
        #endregion

        #region Char方法扩展
        public static byte HexCharToByte(this char c)
        {
            byte b = 0;
            try
            {
                b = Convert.ToByte(c.ToString(), 16);
            }
            catch { }
            return b;
        }
        #endregion

        #region Float扩展方法
        public static byte[] ToBytes(this float f)
        {
            var buffer = BitConverter.GetBytes(f);
            //Array.Reverse(buffer);
            return buffer;
        }
        #endregion

        #region String方法扩展
        /// <summary>
        /// 通讯时处理，转换字符后有时以'\0'结尾
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CommProcess(this string str)
        {
            return str.Replace("\0", "").Trim();
        }
        /// <summary>
        /// 车牌特殊字符替换
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToPlate(this string str)
        {
            //o和O替换为0
            //I替换为1
            str = str.Replace("o", "0").Replace("O", "0");
            str = str.Replace("I", "1");
            return str;
        }
        /// <summary>
        /// 数据库操作时调用
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Process(this string str)
        {
            var s = str.Trim();
            return s;
        }
        /// <summary>
        /// 日期字符串转换为DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str)
        {
            DateTime date = DateTime.MinValue;
            if (!DateTime.TryParse(str, out date))
                date = DateTime.Now;
            return date;
        }
        /// <summary>
        /// 日期格式为：20140110
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToCustomDateTime(this string str)
        {
            DateTime date = new DateTime(1970, 1, 1);
            if (str.Length != 8)
                return date;

            var newDate = string.Format("{0}-{1}-{2}", str.Substring(0, 4), str.Substring(4, 2), str.Substring(6, 2));
            DateTime.TryParse(newDate, out date);
            return date;
        }
        /// <summary>
        /// 合法Email地址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        //public static bool IsEmail(this string str)
        //{
        //    Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        //    return regex.IsMatch(str);
        //}
        /// <summary>
        /// 数值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsOnlyNumber(this string value)
        {
            Regex r = new Regex(@"^[0-9]+$");
            return r.Match(value).Success;
        }
        /// <summary>
        /// 浮点数值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsOnlyNumberDot(this string value)
        {
            Regex r = new Regex(@"^\d+[.]?\d*$");
            return r.Match(value).Success;
        }
        /// <summary>
        /// 转换为Float
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static float ToFloat(this string str)
        {
            var f = 0.0f;
            float.TryParse(str, out f);
            return f;
        }
        /// <summary>
        /// 转换为Decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string str)
        {
            decimal d = 0;
            decimal.TryParse(str, out d);
            return d;
        }
        /// <summary>
        /// 转换为Double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double ToDouble(this string str)
        {
            double d = 0;
            double.TryParse(str, out d);
            return d;
        }
        /// <summary>
        /// 字符串MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMD5(this string str)
        {
            byte[] buffer = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(buffer);
            return Convert.ToBase64String(output);
        }
        /// <summary>
        /// 图片文件转换为字节数组
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] FileToByte(this string path)
        {
            if (!File.Exists(path))
                return new byte[] { };

            return File.ReadAllBytes(path);
        }
        /// <summary>
        /// Base64 to byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] Base64ToByte(this string str)
        {
            return Convert.FromBase64String(str);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string FileToBase64(this string path)
        {
            return path.FileToByte().ToBase64();
        }
        /// <summary>
        /// 字符串ASCII
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToASCII(this string value)
        {
            if (value.IsEmpty())
                return null;

            return Encoding.ASCII.GetBytes(value);
        }
        /// <summary>
        /// 字符串GB2312
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToGB2312(this string value)
        {
            //if (value.IsEmpty())
            //    return null;

            return Encoding.GetEncoding("GB2312").GetBytes(value);
        }
        /// <summary>
        /// 字符串是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// 转全角
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(this string input)
        {
            // 半角转全角：
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 32)
                {
                    array[i] = (char)12288;
                    continue;
                }
                if (array[i] < 127)
                {
                    array[i] = (char)(array[i] + 65248);
                }
            }
            return new string(array);
        }
        /// <summary>
        /// 转半角
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToDBC(this string input)
        {
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 12288)
                {
                    array[i] = (char)32;
                    continue;
                }
                if (array[i] > 65280 && array[i] < 65375)
                {
                    array[i] = (char)(array[i] - 65248);
                }
            }
            return new string(array);
        }

        public static ImageSource ToImageSource(this string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
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

        public static bool IsIPAddress(this string str)
        {
            if (str.IsEmpty())
                return false;

            var ips = str.Split('.');
            if (ips.Length != 4)
                return false;

            var ip1 = ips[0].ToInt32();
            var ip2 = ips[1].ToInt32();
            var ip3 = ips[2].ToInt32();
            var ip4 = ips[3].ToInt32();

            if (ip1 < 256 && ip2 < 256 && ip3 < 256 && ip4 < 256)
                if (ip1 == 0 && ip2 == 1 && ip3 == 0 && ip4 == 0)
                    return false;
                else
                    return true;
            else
                return false;
        }

        public static byte[] ToUtf8(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        public static ImageSource Base64ToImageSource(this string str)
        {
            var buffer = str.Base64ToByte();
            try
            {
                System.Windows.Media.Imaging.BitmapImage image = new System.Windows.Media.Imaging.BitmapImage();
                image.BeginInit();
                image.StreamSource = new MemoryStream(buffer);
                image.EndInit();
                return image;
            }
            catch
            {
                return null;
            }
        }

        public static string UrlEncode(this string content)
        {
            return HttpUtility.UrlEncode(content);
        }

        public static T Deserialize<T>(this string input)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(input);
        }

        #endregion

        #region byte[] 扩展方法
        /// <summary>
        /// 按指定编码格式，将数组转换为字符串
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string BufferToString(this byte[] buffer, Encoding encode)
        {
            return encode.GetString(buffer).CommProcess();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string ToUTF8String(this byte[] buffer)
        {
            var str = buffer.BufferToString(Encoding.UTF8);
            if (str.IndexOf((char)0) > -1)
                str = str.Remove(str.IndexOf((char)0));
            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string ToGB2312String(this byte[] buffer)
        {
            return buffer.BufferToString(Encoding.Default);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string ToBase64(this byte[] buffer)
        {
            return Convert.ToBase64String(buffer);
        }

        public static ImageSource ToImageSource(this byte[] buffer)
        {
            try
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new MemoryStream(buffer);
                image.EndInit();
                return image;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Datetime 扩展方法
        /// <summary>
        /// 缩减版年月日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToYmd(this DateTime date)
        {
            return date.ToString("yyyyMMdd");
        }
        /// <summary>
        /// 短日期
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToShortDate(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToShortTime(this DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToHM(this DateTime date)
        {
            return date.ToString("HH:mm");
        }
        /// <summary>
        /// 长日期
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStandard(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 年-月-日 时:分
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToYmdhm(this DateTime date)
        {
            return date.ToString("yy-MM-dd HH:mm");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToShotShow(this DateTime date)
        {
            return date.ToString("yy/MM/dd HH:mm:ss");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToFileName(this DateTime date)
        {
            ///应对多次抓拍的情况，需要毫秒
            return date.ToString("yyyyMMddHHmmssfff");
        }
        /// <summary>
        /// 日期起始
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetDayStart(this DateTime date)
        {
            return date.Date;
        }
        /// <summary>
        /// 日期最大
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetDayEnd(this DateTime date)
        {
            return date.Date.AddDays(1).AddSeconds(-1);
        }
        /// <summary>
        /// 周日开始
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime WeekOfStartDay(this DateTime date)
        {
            int today = (int)date.DayOfWeek;
            return date.AddDays(-today);
        }
        /// <summary>
        /// 周日结束
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime WeekOfEndDay(this DateTime date)
        {
            int today = (int)date.DayOfWeek;
            return date.AddDays(6 - today);
        }
        /// <summary>
        /// 月开始
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime MonthOfFirstDay(this DateTime date)
        {
            return date.AddDays(1 - date.Day).GetDayStart();
        }
        /// <summary>
        /// 月截止
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime MonthOfEndDay(this DateTime date)
        {
            return date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1).GetDayEnd();
        }
        /// <summary>
        /// 季度开始
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime SeasonOfFirstDay(this DateTime date)
        {
            return DateTime.Parse(date.AddMonths(0 - ((DateTime.Now.Month - 1) % 3)).ToString("yyyy-MM-01"));
        }
        /// <summary>
        /// 季度结束
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime SeasonOfEndDay(this DateTime date)
        {
            return DateTime.Parse(date.AddMonths(3 - ((DateTime.Now.Month - 1) % 3)).ToString("yyyy-MM-01")).AddDays(-1);
        }
        #endregion

        #region DataTable[]扩展方法
        public static void Init<T>(this T[] arr) where T : new()
        {
            if (arr == null)
                return;

            var len = arr.Length;
            for (var i = 0; i < len; i++)
            {
                arr[i] = new T();
            }
        }
        #endregion

        #region TextBox 扩展方法
        /// <summary>
        /// 文本框值
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static string GetText(this TextBox tb)
        {
            return tb.Text.Process();
        }
        /// <summary>
        /// 文本框是否为空
        /// </summary>
        /// <param name="txb"></param>
        /// <returns></returns>
        public static bool IsEmpty(this TextBox txb)
        {
            return string.IsNullOrEmpty(txb.Text.Trim());
        }
        /// <summary>
        /// 文本框数值
        /// </summary>
        /// <param name="txb"></param>
        /// <returns></returns>
        public static int Number(this TextBox txt)
        {
            return txt.GetText().ToInt32();
        }
        #endregion

        #region BitArray 扩展方法
        public static byte BitArrayToByte(this BitArray bits)
        {
            if (bits.Count > 8)
                throw new ArgumentException("ConvertToByte can only work with a BitArray containing a maximum of 8 values");

            byte result = 0;

            for (byte i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    result |= (byte)(1 << i);
            }
            return result;
        }

        public static int BitArrayToInt(this BitArray bitArray)
        {
            if (bitArray.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
        #endregion

        #region TimeSpan 扩展方法
        public static string Formate(this TimeSpan ts)
        {
            var dTotalHours = ts.TotalMinutes / 60;
            dTotalHours = Math.Floor(dTotalHours);
            var iTotalHours = Math.Floor(dTotalHours).ToInt32();
            return string.Format("{0:d2}时{1:d2}分", iTotalHours, ts.Minutes);
        }
        #endregion

        #region float扩展方法
        public static string ToMoney(this float f)
        {
            return f.ToString("0.00");
        }
        #endregion

        #region Decimal扩展方法
        public static string ToMoney(this decimal money)
        {
            return money.ToString("0.00");
        }
        #endregion

        #region double扩展方法
        public static string ToMoney(this double d)
        {
            return d.ToString("0.00");
        }
        #endregion

        #region Directionary<string,string> 扩展方法
        public static string LinkUrl(this Dictionary<string, string> param)
        {
            var sb = new StringBuilder();
            foreach (var item in param)
            {
                sb.Append(item.Key + "=" + item.Value.UrlEncode() + "&");
            }
            var url = sb.ToString();
            url = url.TrimEnd('&');
            return url;
        }
        #endregion

        #region Long扩展方法
        public static DateTime ToDateTime(this long timspan)
        {
            var datetime = new DateTime(1970, 1, 1);
            datetime = TimeZone.CurrentTimeZone.ToLocalTime(datetime);
            datetime = datetime.AddSeconds(timspan);
            return datetime;
        }

        public static long ToUnix(this DateTime dt)
        {
            var datetime = new DateTime(1970, 1, 1);
            datetime = TimeZone.CurrentTimeZone.ToLocalTime(datetime);
            var ts = (dt - datetime).TotalSeconds;
            return (long)ts;
        }
        #endregion
    }
}
