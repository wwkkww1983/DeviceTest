using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.WebAPI
{
    /// <summary>
    /// 登录 
    /// </summary>
    public class KoalaLogin
    {
        public int code { get; set; }

        public LoginData data { get; set; }
    }

    /// <summary>
    /// 登录数据
    /// </summary>
    public class LoginData
    {
        public string company { get; set; }

        public string contact { get; set; }

        public string email { get; set; }

        public int id { get; set; }

        public bool password_reseted { get; set; }

        public string phone { get; set; }

        public int role_id { get; set; }

        public string username { get; set; }
    }

    /// <summary>
    /// 用户
    /// </summary>
    public class SubjectData
    {
        public string remark { get; set; }

        public int subject_type { get; set; }

        public string description { get; set; }

        public string title { get; set; }

        public long timestamp { get; set; }

        public int start_time { get; set; }

        public int end_time { get; set; }

        public string avatar { get; set; }

        public string job_number { get; set; }

        public object birthday { get; set; }

        public object entry_date { get; set; }

        public string department { get; set; }

        public int id { get; set; }

        public string name { get; set; }

        public string[] photo_ids { get; set; }

        public photo[] photos { get; set; }
    }

    public class photo
    {
        public int company_id { get; set; }

        public int id { get; set; }

        public float quality { get; set; }

        public int subject_id { get; set; }

        public string url { get; set; }

        public int version { get; set; }
    }

    public class Subject
    {
        public int code { get; set; }

        public SubjectData data { get; set; }
    }

    public class UploadPhoto
    {
        public int code { get; set; }
        public UpdatePhotoData data { get; set; }
    }

    public class UpdatePhotoData
    {
        public int id { get; set; }
        public int company_id { get; set; }
        public int subject_id { get; set; }
        public string url { get; set; }
        public float code { get; set; }

    }

    public class SubjectList
    {
        public int code { get; set; }

        public List<SubjectData> data { get; set; }
    }

    public class FaceCompare
    {
        public FaceInfo face_info_1 { get; set; }

        public FaceInfo face_info_2 { get; set; }

        public bool same { get; set; }
        /// <summary>
        /// 0~100
        /// </summary>
        public float score { get; set; }
    }

    public class FaceInfo
    {
        public Rect rect { get; set; }

        public float quality { get; set; }

        public float brightness { get; set; }

        public float std_deviation { get; set; }
    }

    public class Rect
    {
        public int Left { get; set; }

        public int Top { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }

    /// <summary>
    /// 获得 ARC 运行状态
    /// </summary>
    public class NucRunState
    {
        public string version { get; set; }

        public Disk disk { get; set; }

        public Ip ip { get; set; }
    }

    public class Disk
    {
        /// <summary>
        /// 总硬盘空间，单位为KiB
        /// </summary>
        public long total { get; set; }
        /// <summary>
        /// 已用空间
        /// </summary>
        public long used { get; set; }
        /// <summary>
        /// 剩余空间
        /// </summary>
        public long avail { get; set; }
    }

    public class Ip
    {
        public string addr { get; set; }

        public string netmask { get; set; }

        public string gateway { get; set; }

        public string dns { get; set; }

        public bool dhcp { get; set; }
    }
}
