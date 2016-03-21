using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HitachiLift
{
    /// <summary>
    /// 日立电梯派梯
    /// </summary>
    public partial class FrmLift : FrmBase
    {
        public FrmLift()
        {
            InitializeComponent();

            cmbPorts.DataSource = SerialPort.GetPortNames();
            if (cmbPorts.DataSource != null && cmbPorts.Items.Count > 0)
                cmbPorts.SelectedIndex = 0;
            else
                btnPort.Enabled = false;

            SerialPortOperate.Window = this;
        }

        private void InitFloors()
        {
            var floorsRang = Enumerable.Range(1, 64).ToList();
            cmbFloors.DataSource = floorsRang;
            cmbFloors.SelectedIndex = 0;
        }

        public void Log(string log, params object[] p)
        {
            Action act = () =>
            {
                richTextBox1.AppendText(string.Format(log, p));
                richTextBox1.AppendText(Environment.NewLine);
            };
            if (richTextBox1.InvokeRequired)
                richTextBox1.Invoke(act);
            else
                act();
        }

        private byte[] GetHandFloor(int floor)
        {
            BitArray bit = new BitArray(64, false);
            bit[floor - 1] = true;
            byte[] buffer = new byte[8];
            bit.CopyTo(buffer, 0);
            return buffer;
        }

        private void FrmLift_Load(object sender, EventArgs e)
        {
            InitFloors();
        }

        private void btnPort_Click(object sender, EventArgs e)
        {
            try
            {
                var bOpen = SerialPortOperate.Open(cmbPorts.Text);
                if (bOpen)
                {
                    SerialPortOperate.DoReceive();
                    btnPort.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                CMessageBox.Show("串口打开失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 自动派
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuto_Click(object sender, EventArgs e)
        {
            var floor = (byte)(cmbFloors.SelectedIndex + 1);
            byte bx = 0x00;
            if (rb1.Checked)
                bx = 0x00;
            if (rb2.Checked)
                bx = 0x80;
            if (rb3.Checked)
                bx = 0x40;
            if (rb4.Checked)
                bx = 0xC0;

            var b41 = (byte)(bx | floor);
            Log("自动权限层：{0}", b41.ToHex());
            var handBuffer = new byte[8];
            var total = Package.CardDataSendToLiftPackage(handBuffer, b41);
            Log("长度：{0}", total.Length);
            Log("自动权限层完整包：{0}", total.ToHex());

            SerialPortOperate.SendData(total);
        }

        /// <summary>
        /// 手工派
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHand_Click(object sender, EventArgs e)
        {
            var floor = (byte)(cmbFloors.SelectedIndex + 1);
            var buffer = GetHandFloor(floor);

            var str = buffer.ToHex();
            Log("手动权限层：{0}", str);

            var total = Package.CardDataSendToLiftPackage(buffer, 0);
            Log("数据包长度：{0}", total.Length);
            Log("手动权限层完整包：{0}", total.ToHex());

            SerialPortOperate.SendData(total);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            SerialPortOperate.ClosePort();
            base.OnClosing(e);
        }

        private void btnNoCard_Click(object sender, EventArgs e)
        {
            var total = Package.NoCard_Package();
            Log("长度：{0}", total.Length);
            Log("数据包：{0}", total.ToHex());
        }

        private void btnBaud_Click(object sender, EventArgs e)
        {
            var total = Package.ConfrmBaudRate_Package(9600);
            Log("长度：{0}", total.Length);
            Log("数据包：{0}", total.ToHex());

            total = Package.ConfrmBaudRate_Package(19200);
            Log("长度：{0}", total.Length);
            Log("数据包：{0}", total.ToHex());

            total = Package.ConfrmBaudRate_Package(38400);
            Log("长度：{0}", total.Length);
            Log("数据包：{0}", total.ToHex());

            total = Package.ConfrmBaudRate_Package(57600);
            Log("长度：{0}", total.Length);
            Log("数据包：{0}", total.ToHex());

            total = Package.ConfrmBaudRate_Package(115200);
            Log("长度：{0}", total.Length);
            Log("数据包：{0}", total.ToHex());
        }

        private void btnChangeBaud_Click(object sender, EventArgs e)
        {
            var total = Package.ChangeBaud_Package(9600);
            Log("长度：{0}", total.Length);
            Log("数据包：{0}", total.ToHex());
            SerialPortOperate.ParsePackage(total);

            total = Package.ChangeBaud_Package(19200);
            Log("长度：{0}", total.Length);
            Log("数据包：{0}", total.ToHex());
            SerialPortOperate.ParsePackage(total);

            total = Package.ChangeBaud_Package(38400);
            Log("长度：{0}", total.Length);
            Log("数据包：{0}", total.ToHex());
            SerialPortOperate.ParsePackage(total);

            total = Package.ChangeBaud_Package(57600);
            Log("长度：{0}", total.Length);
            Log("数据包：{0}", total.ToHex());
            SerialPortOperate.ParsePackage(total);

            total = Package.ChangeBaud_Package(115200);
            Log("长度：{0}", total.Length);
            Log("数据包：{0}", total.ToHex());
            SerialPortOperate.ParsePackage(total);
        }

        private void btnBackGateState_Click(object sender, EventArgs e)
        {
           var total = Package.GateState_Package(1);
            Log("闸机返回状态 长度：{0}", total.Length);
            Log("数据包：{0}", total.ToHex());
            SerialPortOperate.ParsePackage(total);
        }
    }
}
/*
196
 44
 155
 207
*/