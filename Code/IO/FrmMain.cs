using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TrafficBankGateControl;

namespace IO
{
    public partial class FrmMain : FrmBase
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (IPCAPI.F75111_Init() == 0)
            {
                MessageBox.Show("IO板初始化失败！");
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            byte nValue = 0;

            if (DO1.Checked == true)
                nValue |= 0x01;
            if (DO2.Checked == true)
                nValue |= 0x02;
            if (DO3.Checked == true)
                nValue |= 0x04;
            if (DO4.Checked == true)
                nValue |= 0x08;

            if (DO5.Checked == true)
                nValue |= 0x10;
            if (DO6.Checked == true)
                nValue |= 0x20;
            if (DO7.Checked == true)
                nValue |= 0x40;
            if (DO8.Checked == true)
                nValue |= 0x80;

            //输出
            IPCAPI.F75111_SetDigitalOutput(nValue);
            Thread.Sleep(100);
            //充值
            IPCAPI.F75111_SetDigitalOutput(0);
        }

        private void ckbAll_O_CheckedChanged(object sender, EventArgs e)
        {
            var dos = groupBox1.Controls.OfType<CheckBox>();
            foreach (var ckb in dos)
            {
                ckb.Checked = ckbAll_O.Checked;
            }
        }
    }
}
