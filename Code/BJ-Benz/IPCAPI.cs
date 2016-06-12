using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BJ_Benz
{
    /// <summary>
    /// 主板IO控制
    /// </summary>
    sealed class IPCAPI
    {
        const string dllname = "F7511132.dll";
        [DllImport(dllname, CharSet = CharSet.None, ExactSpelling = false)]
        public static extern UInt16 F75111_Init();
        [DllImport(dllname, CharSet = CharSet.None, ExactSpelling = false)]
        public static extern UInt16 F75111_GetDigitalInput();
        [DllImport(dllname, CharSet = CharSet.None, ExactSpelling = false)]
        public static extern void F75111_SetDigitalOutput(byte byteValue);
        [DllImport(dllname, CharSet = CharSet.None, ExactSpelling = false)]
        public static extern void F75111_SetWDTEnable(byte byteTimer);
        [DllImport(dllname, CharSet = CharSet.None, ExactSpelling = false)]
        public static extern void F75111_SetWDTDisable();
    }
}
