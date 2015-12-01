using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCodePrint
{
    public partial class Form1 : FrmBase
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetPrinters_Click(object sender, EventArgs e)
        {
            //PrintDocument pd = new PrintDocument();
            //pd.DefaultPageSettings.Bounds = new 
            //pd.Print();

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            //设置边距
            Margins margin = new Margins(200, 20, 20, 0);
            pd.DefaultPageSettings.Margins = margin;
            //纸张设置默认
            PaperSize pageSize = new PaperSize("First custom size", getYc(58), 100);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //打印事件设置            
            pd.PrintPage += pd_PrintPage;
            ppd.Document = pd;
            ppd.ShowDialog();
            //try
            //{
            //    pd.Print();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    pd.PrintController.OnEndPrint(pd, new PrintEventArgs());
            //}
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            var lineHeight = e.Graphics.MeasureString("伊", this.Font).Height;
            lineHeight += 2;

            var g = e.Graphics;
            //Print(g, "伊尹餐饮公司", 0);
            //Print(g, "C#的winform如何实", 1);
            //Print(g, "C#小票打印机动态纸张尺寸 - 开源中国社区", 2);
            //Print(g, "紫夜星风_新浪博客", 3);
            //Print(g, "demo程..._百度知道", 4);
            Print(g, GetPrintSW().ToString(), 0);
        }

        void Print(Graphics g, string str, int line)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            g.DrawString(str, this.Font, Brushes.Black, new PointF(5, line * 18), sf);
        }

        private int getYc(double cm)
        {
            var w = (int)(cm / 25.4) * 100;
            return w;
        }

        public StringBuilder GetPrintSW()
        {
            StringBuilder sb = new StringBuilder();
            string tou = "测试管理公司名称";
            string address = "河南洛阳";
            string saleID = "2010930233330";    //单号        
            string item = "项目";
            decimal price = 25.00M;
            int count = 5;
            decimal total = 0.00M;
            decimal fukuan = 500.00M;
            sb.AppendLine(" " + tou + " \n");
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine("日期:" + DateTime.Now.ToShortDateString() + " " + "单号:" + saleID);
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine("项目" + "      " + "数量" + "    " + "单价" + "    " + "小计");
            for (int i = 0; i < count; i++)
            {
                decimal xiaoji = (i + 1) * price;
                sb.AppendLine(item + (i + 1) + "      " + (i + 1) + "     " + price + "    " + xiaoji);
                total += xiaoji;
            }
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine("数量:" + count + "  合计: " + total);
            sb.AppendLine("付款:" + fukuan);
            sb.AppendLine("现金找零:" + (fukuan - total));
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine("地址:" + address + "");
            sb.AppendLine("电话:123456789 123456789");
            sb.AppendLine("谢谢惠顾欢迎下次光临 ");
            sb.AppendLine("-----------------------------------------");
            return sb;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //printDialog1.ShowDialog();
        }
    }
}
