using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QRReader
{
    public partial class FrmAbout : FrmBase
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            label1.Text = string.Concat(versionInfo.FileName, Environment.NewLine, versionInfo.FileVersion);
        }
    }
}
