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
    }
}
