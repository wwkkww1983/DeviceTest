using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FKWCFServices
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IFK
    {
        [OperationContract]
        string HelloWorld();

        [OperationContract]
        string PushAppointment(string AppointmentId, string VisitorId,
            string VisitorName, string VisitorIdCard,
            string VisitorMobile);

        [OperationContract]
        List<TimeList> GetDoorRecord();
    }

    [DataContract]
    public class TimeList
    {
        [DataMember]
        public string BMCode { get; set; }

        [DataMember]
        public string BMName { get; set; }

        [DataMember]
        public string BMType { get; set; }

        [DataMember]
        public DateTime SwipeTime { get; set; }
    }
}
