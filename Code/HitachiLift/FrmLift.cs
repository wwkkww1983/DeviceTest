using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void InitFloors()
        {
            var floorsRang = Enumerable.Range(1, 64).ToList();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DataSource = floorsRang;
            comboBox1.SelectedIndex = 0;
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

        /// <summary>
        /// 自动派
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuto_Click(object sender, EventArgs e)
        {
            var floor = (byte)(comboBox1.SelectedIndex + 1);
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
            var floor = (byte)(comboBox1.SelectedIndex + 1);
            var buffer = GetHandFloor(floor);

            var str = buffer.ToHex();
            Log("手动权限层：{0}", str);

            var total = Package.CardDataSendToLiftPackage(buffer, 0);
            Log("数据包长度：{0}", total.Length);
            Log("手动权限层完整包：{0}", total.ToHex());
        }
    }
}
