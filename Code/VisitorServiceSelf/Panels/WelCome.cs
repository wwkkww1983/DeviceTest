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
    /// 引导欢迎
    /// </summary>
    public partial class WelCome : PanelBase
    {
        public WelCome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pictureBoxAdvert1.Stop();
            Controller.Next();
        }

        private void WelCome_Load(object sender, EventArgs e)
        {
            
        }

        public override void Work()
        {
            pictureBoxAdvert1.Start();
        }
    }
}
