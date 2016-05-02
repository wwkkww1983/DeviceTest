using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Honeywell3580
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmMain : FrmBase, ILog
    {
        private BarCodeReader _reader = null;
        public FrmMain()
        {
            InitializeComponent();
            Context.Log = this;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cmbPorts.DataSource = ports;
            if (cmbPorts.Items.Count == 0)
            {
                btnOpen.Enabled = false;
            }
            _reader = new BarCodeReader();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            _reader.Open(cmbPorts.Text, ReaderType.YJ);
        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_reader != null)
                _reader.Dispose();
        }

        public void Write(object obj)
        {
            Action act = () =>
            {
                rtbCode.AppendText(DateTime.Now + " " + obj + Environment.NewLine);
            };
            Invoke(act);
        }
    }
}
