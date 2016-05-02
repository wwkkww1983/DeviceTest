using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisitorServiceSelf
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process instance = RunningInstance();
            if (null == instance)
            {
                Application.Run(new FrmMainWindow());
            }
            else
            {
                HandleRunningInstance(instance);
            }
        }

        private static void HandleRunningInstance(Process instance)
        {
            IntPtr winPtr = IntPtr.Zero;
            if (instance.MainWindowHandle == IntPtr.Zero)
            {
                winPtr = FindWindow(null, "闸机控制软件");
            }
            else
            {
                winPtr = instance.MainWindowHandle;
            }
            ShowWindowAsync(winPtr, 1);  //调用api函数，正常显示窗口
            SetForegroundWindow(winPtr); //将窗口放置最前端
        }


        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);


        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历与当前进程名称相同的进程列表  
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程  
                if (process.Id != current.Id)
                {
                    //保证要打开的进程同已经存在的进程来自同一文件路径
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "//") == current.MainModule.FileName)
                    {
                        //返回已经存在的进程
                        return process;
                    }
                }
            }
            return null;
        }
    }
}
