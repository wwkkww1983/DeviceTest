using Common.NotifyBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VGuangQRReader
{
    class Test : PropertyNotifyObject
    {
        public bool FirstVehicle
        {
            get { return this.GetValue(s => s.FirstVehicle); }
            set { this.SetValue(s => s.FirstVehicle, value); }
        }

        public bool LastVehicle
        {
            get { return this.GetValue(s => s.LastVehicle); }
            set { this.SetValue(s => s.LastVehicle, value); }
        }

        public string TipContent
        {
            get { return this.GetValue(s => s.TipContent); }
            set { this.SetValue(s => s.TipContent, value); }
        }
    }
}
