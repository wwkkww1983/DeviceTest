using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetingClient.Core
{
    class Config
    {
        private static string app = "";
        private static string key = "";
        private static string input_charset = "";
        private static string sign_type = "";

        public static string termId = "2";
        public static string Partner = "";

        static Config()
        {
            app = "guard";
            //交易安全检验码，由数字和字母组成的32位字符串
            key = "guard";


            //字符编码格式 目前支持 gbk 或 utf-8
            input_charset = "utf-8";

            //签名方式，选择项：RSA、DSA、MD5
            sign_type = "MD5";
        }

        public static string App
        {
            get { return app; }
            set { app = value; }
        }

        /// <summary>
        /// 获取或设交易安全校验码
        /// </summary>
        public static string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// 获取字符编码格式
        /// </summary>
        public static string Input_charset
        {
            get { return input_charset; }
        }

        /// <summary>
        /// 获取签名方式
        /// </summary>
        public static string Sign_type
        {
            get { return sign_type; }
        }
    }
}
