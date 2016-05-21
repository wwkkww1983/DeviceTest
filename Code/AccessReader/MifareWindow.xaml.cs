using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AccessReader
{
    /// <summary>
    /// MifareWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MifareWindow
    {

        private const string prefix = "6fh {0} 00h 00h 00h 00h 00h 00h 00h 00h ";
        /// <summary>
        /// 默认A B 密码为 0xFF 0xFF 0xFF 0xFF 0xFF 0xFF
        /// </summary>
        public MifareWindow()
        {
            InitializeComponent();
            Sectors = Enumerable.Range(1, 16).Select(s => s.ToString()).ToArray();
            this.DataContext = this;
        }
        public string[] Sectors { get; set; }

        private void ReadBlockA(int block)
        {
            var cmd = 0x06;    //读
            //var cmd = 0x46;    //授权读
            //var cmd = 0x86;    //选中并授权读
        }

        private void ReadBlockB(int block)
        {
            var cmd = 0x16;    //读
            //var cmd = 0x56;    //授权读
            //var cmd = 0x96;    //选中并授权读
        }

        private void WriteBlockA(int block, byte[] buffer)
        {
            var cmd = 0x08;    //写
            //var cmd = 0x48;    //授权写
            //var cmd = 0x88;    //选中并授权写
        }

        private void WriteBlockB(int block, byte[] buffer)
        {
            var cmd = 0x18;    //读
            //var cmd = 0x58;    //授权读
            //var cmd = 0x98;    //选中并授权读
        }
    }
}
