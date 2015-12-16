using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using Common;

namespace QRCodePrint
{
    public partial class FrmHengstler : FrmBase
    {
        const string init = "1B 40"; //软件初始化
        const string fontbold = "1B 45 00"; //粗体
        const string underline = "1B 2D 00"; //下划线
        const string ht = "1B 61 01"; //水平对齐  0 left 1 center 2 right
        const string characterSize = "1B 21 12"; //字体大小
        const string line1 = "1B 64 01"; //打印并前进N行
        const string line2 = "1B 64 02"; //打印并前进N行
        const string line3 = "1B 64 03"; //打印并前进N行
        const string line4 = "1B 64 04"; //打印并前进N行
        const string leftspace = "1D 4C"; //左侧空白量 nL nH (nL+nH*256)*0.125毫米

        const string barcodeH = "1D 68 80";  //条码高
        const string barcodeW = "1D 77 01";  //条码宽
        const string barcodesetting1 = "1B F0 08 01 05"; //条码设置
        const string barcodecmd = "1D 6B 49 0B 67"; //code128 8个长度 0x67子集A


        const string barcodesetting2 = "1B F0 09 07 02 02 00 01 00 00 FF"; //二维码设置
        const string barcodecmd2 = "1B F0 0A 0A"; //二维码指令 10个长度

        const string cutpaper = "1B F0 06 01 02"; //切纸

        HengeslterSerialPrinter printer = null;
        public FrmHengstler()
        {
            InitializeComponent();
        }

        private void FrmHengstler_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = SerialPort.GetPortNames();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printer = new HengeslterSerialPrinter(comboBox1.Text);
            if (printer.Open())
                button4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<byte> data = new List<byte>();
            data.AddRange(init.ToByte());
            data.AddRange(fontbold.ToByte());
            data.AddRange(underline.ToByte());
            data.AddRange(ht.ToByte());
            data.AddRange(characterSize.ToByte());
            data.AddRange(line1.ToByte());

            data.AddRange("小票标题".ToGb2312());
            data.AddRange(line4.ToByte());
            data.AddRange(cutpaper.ToByte());

            printer.Write(data.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<byte> data = new List<byte>();
            data.AddRange(init.ToByte());
            data.AddRange(fontbold.ToByte());
            data.AddRange(underline.ToByte());
            data.AddRange(ht.ToByte());
            data.AddRange(characterSize.ToByte());
            data.AddRange(line1.ToByte());

            //行高、宽
            data.AddRange(barcodeH.ToByte());
            data.AddRange(barcodeW.ToByte());
            data.AddRange(barcodesetting1.ToByte());
            data.AddRange(barcodecmd.ToByte());
            var code = "0123456789";
            foreach (var c in code)
            {
                data.Add((byte)c);
            }
            data.AddRange(line2.ToByte());
            data.AddRange(cutpaper.ToByte());

            printer.Write(data.ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<byte> data = new List<byte>();
            data.AddRange(init.ToByte());
            data.AddRange(fontbold.ToByte());
            data.AddRange(underline.ToByte());
            data.AddRange(ht.ToByte());
            data.AddRange(characterSize.ToByte());
            data.AddRange(line1.ToByte());

            data.AddRange(barcodeH.ToByte());
            data.AddRange(barcodesetting2.ToByte());
            data.AddRange(barcodecmd2.ToByte());
            var code = "0123456789";
            foreach (var c in code)
            {
                data.Add((byte)c);
            }
            data.AddRange(line2.ToByte());
            data.AddRange(cutpaper.ToByte());

            printer.Write(data.ToArray());
        }
    }

    public static class Ext
    {
        public static byte[] ToByte(this string str)
        {
            return str.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray();
        }

        public static byte[] ToGb2312(this string str)
        {
            return Encoding.Default.GetBytes(str);
        }
    }
}
