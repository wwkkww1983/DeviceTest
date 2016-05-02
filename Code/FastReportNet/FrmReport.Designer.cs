namespace FastReportNet
{
    partial class FrmReport
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReport));
            this.report1 = new FastReport.Report();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Design Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(319, 264);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "View Report";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 428);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FrmReport";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastReport.Report report1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

