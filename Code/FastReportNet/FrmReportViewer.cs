using Common;
using FastReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastReportNet
{
    public partial class FrmReportViewer : Form
    {
        public FrmReportViewer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmReportViewer_Load(object sender, EventArgs e)
        {
            var report  = new Report();

            report.Load(@"..\..\fs.frx");

            report.Preview = previewControl1;

            report.Prepare();
            report.ShowPrepared();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            previewControl1.Print();
        }
    }
}
