using Common;
using MobileClient.Mobile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MobileClient
{
    public partial class FrmTest : FrmBase
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FKSoapClient fk = new FKSoapClient();
            //var str = fk.PushAppointment("", "", "", "", "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FKSoapClient fk = new FKSoapClient("FKSoap");
            var list = fk.GetDoorRecord().ToList();
            CMessageBox.Show(list.Count.ToString());
            CMessageBox.Show(string.Format("{0},{1},{2},{3}", list.First().BMCode, list.First().BMName, list.First().BMType, list.First().SwipeTime.ToShortDateString()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mobile.FKSoapClient fk = new Mobile.FKSoapClient();
            //var str = fk.HelloWorld();
            //CMessageBox.Show(str);
        }
    }
}
