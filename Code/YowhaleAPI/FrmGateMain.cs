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
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var url = "https://meeting.yowhale.com/openapi/guard/openDoor.json?{0}";
                    using (MeetingHttpRequest requestAPI = new MeetingHttpRequest(url))
                    {
                        var sw = Stopwatch.StartNew();
                        var code = "https://visitor.shenjing.com/openapi/guard/openDoor.json?app=guard&content=visitor%3A%2F%2Farrive%3Fcode%3Ddf18392b-9b7e-4d73-a516-7d56fe67d6b8&guard=2&sign=46aab8e44e151fbc3ebf2b94a09c0c01&sign_type=MD5";
                        var flag = requestAPI.VerfiyAccess(code);
                        sw.Stop();
                        Debug.WriteLine("open door:" + flag + " " + sw.ElapsedMilliseconds);
                        //label1.Text = "API call:" + sw.ElapsedMilliseconds + " " + (flag ? "true" : "false");
                    }
                    Thread.Sleep(1000);
                }
            });
        }

        private void btnVisitor_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var url = "https://visitor.yowhale.com/openapi/guard/openDoor.json?{0}";
                    using (MeetingHttpRequest requestAPI = new MeetingHttpRequest(url))
                    {
                        var sw = Stopwatch.StartNew();
                        var code = "https://visitor.shenjing.com/openapi/guard/openDoor.json?app=guard&content=visitor%3A%2F%2Farrive%3Fcode%3Ddf18392b-9b7e-4d73-a516-7d56fe67d6b8&guard=2&sign=46aab8e44e151fbc3ebf2b94a09c0c01&sign_type=MD5";
                        var flag = requestAPI.VerfiyAccess(code);
                        sw.Stop();
                        //var request = WebRequest.Create(code);
                        //var response = request.GetResponse();
                        //var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        //var content = streamReader.ReadToEnd();
                        //streamReader.Close();
                        //JavaScriptSerializer java = new JavaScriptSerializer();
                        //var jsonObject = java.Deserialize<ErrorModel>(content);
                        //var flag = jsonObject.content;
                        Debug.WriteLine("open door:" + flag + " " + sw.ElapsedMilliseconds);
                    }
                    Thread.Sleep(1000);
                    break;
                }
            });
        }
    }
}
