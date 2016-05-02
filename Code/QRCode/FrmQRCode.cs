using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace QRCode
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmQRCode : FrmBase
    {
        public FrmQRCode()
        {
            InitializeComponent();
            //txtEncodeInfo.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
            txtEncodeInfo.Text = "12345678ABCDEFG";
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            var txt = txtEncodeInfo.Text;
            if (string.IsNullOrEmpty(txt))
                return;

            if (ckbEncode.Checked)
            {
                txt = Person.Encrypt(txt);
            }

            var size = 300;
            BarcodeWriter writer = new BarcodeWriter();
            QrCodeEncodingOptions qr = new QrCodeEncodingOptions()
            {
                CharacterSet = "UTF-8",
                ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.H,
                Height = size,
                Width = size
            };
            writer.Options = qr;
            writer.Format = BarcodeFormat.QR_CODE;

            //txt += "|" + DateTime.Now.Ticks;
            Bitmap map = writer.Write(txt);
            if (ckbLogo.Checked)
            {
                using (Graphics g = Graphics.FromImage(map))
                {
                    Image logo = Image.FromFile("logo.jpg");
                    Graphics temp = Graphics.FromImage(logo);
                    var w = 30;
                    var x = (map.Width - w) / 2;
                    var y = (map.Height - w) / 2;
                    var rect = new Rectangle(x, y, w, w);
                    g.FillRectangle(Brushes.Red, rect);
                    g.DrawImage(logo, x + 2, y + 2, w - 4, w - 4);
                }
            }
            pictureBox1.BackColor = Color.White;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.Image = map;
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            IBarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBox1.Image);
            if (result != null)
            {
                var txt = result.Text;
                if (ckbEncode.Checked)
                {
                    //txt = ED.DecodeBase64(txt);
                    txtSourceStr.Text = txt;
                    txt = Person.Decrypt(txt);
                }
                txtDecodeInfo.Text = txt;
            }
        }

        private void btnQRImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = ofd.FileName;
                }
            }
        }

        private void FrmQRCode_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var g = e.Graphics;
            g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, 200, 200));

            g.DrawString("    姓名：张三", new Font("宋体", 20f), Brushes.Black, new PointF(230, 20));
            g.DrawString("    电话：13760129591", new Font("宋体", 20f), Brushes.Black, new PointF(230, 70));
            //g.DrawString("证件号码：410726198101103012", new Font("宋体", 20f), Brushes.Black, new PointF(230, 80));
            g.DrawString("访问时间：09:00-14:00", new Font("宋体", 20f), Brushes.Black, new PointF(230, 120));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //printDocument1.Print();

            printDialog1.Document = printDocument1;

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
