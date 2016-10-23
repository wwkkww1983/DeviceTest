using Common;
using Common.Log;
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
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public static bool OpenPort(string portName)
        {
            try
            {
                _serial = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                _serial.Open();
                _isOpen = true;
            }
            catch (Exception ex)
            {
                LogHelper.Info(portName + "串口打开失败，" + ex.Message);
            }
            return _isOpen;
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        public static void ClosePort()
        {
            _isOpen = false;
            if (_serial != null)
            {
                _serial.Close();
            }
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
