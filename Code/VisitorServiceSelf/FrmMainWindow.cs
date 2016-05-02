using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisitorServiceSelf.Core;
using VisitorServiceSelf.Panels;

namespace VisitorServiceSelf
{
    public partial class FrmMainWindow : Form
    {
        private Controllers controller = null;
        public FrmMainWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            DateTimeService.Start(label1);
            controller = Controllers.Instance;
            controller.WindowChange += controller_WindowChange;
            controller.RegistrationPanel(new WelCome());
            controller.RegistrationPanel(new ReadDocument());
            controller.RegistrationPanel(new Responses());
            controller.RegistrationPanel(new PrintCert());
            controller.Start();
            base.OnShown(e);
        }

        private void controller_WindowChange(PanelBase panel)
        {
            panel2.Controls.Clear();
            panel.Dock = DockStyle.Fill;
            panel2.Controls.Add(panel);
            panel.Work();
        }

        private void FrmMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DateTimeService.Stop();
        }
    }
}
