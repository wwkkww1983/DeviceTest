//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrmLinqToMySql.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_basestation
    {
        public int Id { get; set; }
        public string titles { get; set; }
        public string addrName { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public System.DateTime collectTime { get; set; }
        public Nullable<int> caseId { get; set; }
        public int userId { get; set; }
        public System.DateTime createTime { get; set; }
        public System.DateTime modefyTime { get; set; }
    }
}
