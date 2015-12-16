using Common;
using Exo_ApiWrapper_NET;
using QRCodePrint.printdll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCodePrint
{
    public partial class FrmHenglsterPrinter : FrmBase
    {
        private IntPtr _hPrinterEnum = IntPtr.Zero;
        private ExoApiWrapper api = new ExoApiWrapper();
        public FrmHenglsterPrinter()
        {
            InitializeComponent();
        }

        private void FrmHenglsterPrinter_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = SerialPort.GetPortNames();
        }

        private void btnPrinterEnum_Click(object sender, EventArgs e)
        {
            //_hPrinterEnum = api.Exo_Api_Pe_PrinterEnumStart();
            //if (_hPrinterEnum == IntPtr.Zero)
            //{
            //    CMessageBox.Show("查找打印机失败!");
            //    return;
            //}

            _hPrinterEnum = Henglster.Exo_Api_Pe_PrinterEnumStart();
            //if (_hPrinterEnum == IntPtr.Zero)
            //{
            //    CMessageBox.Show("查找打印机失败!");
            //    return;
            //}

//            string lpszPrinter = null;
//            for (lpszPrinter = Henglster.Exo_Api_Pe_PrinterEnum(_hPrinterEnum, true)
//; lpszPrinter != null
//; lpszPrinter = Henglster.Exo_Api_Pe_PrinterEnum(_hPrinterEnum, false))
//            {
//                cmbPrinters.Items.Add(lpszPrinter);
//            }
        }

        private void btnOpenPrinter_Click(object sender, EventArgs e)
        {
            IntPtr ptr = Henglster.Exo_Api_Pio_PrinterOpen("cba", Henglster.D_EXO_API_PIO_OPT_NONE, 10000);
            if (ptr == IntPtr.Zero)
            {
                CMessageBox.Show("打开失败");
                return;
            }
        }

        /// <summary>
        /// 条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr ptr = Henglster.Exo_Api_Pio_PrinterOpen("cba", Henglster.D_EXO_API_PIO_OPT_NONE, 10000);
            if (ptr == IntPtr.Zero)
            {
                CMessageBox.Show("打开失败");
                return;
            }
        }

        /// <summary>
        /// 二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            IntPtr ptr = Henglster.Exo_Api_Pio_PrinterOpen("cba", Henglster.D_EXO_API_PIO_OPT_NONE, 10000);
            if (ptr == IntPtr.Zero)
            {
                CMessageBox.Show("打开失败");
                return;
            }

            //n1 Style
            //0 PDF417
            //1 Datamatrix
            //2 QR Code
            byte n1 = 0x02;
            byte n2 = 0x00;
            //Barcode Type Range
            //PDF417 0 (least error correction) … 8
            //Datamatrix 0 (least error correction) … 29
            //QR Code 0 (least error correction; “L”), 1 (“M”), 2 (“Q”), 3 (“H”)
            byte n3 = 0x00;
            byte[] buffer = { 0x1B, 0xF0, 0x09, 0x07, n1, n2, n3 };
        }

        /// <summary>
        /// 字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            IntPtr ptr = Henglster.Exo_Api_Pio_PrinterOpen("cba", Henglster.D_EXO_API_PIO_OPT_NONE, 10000);
            if (ptr == IntPtr.Zero)
            {
                CMessageBox.Show("打开失败");
                return;
            }
        }

        SerialPort port = null;
        private void button4_Click(object sender, EventArgs e)
        {
            port = new SerialPort(comboBox1.Text, 115200, Parity.None, 8, StopBits.One);
            try
            {
                port.Open();
            }
            catch
            {
                MessageBox.Show("串口打开失败");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] buffer = { 0x1B, 0x40 };
            byte[] cut = { 0x1b, 0xf0, 0x06, 0x01, 0x02 };

            byte[] context1 = Encoding.Default.GetBytes("姓名：杨绍杰");
            byte[] context2 = Encoding.Default.GetBytes("手机：13760129591");
            byte[] context3 = Encoding.Default.GetBytes("日期：" + DateTime.Now.ToString());
            byte[] context4 = Encoding.Default.GetBytes("证件：410726198101103012");

            List<byte> total = new List<byte>();
            total.AddRange(buffer.ToList());
            for (var i = 0; i < 2; i++)
                total.Add(0x0a);

            //行间距
            total.AddRange(new byte[3] { 0x1B, 0x41, 20 });
            //下划线
            
            total.AddRange(context1.ToList());
            total.Add(0x0A);
            total.AddRange(new byte[3] { 0x1B, 0x2D, 2 });
            total.AddRange(context2.ToList());
            total.Add(0x0A);
            total.AddRange(context3.ToList());
            total.Add(0x0A);

            total.AddRange(context4.ToArray());

            total.AddRange(cut.ToList());
            var send = total.ToArray();
            Print(send);
            if (port != null)
            {
                if (port.IsOpen)
                {
                    port.Write(send, 0, send.Length);
                }
            }
        }

        private void Print(byte[] buffer)
        {
            var sb = new StringBuilder();
            foreach (var b in buffer)
            {
                sb.Append(b + " ");
            }
            textBox5.Text = sb.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] buffer = { 0x1B, 0x40 };
            byte[] cut = { 0x1b, 0xf0, 0x06, 0x01, 0x02 };

            List<byte> total = new List<byte>();
            total.AddRange(buffer.ToList());

            var str = "0123456789";
            foreach (var c in str)
            {
                total.Add((byte)c);
                total.Add(0x0a);
            }
            total.AddRange(cut.ToList());
            var send = total.ToArray();
            Print(send);
            if (port != null)
            {
                if (port.IsOpen)
                {
                    port.Write(send, 0, send.Length);
                    textBox5.Text = ("打印" + Environment.NewLine);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var str = "1B 40 1B 45 00 1B 2D 00 1B 61 01 1B 21 12 1B 64 01 B1 B1 BE A9 B4 F3 BE E7 D4 BA CD A3 B3 B5 B3 A1 1B 64 01 1B 21 02 1B 64 01 1D 68 80 1D 77 01 1B F0 08 01 05 1D 6B 49 08 67 32 33 33 39 35 35 35 1B 64 02 1B 61 00 1D 4C 14 00 C8 EB B3 A1 3A 32 30 31 32 2D 30 38 2D 33 31 20 31 30 3A 35 33 1B 64 01 CD A8 B5 C0 3A D2 BB BA C5 C8 EB BF DA 1B 64 01 B3 A7 C9 CC A3 BA C9 EE DB DA CA D0 BC AA CC A9 CD FE BF C6 BC BC 1B 64 01 1B 64 01 1D 4C 00 00 1B 61 01 A1 F8 1B 64 01 1B 61 01 1B 21 12 CF C8 B5 BD CA D5 B7 D1 B4 A6 BD BB B7 D1 A3 AC D4 D9 C8 A1 B3 B5 B3 F6 B3 A1 1B 64 01 1B 21 02 1B 64 01 2D 2D 2D 2D 2D 2D 2D 2D 2D 2D 2D 2D 2D 2D 2D 2D 2D 2D 2D 2D 1B 64 01 B3 F6 B3 A1 C6 BE D6 A4 2C C7 EB CE F0 D5 DB CB F0 21 1B 64 01 B3 F6 BF DA BB D8 CA D5 A3 BA CA D6 CE D5 B4 CB B4 A6 A3 AC D5 FD C3 E6 B3 AF C9 CF C8 FB BF A8 1B 64 01 1B 64 01 1B F0 06 01 02".Split(' ');
            List<byte> list = new List<byte>();
            foreach (var s in str)
            {
                list.Add(Convert.ToByte(s, 16));
            }
            var send = list.ToArray();
            Print(send);
            if (port != null)
            {
                if (port.IsOpen)
                {
                    port.Write(send, 0, send.Length);
                    textBox5.Text = ("打印" + Environment.NewLine);
                }
            }
        }
    }
}
