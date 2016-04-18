using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public interface ILog
    {
        void Write(Object obj);
    }

    public static class Context
    {
        public static ILog Log { get; set; }
    }
}
