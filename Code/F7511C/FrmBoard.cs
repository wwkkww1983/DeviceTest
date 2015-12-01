using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace F7511C
{
    public partial class FrmBoard : FrmBase
    {
        public FrmBoard()
        {
            InitializeComponent();
        }

        private void FrmBoard_Load(object sender, EventArgs e)
        {
            var ret = IPCAPI.F75111_Init();
            if (ret == 0)
            {
                CMessageBox.Show("Init F75111 Failed...");
                return;
            }
        }

        private void Read_Button_Click(object sender, EventArgs e)
        {
            this.DI1.Checked = false;
            this.DI2.Checked = false;
            this.DI3.Checked = false;
            this.DI4.Checked = false;
            this.DI5.Checked = false;
            this.DI6.Checked = false;
            this.DI7.Checked = false;
            this.DI8.Checked = false;
            byte num = (byte)IPCAPI.F75111_GetDigitalInput();
            if ((num & 0x01) > 0)
            {
                this.DI1.Checked = true;
            }
            if ((num & 0x02) > 0)
            {
                this.DI2.Checked = true;
            }
            if ((num & 0x04) > 0)
            {
                this.DI3.Checked = true;
            }
            if ((num & 0x08) > 0)
            {
                this.DI4.Checked = true;
            }
            if ((num & 0x10) > 0)
            {
                this.DI5.Checked = true;
            }
            if ((num & 0x20) > 0)
            {
                this.DI6.Checked = true;
            }
            if ((num & 0x40) > 0)
            {
                this.DI7.Checked = true;
            }
            if ((num & 0x80) > 0)
            {
                this.DI8.Checked = true;
            }
        }

        private void Write_Button_Click(object sender, EventArgs e)
        {
            byte num = 0;
            if (this.DO1.Checked)
            {
                num = (byte)(num | 0x01);
            }
            if (this.DO2.Checked)
            {
                num = (byte)(num | 0x02);
            }
            if (this.DO3.Checked)
            {
                num = (byte)(num | 0x04);
            }
            if (this.DO4.Checked)
            {
                num = (byte)(num | 0x08);
            }
            if (this.DO5.Checked)
            {
                num = (byte)(num | 0x10);
            }
            if (this.DO6.Checked)
            {
                num = (byte)(num | 0x20);
            }
            if (this.DO7.Checked)
            {
                num = (byte)(num | 0x40);
            }
            if (this.DO8.Checked)
            {
                num = (byte)(num | 0x80);
            }
            IPCAPI.F75111_SetDigitalOutput(num);
        }

        private void Enable_Button_Click(object sender, EventArgs e)
        {
            IPCAPI.F75111_SetWDTEnable(byte.Parse(WDT_Number.Text));
        }

        private void Disable_Button_Click(object sender, EventArgs e)
        {
            IPCAPI.F75111_SetWDTDisable();
        }
    }
}
