using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace HitachiLift
{
    /// <summary>
    /// 广州耀华 日立电梯派梯
    /// </summary>
    public partial class FrmLift : FrmBase
    {
        public FrmLift()
        {
            InitializeComponent();

            var ports = SerialPort.GetPortNames().OrderBy(s => s.Length).ToList();
            cmbPorts.DataSource = ports;
            if (cmbPorts.DataSource != null && cmbPorts.Items.Count > 0)
                cmbPorts.SelectedIndex = 0;
            else
                btnPort.Enabled = false;

            SerialPortOperate.Window = this;
            cmbSetBaud.SelectedIndex = 0;
            cmbBaud.SelectedIndex = 0;
            cmbGateState.SelectedIndex = 0;
            cmbPersion.SelectedIndex = 0;
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
                if (rtbLog.Lines.Length >=25)
                {
                    rtbLog.Clear();
                }
                rtbLog.AppendText(string.Format(log, p));
                rtbLog.AppendText(Environment.NewLine);
            };

            try
            {
                if (rtbLog.InvokeRequired)
                    rtbLog.Invoke(act);
                else
                    act();
            }
            catch
            {
            }
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
            btnClosePort.Enabled = false;
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
                    btnClosePort.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CMessageBox.Show("串口打开失败：" + ex.Message);
            }
        }

        private void btnQueryPackage_Click(object sender, EventArgs e)
        {
            var total = Package.Query_Package();
            Log("查询--->");
            Log("长度：{0}", total.Length);
            Log("数据：{0}", total.ToHex());
            SerialPortOperate.SendData(total);
        }

        private void btnConfrmPackage_Click(object sender, EventArgs e)
        {
            var cardId = txtConfrmCardID.Text.ToInt32();
            var total = Package.Confrm_Package(cardId);
            Log("查询--->");
            Log("长度：{0}", total.Length);
            Log("数据：{0}", total.ToHex());
            SerialPortOperate.SendData(total);
        }

        private void btnChangeBaud_Click(object sender, EventArgs e)
        {
            var total = Package.ChangeBaud_Package(cmbSetBaud.Text.ToInt32());
            Log("设置波特率--->");
            Log("长度：{0}", total.Length);
            Log("数据：{0}", total.ToHex());
            SerialPortOperate.SendData(total);
        }

        /// <summary>
        /// 自动派梯
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
            Log("自动权限层：{0} {1}", b41.ToHex(), floor);
            var handBuffer = Funs.InitArray(8, 0x00);
            var total = Package.CardDataSendToLiftPackage(txtBackCardID.Text.ToInt32(), handBuffer, b41);
            Log("长度：{0}", total.Length);
            Log("数据：{0}", total.ToHex());

            label9.Text = "楼层：" + floor;

            SerialPortOperate.SendData(total);
        }

        /// <summary>
        /// 手动派梯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHand_Click(object sender, EventArgs e)
        {
            var floor = (byte)(cmbFloors.SelectedIndex + 1);
            var buffer = GetHandFloor(floor);

            var str = buffer.ToHex();
            Log("手动权限层：{0}", str);
            var total = Package.CardDataSendToLiftPackage(txtBackCardID.Text.ToInt32(), buffer, 0);
            Log("长度：{0}", total.Length);
            Log("数据：{0}", total.ToHex());

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
            Log("无卡包--->");
            Log("长度：{0}", total.Length);
            Log("数据：{0}", total.ToHex());
            SerialPortOperate.SendData(total);
        }

        private void btnBaud_Click(object sender, EventArgs e)
        {
            var total = Package.ConfrmBaudRate_Package(cmbBaud.Text.ToInt32());
            Log("返回波特率--->");
            Log("长度：{0}", total.Length);
            Log("数据：{0}", total.ToHex());
            SerialPortOperate.SendData(total);
        }

        private void btnBackGateState_Click(object sender, EventArgs e)
        {
            var gateState = cmbGateState.Text;
            var val = Funs.GetNumber(gateState);
            var total = Package.GateState_Package(val);
            Log("闸机返回状态-->");
            Log("长度：{0}", total.Length);
            Log("数据：{0}", total.ToHex());
            SerialPortOperate.ParsePackage(total);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cardID = txtBackCardID.Text.ToInt32();
            var gateState = cmbPersion.Text;
            var val = Funs.GetNumber(gateState);
            var total = Package.ConfrmGateCard_Package(cardID, val);
            Log("闸机确认卡片状态-->");
            Log("长度：{0}", total.Length);
            Log("数据：{0}", total.ToHex());
            SerialPortOperate.ParsePackage(total);
        }

        private void btnQueryGateState_Click(object sender, EventArgs e)
        {
            var total = Package.QueryGateState_Package();
            Log("查询闸机状态-->");
            Log("长度：{0}", total.Length);
            Log("数据：{0}", total.ToHex());
            SerialPortOperate.SendData(total);
        }

        private void btnQueryGateCardPermission_Click(object sender, EventArgs e)
        {
            var cardID = txtId.Text.ToInt32();
            var total = Package.QueryGateCardState_Package(cardID);
            Log("查询闸机卡片权限-->");
            Log("长度：{0}", total.Length);
            Log("数据：{0}", total.ToHex());
            SerialPortOperate.SendData(total);
        }

        private void btnLogClear_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {
            SerialPortOperate.ClosePort();
            btnPort.Enabled = true;
            btnClosePort.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                var floor = 1;
                while (true)
                {
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
                    Log("自动权限层：{0} {1}", b41.ToHex(), floor);
                    var handBuffer = Funs.InitArray(8, 0x00);
                    var total = Package.CardDataSendToLiftPackage(txtBackCardID.Text.ToInt32(), handBuffer, b41);
                    Log("长度：{0}", total.Length);
                    Log("数据：{0}", total.ToHex());

                    Action act = () =>
                    {
                        label9.Text = "楼层：" + floor;
                    };
                    Invoke(act);

                    floor++;
                    if (floor > 17)
                    {
                        floor = 1;
                    }
                    SerialPortOperate.SendData(total);
                    Thread.Sleep(5000);
                }
            }).Start();
        }
    }
}
/*
196
 44
 155
 207
*/