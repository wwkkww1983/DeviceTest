using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XzxID
{
    public partial class FrmMain : FrmBase
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            uint[] iBaud = new uint[1];
            i = IDAPI.Syn_FindReader();
            if (i > 0)
            {
                if (i > 1000)
                {
                    textBox1.Text = i.ToString();
                    AddToListbox("读卡器连接在USB " + i.ToString());

                    var nRet = IDAPI.Syn_SetMaxRFByte(i, 80, 0);
                    AddToListbox("Syn_SetMaxRFByte, nRet=" + nRet);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IDCardData CardMsg = new IDCardData();
            int nRet, nPort;
            byte[] pucIIN = new byte[4];
            byte[] pucSN = new byte[8];
            nPort = Convert.ToInt32(textBox1.Text);

            nRet = IDAPI.Syn_OpenPort(nPort);
            if (nRet != 0)
            {
                AddToListbox("打开端口, nRet=" + nRet);
                return;
            }
            nRet = IDAPI.Syn_StartFindIDCard(nPort, ref pucIIN[0], 0);
            if (nRet != 0)
            {
                AddToListbox("Syn_StartFindIDCard, nRet=" + nRet);
                return;
            }
            nRet = IDAPI.Syn_SelectIDCard(nPort, ref pucSN[0], 0);
            if (nRet != 0)
            {
                AddToListbox("Syn_SelectIDCard, nRet=" + nRet);
                return;
            }

            try
            {
                nRet = IDAPI.Syn_ReadMsg(nPort, 0, ref CardMsg);
            }
            catch
            {
                MessageBox.Show("cao");
            }
            if (nRet == 0)
            {
                listBox1.Items.Clear();
                AddToListbox("姓名:" + CardMsg.Name);
                AddToListbox("性别:" + CardMsg.Sex);
                AddToListbox("民族:" + CardMsg.Nation);
                AddToListbox("出生日期:" + CardMsg.Born);
                AddToListbox("地址:" + CardMsg.Address);
                AddToListbox("身份证号:" + CardMsg.IDCardNo);
                AddToListbox("发证机关:" + CardMsg.GrantDept);
                AddToListbox("有效期开始:" + CardMsg.UserLifeBegin);
                AddToListbox("有效期结束:" + CardMsg.UserLifeEnd);
                AddToListbox("照片文件名:" + CardMsg.PhotoFileName);
                pictureBox1.ImageLocation = CardMsg.PhotoFileName;
            }
            else
            {
                AddToListbox("读取身份证信息错误");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int nRet;
            byte[] cPath = new byte[255];
            nRet = IDAPI.Syn_SetPhotoPath(1, ref cPath[0]);
            AddToListbox("照片存放路径设置为当前路径,nRet =" + Convert.ToString(nRet));

            nRet = IDAPI.Syn_SetPhotoType(1);
            AddToListbox("照片存放格式为Jpeg ,nRet =" + Convert.ToString(nRet));

            nRet = IDAPI.Syn_SetPhotoName(0);
            AddToListbox("设置图片名称 tmp,nRet =" + Convert.ToString(nRet));

            nRet = IDAPI.Syn_SetSexType(1);
            if (nRet == 0)
                AddToListbox("设置性别");
            else
                AddToListbox("sex error");

            nRet = IDAPI.Syn_SetNationType(1);
            if (nRet == 0)
                AddToListbox("设置民族格式");
            else
                AddToListbox("nation error");

            nRet = IDAPI.Syn_SetBornType(3);
            AddToListbox("设置生日格式yyyy-MM-dd, nRet=" + nRet);
        }

        private void AddToListbox(string str)
        {
            listBox1.Items.Add(DateTime.Now + " " + str);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
            button3.PerformClick();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                int nRet = IDAPI.Syn_ClosePort(Int32.Parse(textBox1.Text));
            }
        }
    }
}
