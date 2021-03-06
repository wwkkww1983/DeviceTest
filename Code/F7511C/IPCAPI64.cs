﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace F7511C
{
    /// <summary>
    /// 主板IO控制(64)
    /// </summary>
    public sealed class IPCAPI64
    {
        const string dllname = "F7511164.dll";
        [DllImport(dllname, CharSet = CharSet.None, ExactSpelling = false)]
        public static extern bool F75111_Init();
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
