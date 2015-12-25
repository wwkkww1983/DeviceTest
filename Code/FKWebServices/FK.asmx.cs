using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FKWebServices
{
    /// <summary>
    /// FK 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://ysj.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class FK : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentId">预约编号</param>
        /// <param name="VisitorId">访问者编号</param>
        /// <param name="VisitorName">访问者名字</param>
        /// <param name="VisitorIdCard">访问者身份证号码</param>
        /// <param name="VisitorMobile">访问者电话</param>
        /// <returns></returns>
        [WebMethod(Description = "推送预约信息")]
        public string PushAppointment(string AppointmentId, string VisitorId,
            string VisitorName, string VisitorIdCard,
            string VisitorMobile)
        {
            return string.Empty;
        }

        [WebMethod(Description = "获取门禁记录")]

        public List<TimeList> GetDoorRecord()
        {
            var list = new List<TimeList>
           {
               new TimeList{ BMCode="1" ,BMName="1", BMType="进", SwipeTime=DateTime.Now},
               new TimeList{ BMCode="2" ,BMName="2", BMType="出", SwipeTime=DateTime.Now},
               new TimeList{ BMCode="3" ,BMName="3", BMType="进", SwipeTime=DateTime.Now},
               new TimeList{ BMCode="4" ,BMName="4", BMType="出", SwipeTime=DateTime.Now},
               new TimeList{ BMCode="5" ,BMName="5", BMType="进", SwipeTime=DateTime.Now}
           };
            return list;
        }
    }
}
