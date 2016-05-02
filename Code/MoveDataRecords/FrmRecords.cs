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

namespace DataRecords
{
    public partial class FrmRecords : FrmBase
    {
        List<User> records = new List<User>();
        public FrmRecords()
        {
            InitializeComponent();
        }

        private void FrmRecords_Load(object sender, EventArgs e)
        {
            records.Add(new User { ID = "1", Name = "ysj", Image = "1.jpg" });
            records.Add(new User { ID = "2", Name = "dgl", Image = "2.jpg" });
            records.Add(new User { ID = "3", Name = "ylz", Image = "3.jpg" });
            records.Add(new User { ID = "4", Name = "ysh", Image = "4.jpg" });
            bs.DataSource = records;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
            ShowRecord(bs.Current as User);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
            ShowRecord(bs.Current as User);
        }

        private void ShowRecord(User user)
        {
            txtID.Text = user.ID;
            txtName.Text = user.Name;
            pictureBox1.ImageLocation = user.Image;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
            ShowRecord(bs.Current as User);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
            ShowRecord(bs.Current as User);
        }
    }


    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
