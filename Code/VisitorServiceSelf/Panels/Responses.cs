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
using Common;

namespace VisitorServiceSelf.Panels
{
    /// <summary>
    /// 填写被访人
    /// </summary>
    public partial class Responses : PanelBase
    {
        public Responses()
        {
            InitializeComponent();
        }

        private void Responses_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            textBox1.Text = "ysj";
            ActiveControl = textBox1;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                CMessageBox.Show("非空");
                ActiveControl = textBox1;
                return;
            }
            //if (string.IsNullOrEmpty(textBox2.Text))
            //{
            //    CMessageBox.Show("非空");
            //    ActiveControl = textBox2;
            //    return;
            //}
            Controller.Next();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Controller.Start();
        }
    }
}
