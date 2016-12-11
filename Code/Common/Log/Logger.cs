using Iaspec.Common.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Common.Log
{
    public static class LogHelper
    {
        static ILogOutput log = DefaultLogFacade.CreateLog("");
        static LogHelper()
        {
            DefaultLogFacade.RegisterLogWriter(DefaultLogFacade.CreateFilePathWriter("Logs"));
        }
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="str"></param>
        public static void Info(object str, params string[] args)
        {
            try
            {
                var msg = string.Format("gate:" + DateTime.Now.ToString("HH:mm:ss") + " " + str, args);
                Trace.WriteLine(msg);
                log.WriteInfomation(msg);
            }
            catch
            {
            }
        }

        public static void LogJson(string str)
        {
            try
            {
                var msg = "gate:" + DateTime.Now.ToString("HH:mm:ss") + " " + str;
                Console.WriteLine(msg);
                log.WriteInfomation(msg);
            }
            catch
            {
            }
        }
    }
}
