using Common;
using Exo_ApiWrapper_NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCodePrint
{
    public partial class FrmHenglsterPrinter : FrmBase
    {
        private IntPtr _printerEnum = IntPtr.Zero;
        private ExoApiWrapper api = new ExoApiWrapper();
        public FrmHenglsterPrinter()
        {
            InitializeComponent();
        }

        private void FrmHenglsterPrinter_Load(object sender, EventArgs e)
        {

        }

        private void btnPrinterEnum_Click(object sender, EventArgs e)
        {

            _printerEnum = api.Exo_Api_Pe_PrinterEnumStart();
            if (_printerEnum == IntPtr.Zero)
            {
                CMessageBox.Show("查找打印机失败!");
                return;
            }
        }
    }
}
