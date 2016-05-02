using Common;
using GateTest.Visitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GateTest
{
    public partial class FrmGateTest : FrmBase, ILog
    {
        GateService gateService = null;
        public FrmGateTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            btnOpenGate.Enabled = false;
            Loger.Log = this;

            var ports = SerialPort.GetPortNames();
            cmbPorts.DataSource = ports;
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            if (cmbPorts.Items.Count == 0)
            {
                Log("未找到计算机串口！");
                return;
            }

            string port = cmbPorts.Text;
            gateService = new GateService();
            bool flag = gateService.Open(port);
            if (flag)
            {
                Log("串口打开成功：" + port);
                btnOpenPort.Enabled = false;
                btnOpenGate.Enabled = true;
            }
            else
            {
                Log("串口打开失败：" + port);
            }
        }

        private void btnOpenGate_Click(object sender, EventArgs e)
        {
            if (gateService == null)
                return;

            gateService.AutoOpenDoor();
        }

        public void Log(object obj)
        {
            rtb.AppendText(obj.ToString() + Environment.NewLine);
        }

        private void Message(object obj)
        {
            MessageBox.Show(obj.ToString(), "提示");
        }

        private void FrmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gateService != null)
            {
                gateService.Dispose();
            }
        }
    }

    public static class ClassExtensions
    {
        public static string ToHex(this byte[] buffer)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var b in buffer)
            {
                sb.Append(b.ToString("X2") + " ");
            }
            return sb.ToString();
        }
    }

    public interface ILog
    {
        void Log(object obj);
    }

    public class Loger
    {
        public static ILog Log { get; set; }
    }
}
