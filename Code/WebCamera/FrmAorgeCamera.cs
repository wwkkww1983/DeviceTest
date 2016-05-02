using AForge.Video.DirectShow;
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
    public partial class FrmAorgeCamera : FrmBase
    {
        CameraDevices camera = new CameraDevices();
        VideoCaptureDevice videoDevice = null;
        public FrmAorgeCamera()
        {
            InitializeComponent();
        }

        private void FrmAorgeCamera_Load(object sender, EventArgs e)
        {
            if (camera.Devices.Count <= 0)
                return;

            var device = camera.Devices[0];
            videoDevice = new VideoCaptureDevice(device.MonikerString);
            var videoCapabilities = videoDevice.VideoCapabilities;
            //videoDevice.VideoResolution = videoCapabilities[10];
            videoDevice.NewFrame += videoDevice_NewFrame;
            videoDevice.Start();
        }

        void videoDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            pbVideo.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btnSnapShot_Click(object sender, EventArgs e)
        {
            videoDevice.SimulateTrigger();
            Bitmap bitmap = pbVideo.Image as Bitmap;
            pbSnap.Image = bitmap;
            label1.Text = string.Format("W:{0} H:{1}", bitmap.Width, bitmap.Height);
        }
    }
}
