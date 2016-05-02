using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCamera
{
    public partial class FrmCamera : FrmBase
    {
        WebCam cam = null;
        public FrmCamera()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            cam = new WebCam { Container = pbVideo };
            cam.OpenConnection();
        }

        private void btnSnapShot_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = cam.GetCurrentImage();
            pbSnap.SizeMode = PictureBoxSizeMode.Zoom;
            pbSnap.Image = bitmap;

            label1.Text = string.Format("W:{0} H:{1}", bitmap.Width, bitmap.Height);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (cam != null)
            {
                cam.Dispose();
            }
            base.OnClosing(e);
        }
    }
}
