using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HitachiLift
{
    public static class Funs
    {
        /// <summary>
        /// 从帧头开始
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte GetXOR(List<byte> data)
        {
            byte val = 0;
            foreach (var b in data)
            {
                val ^= b;
            }
            return val;
        }

        public static byte[] IntToBytes(int val)
        {
            //GetBytes获取的低字节在前
            var bytes = BitConverter.GetBytes(val);
            Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] InitArray(int length, byte val)
        {
            byte[] array = new byte[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = val;
            }
            return array;
        }
    }
}
