using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FKWebServices
{
    [Serializable]
    public class TimeList
    {
        public string BMCode { get; set; }

        public string BMName { get; set; }

        public string BMType { get; set; }

        public DateTime SwipeTime { get; set; }
    }
}