using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorServiceSelf.Panels;

namespace VisitorServiceSelf.Core
{
    public class Controllers
    {
        public delegate void WindowChangeEventHandler(PanelBase panel);
        public event WindowChangeEventHandler WindowChange;
        private PanelBase currentWindow = null;
        private static Controllers _controler = null;
        public VisitorRecord RecordInfo
        {
            get;
            set;
        }
        private Controllers()
        {
        }

        public static Controllers Instance
        {
            get
            {
                if (_controler == null)
                    _controler = new Controllers();
                return _controler;
            }
        }

        private List<PanelBase> Windows = new List<PanelBase>();
        private int Index = 0;

        public int Count
        {
            get
            {
                return Windows.Count;
            }
        }

        public void RegistrationPanel(PanelBase pb)
        {
            Windows.Add(pb);
        }

        public void Clear()
        {
            foreach (var window in Windows)
            {
                window.Dispose();
            }
        }

        public void Start()
        {
            Index = 0;
            currentWindow = Windows[0];
            Fire();
        }

        public void Next()
        {
            if (Index < Count)
                Index++;
            currentWindow = Windows[Index];
            Fire();
        }

        public void Previous()
        {
            if (Index > 0)
                Index--;
            currentWindow = Windows[Index];
            Fire();
        }

        protected void Fire()
        {
            if (WindowChange != null)
            {
                WindowChange(currentWindow);
            }
        }
    }
}
