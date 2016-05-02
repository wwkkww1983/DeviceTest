using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace GateTest.Visitor
{
    public class GateService : IDisposable
    {
        private SerialPort comm = new SerialPort();

        public GateService()
        {
        }

        public bool Open(string port)
        {
            comm.PortName = port;
            comm.BaudRate = 38400;
            comm.DataBits = 8;
            comm.StopBits = StopBits.One;
            comm.Parity = Parity.None;
            try
            {
                comm.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void AutoOpenDoor()
        {
            GateCommon db = new GateCommon();
            SetHeader(ref db, 0x21);
            byte[] buffer = ObjectToArray(db);
            //进入指令（REntry）
            SendData(buffer);
            Thread.Sleep(200);
            SetHeader(ref db, 0x30);
            //移卡指令(CardRemoved)
            buffer = ObjectToArray(db);
            SendData(buffer);
        }

        private void SetHeader(ref GateCommon db, byte key)
        {
            db.SFD = 0x02;
            db.DA = 0x02;
            db.SA = 0x01;
            db.Len = 0x04;
            db.group = 0x51;
            db.key = key;
        }

        private byte[] ObjectToArray(object db)
        {
            var len = Marshal.SizeOf(db.GetType());
            //+2，CRC长度
            byte[] buffer = new byte[len + 2];
            IntPtr ptr = Marshal.AllocHGlobal(len);
            try
            {
                Marshal.StructureToPtr(db, ptr, true);
                Marshal.Copy(ptr, buffer, 0, len);
            }
            finally
            {
                //释放内存
                Marshal.FreeHGlobal(ptr);
            }
            //计算CRC
            byte crcLow = 0, crcHi = 0;
            CRC.CRC16(buffer, (byte)len, ref crcLow, ref crcHi);
            byte[] crc = { crcLow, crcHi };
            Array.Copy(crc, 0, buffer, len, crc.Length);
            return buffer;
        }

        private void SendData(byte[] buffer)
        {
            Loger.Log.Log(buffer.ToHex());
            if (comm.IsOpen)
            {
                comm.Write(buffer, 0, buffer.Length);
            }
        }

        public void Dispose()
        {
            if (comm.IsOpen)
            {
                comm.Close();
            }
        }
    }
}
