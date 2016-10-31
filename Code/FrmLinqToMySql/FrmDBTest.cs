using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrmLinqToMySql.EF;
using Common;
using System.Diagnostics;

namespace FrmLinqToMySql
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmDBTest : FrmBase
    {
        public FrmDBTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new db_hzcdatasourceEntities())
            {
                var count = db.t_caseinfo.Count();
                MessageBox.Show(count.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new db_hzcdatasourceEntities())
            {
                var sql = "select * from t_caseinfo";
                var list = db.Database.SqlQuery<MyCase>(sql).ToList();
                MessageBox.Show(list.Count.ToString());
                foreach (var item in list)
                {
                    Trace.WriteLine(item.Id + " " + item.CaseName + " " + item.No);
                }
            }
        }
    }

    public class MyCase
    {
        public int Id { get; set; }

        public string CaseName { get; set; }

        public string No { get; set; }
    }
}
