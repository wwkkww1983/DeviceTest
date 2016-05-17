using Iaspec.Common.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace HitchElevator.Core
{
    public static class Logger
    {
        static ILogOutput log = DefaultLogFacade.CreateLog("");
        static Logger()
        {
            DefaultLogFacade.RegisterLogWriter(DefaultLogFacade.CreateFilePathWriter("Logs"));
        }
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="str"></param>
        public static void ToFile(object str)
        {
            str = DateTime.Now.ToStandard() + " " + str;
            log.WriteInfomation(str.ToString());
        }
    }
}
