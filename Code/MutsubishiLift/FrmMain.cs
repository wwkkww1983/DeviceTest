using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace MutsubishiLift
{
    /// <summary>
    /// 三菱电梯 派梯协议
    /// </summary>
    public partial class FrmMain : FrmBase
    {
        byte cmd = 0x00;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //port 60173
        }

        //心跳
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = 0x11;
            List<byte> data = new List<byte>();
            data.Add(0x04);
            data.Add((byte)'A');
            data.Add(0x00);
            data.Add(0x00);
            data.Add(cmd);
            data.Add(0x00);
            data.Add(0x00);
            data.Add(0x00);

            var arr = data.ToArray();
            Debug.WriteLine(arr.Length);
        }
    }
}
