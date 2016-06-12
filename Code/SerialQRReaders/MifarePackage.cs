using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialQRReaders
{
    class MifarePackage
    {
        //messagetype   0 1
        //datalen       4 4
        //slot Id       5 1
        //seq           6 1
        //bwi           7 1
        //levelparameter8 2
        private const string prefix_mifare = "6fh {0} 00h 00h 00h 00h 00h 00h 00h 00h ";


        private static byte[] CompositeMifareData(string str)
        {
            var len = str.Split(' ').Length;
            str = string.Format(prefix_mifare, len) + str;
            str = str.Replace("h", "").Trim();
            var arr = str.Split(' ');
            var buffer = arr.Select(s=> Convert.ToByte(str, 16)).ToArray();
            return buffer;
        }


        public static byte[] Data(string str)
        {
            var data = CompositeMifareData(str);
            return data;
        }
    }
}
