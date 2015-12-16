using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodePrint
{
    public class HengeslterSerialPrinter
    {
        SerialPort comPort = null;

        public HengeslterSerialPrinter(string com)
        {
            comPort = new SerialPort(com, 115200, Parity.None, 8, StopBits.One);
        }

        public bool Open()
        {
            try
            {
                comPort.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Write(byte[] buffer)
        {
            if (null == buffer)
                return;

            if (comPort.IsOpen)
            {
                comPort.Write(buffer, 0, buffer.Length);
            }
        }

        public void Close()
        {
            if(comPort.IsOpen)
            {
                comPort.Close();
            }
        }
    }
}
