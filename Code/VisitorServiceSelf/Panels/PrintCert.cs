using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisitorServiceSelf.Panels
{
    /// <summary>
    /// 打印二维码或控制出卡机
    /// </summary>
    public partial class PrintCert : PanelBase
    {
        public PrintCert()
        {
            InitializeComponent();
        }

        private void PrintCert_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                Invoke(new MethodInvoker(() =>
                {
                    Controller.Start();
                }));
            });
        }
    }
}
