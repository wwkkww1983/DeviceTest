using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XzxID
{
    public static class IDAPI
    {
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_FindReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindReader();

        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoPath", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoPath(int iOption, ref byte cPhotoPath);

        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoType(int iType);

        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoName", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoName(int iType);

        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_OpenPort", CharSet = CharSet.Ansi)]
        public static extern int Syn_OpenPort(int iPort);

        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ClosePort", CharSet = CharSet.Ansi)]
        public static extern int Syn_ClosePort(int iPort);

        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetMaxRFByte", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetMaxRFByte(int iPort, byte ucByte, int iIfOpen);

        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_StartFindIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_StartFindIDCard(int iPort, ref byte pucIIN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SelectIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_SelectIDCard(int iPort, ref byte pucSN, int iIfOpen);

        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetNationType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetNationType(int iType);

        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetSexType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetSexType(int iType);

        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetBornType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetBornType(int iType);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct IDCardData
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] //结构中使用的字串，[]类似限定说明 说明此公共结构传输到非托管代码时封装定义
        public string Name; //姓名   
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string Sex;   //性别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string Nation; //名族
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
        public string Born; //出生日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 72)]
        public string Address; //住址
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
        public string IDCardNo; //身份证号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string GrantDept; //发证机关
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
        public string UserLifeBegin; // 有效开始日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
        public string UserLifeEnd;  // 有效截止日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
        public string reserved; // 保留
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string PhotoFileName; // 照片路径
    }
}
