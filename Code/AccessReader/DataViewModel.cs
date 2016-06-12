using Common.NotifyBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessReader
{
    class DataViewModel : PropertyNotifyObject
    {
        public string Barcode
        {
            get { return this.GetValue(s => s.Barcode); }
            set { this.SetValue(s => s.Barcode, value); }
        }

    }
}
