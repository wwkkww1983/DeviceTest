using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Common
{
    public class CMessageBox
    {
        public static DialogResult Show(string text, string title = "提示")
        {
            return MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Confirm(string text, string title = "确认")
        {
            return MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
    }
}
