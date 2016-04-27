using Common;
using MeetingClient.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MeetingClient
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmGateMain : FrmBase
    {
        public FrmGateMain()
        {
            InitializeComponent();
        }

        private void FrmGateMain_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MeetingHttpRequest requestAPI = new MeetingHttpRequest())
            {
                var code = "meeting://book?code=c4bc7af4-618e-4aed-a014-fd089b2b3106";
                var flag = requestAPI.VerfiyAccess(code);
                Debug.WriteLine("open door:" + flag);
                label1.Text = (flag ? "true" : "false");
            }
        }

    }
}
