using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services.Description;

namespace FKWCFServices
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class FKServices : IFK
    {
        public string HelloWorld()
        {
            return "Hello WCF";
        }

        public string PushAppointment(string AppointmentId, string VisitorId, string VisitorName, string VisitorIdCard, string VisitorMobile)
        {
            return "PushAppointment";
        }

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
