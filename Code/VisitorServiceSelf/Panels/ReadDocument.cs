using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisitorServiceSelf.Core;

namespace VisitorServiceSelf.Panels
{
    /// <summary>
    /// 识别证件
    /// </summary>
    public partial class ReadDocument : PanelBase
    {
        public ReadDocument()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Controller.Next();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Controller.Start();
        }

        private void CheckIdNumber()
        {
            string IdNumber = "";

        }
    }
}
