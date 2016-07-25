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
    /// Home test
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

        private void btnMeeting_Click(object sender, EventArgs e)
        {
            var url = "https://meeting.yowhale.com/openapi/guard/openDoor.json?{0}";
            using (MeetingHttpRequest requestAPI = new MeetingHttpRequest(url))
            {
                var sw = Stopwatch.StartNew();
                var code = "meeting://book?code=8c3cff41-f476-4c9c-8126-e9a6163f564b";
                var flag = requestAPI.VerfiyAccess(code);
                sw.Stop();
                Debug.WriteLine("open door:" + flag);
                label1.Text = "API call:" + sw.ElapsedMilliseconds + " " + (flag ? "true" : "false");
            }
        }

        private void btnVisitor_Click(object sender, EventArgs e)
        {
            var url = "https://visitor.yowhale.com/openapi/guard/openDoor.json?{0}";
            using (MeetingHttpRequest requestAPI = new MeetingHttpRequest(url))
            {
                var sw = Stopwatch.StartNew();
                var code = "visitor://book?code=2f2e4c9e-6cd8-402e-a95c-e08f4006894e";
                code = "visitor://book?code=7f88fc92-e3ed-40d2-b32a-01e0074df113";
                var flag = requestAPI.VerfiyAccess(code);
                sw.Stop();
                Debug.WriteLine("open door:" + flag);
                label1.Text = "API call:" + sw.ElapsedMilliseconds + " " + (flag ? "true" : "false");
            }
        }
    }
}
