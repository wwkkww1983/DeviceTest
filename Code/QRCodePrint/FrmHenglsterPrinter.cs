using Common;
using Exo_ApiWrapper_NET;
using QRCodePrint.printdll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        //private ExoApiWrapper api = new ExoApiWrapper();
        public FrmHenglsterPrinter()
        {
            InitializeComponent();
        }

        private void FrmHenglsterPrinter_Load(object sender, EventArgs e)
        {
        }

        private void btnPrinterEnum_Click(object sender, EventArgs e)
        {
            //_printerEnum = api.Exo_Api_Pe_PrinterEnumStart();
            //if (_printerEnum == IntPtr.Zero)
            //{
            //    CMessageBox.Show("查找打印机失败!");
            //    return;
            //}

            _hPrinterEnum = Henglster.Exo_Api_Pe_PrinterEnumStart();
            if (_hPrinterEnum == IntPtr.Zero)
            {
                CMessageBox.Show("查找打印机失败!");
                return;
            }

            string lpszPrinter = null;
            for (lpszPrinter = Henglster.Exo_Api_Pe_PrinterEnum(_hPrinterEnum, true)
; lpszPrinter != null
; lpszPrinter = Henglster.Exo_Api_Pe_PrinterEnum(_hPrinterEnum, false))
            {
                cmbPrinters.Items.Add(lpszPrinter);
            }
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
    }
}
