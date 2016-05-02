using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRT571
{
    public partial class FrmTestMain : FrmBase
    {
        bool isOpen = false;
        IntPtr ptr = IntPtr.Zero;
        const string portName = "COM1";
        const UInt32 baudRate = 38400;
        public FrmTestMain()
        {
            InitializeComponent();
        }

        private void Log(object obj)
        {
            listBox1.Items.Insert(0, obj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ptr = CRTAPI.CommOpenWithBaut(portName, baudRate);
            if (ptr == IntPtr.Zero)
            {
                CMessageBox.Show("串口打开失败");
                return;
            }
            isOpen = true;
            Log("串口打开成功");
        }

        private void FrmTestMain_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isOpen)
            {
                CRTAPI.CommClose(ptr);
                isOpen = false;
                ptr = IntPtr.Zero;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte ICRWaddr = 0;
            byte CmCode = 0;
            byte PmCode = 0;
            int CmDataLen = 0;
            byte[] CmData = new byte[1024];

            byte repleyType = 0;
            byte St2 = 0;
            byte St1 = 0;
            byte St0 = 0;
            int ReDataLen = 0;
            byte[] ReData = new byte[1024];

            CmCode = 0x30;
            PmCode = 0x33;
            CmDataLen = 0;

            int rc = CRTAPI.ExecuteCommand(ptr,
                ICRWaddr,
                CmCode,
                PmCode,
                CmDataLen,
                CmData,
                ref repleyType, ref St0, ref St1, ref St2, ref ReDataLen, ReData);

            if (rc != 0)
            {
                Log("通讯异常");
                return;
            }
            if (repleyType == 0x50)
            {
                Log("通讯正常");
            }
        }
    }
}
