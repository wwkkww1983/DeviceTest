using Common;
using MeetingClient.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
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
                var code = "123";
                var flag = requestAPI.VerfiyAccess(code);
                sw.Stop();
                Debug.WriteLine("open door:" + flag + " " + sw.ElapsedMilliseconds);
            }
        }

        private void btnVisitor_Click(object sender, EventArgs e)
        {
            var url = "https://visitor.yowhale.com/openapi/guard/openDoor.json?{0}";
            using (MeetingHttpRequest requestAPI = new MeetingHttpRequest(url))
            {
                var sw = Stopwatch.StartNew();
                var code = "meeting://book?code=df13400d-4199-4227-9a5c-d8abc6dbc7c9";
                var flag = requestAPI.VerfiyAccess(code);
                sw.Stop();
                Debug.WriteLine("open door:" + flag + " " + sw.ElapsedMilliseconds);
            }
        }
    }
}
