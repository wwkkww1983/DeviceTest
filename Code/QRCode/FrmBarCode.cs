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

namespace QRCode
{
    public partial class FrmBarCode : FrmBase
    {
        public FrmBarCode()
        {
            InitializeComponent();
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            MultiFormatWriter mutiWriter = new MultiFormatWriter();
            BitMatrix bm = mutiWriter.encode("123456789", BarcodeFormat.CODE_39, 200, 50);
            Bitmap img = new BarcodeWriter().Write(bm);
            //img.Save("d:/1.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

            pictureBox1.Image = img;
        }
    }
}
