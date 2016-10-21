using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR104
{
    /// <summary>
    /// SR控制器
    /// </summary>
    public class SRController
    {
        private static bool _isOpen = false;
        private static SerialPort _serial = null;

        public static bool Open(string portName)
        {
            try
            {
                _serial = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                _serial.Open();
                _isOpen = true;
            }
            catch (Exception)
            {
            }
            return _isOpen;
        }
        /// <summary>
        /// 吸合
        /// </summary>
        /// <param name="index"></param>
        public static void Close(int index)
        {
            BitArray ba = new BitArray(8);
            if (index == 1)
                ba[0] = true;

            if (index == 2)
                ba[1] = true;

            ba[4] = true;

            byte[] data = new byte[1];
            ba.CopyTo(data, 0);
            if (_isOpen)
            {
                _serial.Write(data, 0, data.Length);
            }
        }
        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="index"></param>
        public static void Free(int index)
        {
            BitArray ba = new BitArray(8);
            if (index == 1)
                ba[0] = true;

            if (index == 2)
                ba[1] = true;

            ba[5] = true;

            byte[] data = new byte[1];
            ba.CopyTo(data, 0);
            if (_isOpen)
            {
                _serial.Write(data, 0, data.Length);
            }
        }
    }

    public enum SR_Order
    {

    }
}
