using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisitorServiceSelf.Core;

namespace VisitorServiceSelf.Panels
{
    public partial class PanelBase : UserControl
    {
        public PanelBase()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
        }

        protected Controllers Controller
        {
            get
            {
                return Controllers.Instance;
            }
        }

        public virtual void Work()
        {

        }
    }
}
