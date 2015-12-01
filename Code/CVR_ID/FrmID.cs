using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using Common;

namespace CVR_ID
{
    public partial class FrmID : FrmBase
    {
        int iRetUSB, iRetCOM;
        Timer timerID = new Timer();
        public FrmID()
        {
            InitializeComponent();

            var ports = SerialPort.GetPortNames();
            cmbPorts.DataSource = ports;
            timerID.Tick += timerID_Tick;
        }

        private void timerID_Tick(object sender, EventArgs e)
        {
            int authenticate = CVRSDK.CVR_Authenticate();
            if (authenticate == 1)
            {
                int readContent = CVRSDK.CVR_Read_Content(4);
                if (readContent == 1)
                {
                    FillData();
                }
            }
        }

        private void FillData()
        {
            try
            {
                pictureBox1.ImageLocation = Application.StartupPath + "\\zp.bmp";
                byte[] name = new byte[30];
                int length = 30;
                CVRSDK.GetPeopleName(ref name[0], ref length);
                byte[] number = new byte[30];
                length = 36;
                CVRSDK.GetPeopleIDCode(ref number[0], ref length);
                byte[] people = new byte[30];
                length = 3;
                CVRSDK.GetPeopleNation(ref people[0], ref length);
                byte[] validtermOfStart = new byte[30];
                length = 16;
                CVRSDK.GetStartDate(ref validtermOfStart[0], ref length);
                byte[] birthday = new byte[30];
                length = 16;
                CVRSDK.GetPeopleBirthday(ref birthday[0], ref length);
                byte[] address = new byte[30];
                length = 70;
                CVRSDK.GetPeopleAddress(ref address[0], ref length);
                byte[] validtermOfEnd = new byte[30];
                length = 16;
                CVRSDK.GetEndDate(ref validtermOfEnd[0], ref length);
                byte[] signdate = new byte[30];
                length = 30;
                CVRSDK.GetDepartment(ref signdate[0], ref length);
                byte[] sex = new byte[30];
                length = 3;
                CVRSDK.GetPeopleSex(ref sex[0], ref length);

                byte[] samid = new byte[32];
                CVRSDK.CVR_GetSAMID(ref samid[0]);

                lblName.Text = GetString(name);
                lblIdCard.Text = GetString(number);
                lblNation.Text = GetString(people);
                lblSex.Text = GetString(sex);
                lblBirthday.Text = GetString(birthday);
                lblAddress.Text = GetString(address);
                lblDept.Text = GetString(signdate);
                lblSecurity.Text = "安全模块号：" + GetString(samid);
                lblValidDate.Text = GetString(validtermOfStart) + "-" + GetString(validtermOfEnd);
            }
            catch (Exception ex)
            {
                CMessageBox.Show(ex.ToString());
            }
        }

        private string GetString(byte[] buffer)
        {
            var str = Encoding.Default.GetString(buffer);
            str = str.Replace("\0", "").Trim();
            return str;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cmbPorts.Items.Count == 0)
            {
                CMessageBox.Show("计算机未发现串口！");
            }
            try
            {
                int iPort;
                for (iPort = 1001; iPort <= 1016; iPort++)
                {
                    iRetUSB = CVRSDK.CVR_InitComm(iPort);
                    if (iRetUSB == 1)
                    {
                        break;
                    }
                }
                if (iRetUSB != 1)
                {
                    for (iPort = 1; iPort <= 4; iPort++)
                    {
                        iRetCOM = CVRSDK.CVR_InitComm(iPort);
                        if (iRetCOM == 1)
                        {
                            break;
                        }
                    }
                }
                if (iRetUSB == 1 || iRetCOM == 1)
                {
                    timerID.Interval = 500;
                    timerID.Start();
                }
            }
            catch (Exception ex)
            {
                CMessageBox.Show(ex.ToString());
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CVRSDK.CVR_CloseComm();
            base.OnFormClosing(e);
        }
    }
}
