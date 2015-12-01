using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QRCode
{
    public class ED
    {
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="codeName">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string EncodeBase64(Encoding encode, string source)
        {
            string enstring = "";
            byte[] bytes = encode.GetBytes(source);
            try
            {
                enstring = Convert.ToBase64String(bytes);
            }
            catch
            {
                enstring = source;
            }
            return enstring;
        }

        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string EncodeBase64(string source)
        {
            return EncodeBase64(Encoding.UTF8, source);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="codeName">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(Encoding encode, string result)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(string result)
        {
            return DecodeBase64(Encoding.UTF8, result);
        }
    }


    public class Person
    {
        //必须为4位长度的密钥
        static string encryptKey = "Yang";    //定义密钥  
        /// <summary> /// 加密字符串   
        /// </summary>  
        /// <param name="str">要加密的字符串</param>  
        /// <returns>加密后的字符串</returns>  
        public static string Encrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   
            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    
            byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串  
            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      
            //使用内存流实例化加密流对象   
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);  //向加密流中写入数据      
            CStream.FlushFinalBlock();              //释放加密流      
            return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串  
        }

        /// <summary>  
        /// 解密字符串   
        /// </summary>  
        /// <param name="str">要解密的字符串</param>  
        /// <returns>解密后的字符串</returns>  
        public static string Decrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象    
            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    
            byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串  

            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      
            //使用内存流实例化解密流对象       
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);      //向解密流中写入数据     

            CStream.FlushFinalBlock();               //释放解密流      
            return Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串  
        } 
    }
}
