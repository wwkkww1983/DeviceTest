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
        SerialPort _port = null;
        public FrmLift()
        {
            InitializeComponent();

            cmbPorts.DataSource = SerialPort.GetPortNames();
            if (cmbPorts.DataSource != null)
                cmbPorts.SelectedIndex = 0;
        }

        private void InitFloors()
        {
            var floorsRang = Enumerable.Range(1, 64).ToList();
            cmbFloors.DataSource = floorsRang;
            cmbFloors.SelectedIndex = 0;
        }

        private void Log(string log, params object[] p)
        {
            richTextBox1.AppendText(string.Format(log, p));
            richTextBox1.AppendText(Environment.NewLine);
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
                _port = new SerialPort(cmbPorts.Text, 9600, Parity.None, 8, StopBits.One);
                _port.Open();
                btnPort.Enabled = false;
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
            Log("数据包长度：{0}", total.Length);
            Log("自动权限层完整包：{0}", total.ToHex());
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
        }
    }
}
