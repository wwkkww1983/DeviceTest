using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SR_104
{
    /// <summary>
    /// FrmImageZoomPan.xaml 的交互逻辑
    /// </summary>
    public partial class FrmImageZoomPan : Window
    {
        public FrmImageZoomPan()
        {
            InitializeComponent();
        }

        double d = 1.0d;
        private void img_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                var trans = image.RenderTransform as TransformGroup;
                var scale = trans.Children[0] as ScaleTransform;
                scale.ScaleX += d * 0.1;
                scale.ScaleY += d * 0.1;
            }
            else
            {
                var trans = image.RenderTransform as TransformGroup;
                var scale = trans.Children[0] as ScaleTransform;

                if (scale.ScaleX <= 0.5)
                    return;

                scale.ScaleX -= d * 0.1;
                scale.ScaleY -= d * 0.1;
            }
            //var s = img.RenderTransform as ScaleTransform;
            //Console.WriteLine(s.ScaleX + " " + s.ScaleY + " " + s.CenterX + " " + s.CenterY);
        }

        Point start, origin;

        private void image_MouseMove(object sender, MouseEventArgs e)
        {
            if (!image.IsMouseCaptured) return;

            var tt = (TranslateTransform)((TransformGroup)image.RenderTransform).Children.First(tr => tr is TranslateTransform);
            Vector v = start - e.GetPosition(grid);
            tt.X = origin.X - v.X;
            tt.Y = origin.Y - v.Y;
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            image.ReleaseMouseCapture();
        }

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image.CaptureMouse();
            var tt = (TranslateTransform)((TransformGroup)image.RenderTransform).Children.First(tr => tr is TranslateTransform);
            start = e.GetPosition(grid);
            origin = new Point(tt.X, tt.Y);
        }
    }
}
