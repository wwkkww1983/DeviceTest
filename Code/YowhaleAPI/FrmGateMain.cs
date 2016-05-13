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
using System.Web;
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
                var sw = Stopwatch.StartNew();
                var code = "meeting://book?code=8c3cff41-f476-4c9c-8126-e9a6163f564b";
                var flag = requestAPI.VerfiyAccess(code);
                sw.Stop();
                Debug.WriteLine("open door:" + flag);
                label1.Text = "API call:" + sw.ElapsedMilliseconds + " " + (flag ? "true" : "false");
            }
        }

    }
}
