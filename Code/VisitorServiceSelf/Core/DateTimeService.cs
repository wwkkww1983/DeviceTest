using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisitorServiceSelf.Core
{
    public class DateTimeService
    {
        static Timer timer = new Timer();
        static string[] DayOfWeek = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        static Label _content = null;
        static DateTimeService()
        {
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
        }
        public static void Start(Label content)
        {
            _content = content;
            _content.Text = GetDateTimeInfo();
            timer.Start();
        }

        static void timer_Tick(object sender, EventArgs e)
        {
            _content.Text = GetDateTimeInfo();
        }

        private static string GetDateTimeInfo()
        {
            var year = DateTime.Now.ToString("yyyy年MM月dd日");

            var week = DayOfWeek[(int)DateTime.Now.DayOfWeek];

            var hours = DateTime.Now.ToString("HH:mm:ss");

            return string.Concat(year, " ", week, " ", hours); 
        }

        public static void Stop()
        {
            timer.Stop();
        }
    }
}
