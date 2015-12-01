using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisitorServiceSelf.Panels
{
    public class PictureBoxAdvert : PictureBox
    {
        AutoResetEvent waitOne = new AutoResetEvent(false);
        public PictureBoxAdvert()
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void Start()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                var path = Path.Combine(Application.StartupPath, "Advert");
                var files = Directory.GetFiles(path);
                bool stop = false;
                while (!stop)
                {
                    foreach (var file in files)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            this.ImageLocation = file;
                        }));
                        if (waitOne.WaitOne(TimeSpan.FromSeconds(2)))
                        {
                            stop = true;
                            break;
                        }
                    }
                }
            });
        }

        public void Stop()
        {
            waitOne.Set();
        }
    }
}
