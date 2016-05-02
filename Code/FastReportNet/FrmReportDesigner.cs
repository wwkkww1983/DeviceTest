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
    public partial class FrmReportDesigner : Form
    {
        DataSet FDataSet;
        public FrmReportDesigner()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
        }

        private void FrmReportDesigner_Load(object sender, EventArgs e)
        {
            FDataSet = new DataSet();

            DataTable table = new DataTable();
            table.TableName = "Employees";
            FDataSet.Tables.Add(table);

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));

            table.Rows.Add(1, "Andrew Fuller");
            table.Rows.Add(2, "Nancy Davolio");
            table.Rows.Add(3, "Margaret Peacock");

            Report report = new Report();
            report.Load(@"..\..\fs.frx");

            report.RegisterData(FDataSet, "员工信息表");


            designerControl1.Report = report;
            designerControl1.RefreshLayout();
        }
    }
}
