using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FastReportNet
{
    public partial class FrmReport : FrmBase
    {
        public FrmReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmReportDesigner designer = new FrmReportDesigner();
            designer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmReportViewer viewer = new FrmReportViewer();
            viewer.Show();
        }
    }
}
