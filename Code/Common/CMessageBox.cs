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
        public static DialogResult Show(string text)
        {
            return MessageBox.Show(text, "提示");
        }
    }
}
