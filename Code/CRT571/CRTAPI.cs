using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CRT571
{
    public static class CRTAPI
    {
        const string dllpath = @"dll\CRT_571.dll";


        [DllImport(dllpath)]
        public static extern IntPtr CommOpen(string port);

        [DllImport(dllpath)]
        public static extern IntPtr CommSetting(IntPtr ptr, string settings);


        [DllImport(dllpath)]
        public static extern IntPtr CommOpenWithBaut(string port, UInt32 baudRate);


        [DllImport(dllpath)]
        public static extern int CommClose(IntPtr port);


        [DllImport(dllpath)]
        public static extern int ExecuteCommand(
            IntPtr ptr,
            byte addr,
            byte cmdcode,
            byte pmcode,
            int datalen,
            byte[] data,
            ref byte recType,
            ref byte RxStCode0,
            ref byte RxStCode1,
            ref byte RxStCode2,
            ref int RxDataLen,
            byte[] RxData);


        [DllImport(dllpath)]
        public static extern int ICCardTransmit(
            IntPtr ComHandle,
    byte TxAddr,
    byte TxCmCode,
    byte TxPmCode,
    int TxDataLen,
    byte[] TxData,
    ref byte RxReplyType,
    ref byte RxCmCode,
    ref byte RxPmCode,
    ref byte RxStCode0,
    ref byte RxStCode1,
    ref byte RxStCode2,
    ref int RxDataLen,
    byte[] RxData);
    }
}
