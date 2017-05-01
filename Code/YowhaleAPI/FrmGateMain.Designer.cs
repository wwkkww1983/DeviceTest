namespace MeetingClient
{
    partial class FrmGateMain
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
            this.bteMeeting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVisitor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bteMeeting
            // 
            this.bteMeeting.Location = new System.Drawing.Point(52, 38);
            this.bteMeeting.Name = "bteMeeting";
            this.bteMeeting.Size = new System.Drawing.Size(87, 33);
            this.bteMeeting.TabIndex = 0;
            this.bteMeeting.Text = "会议室";
            this.bteMeeting.UseVisualStyleBackColor = true;
            this.bteMeeting.Click += new System.EventHandler(this.btnMeeting_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(35, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 55);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVisitor
            // 
            this.btnVisitor.Location = new System.Drawing.Point(234, 38);
            this.btnVisitor.Name = "btnVisitor";
            this.btnVisitor.Size = new System.Drawing.Size(87, 33);
            this.btnVisitor.TabIndex = 2;
            this.btnVisitor.Text = "访客";
            this.btnVisitor.UseVisualStyleBackColor = true;
            this.btnVisitor.Click += new System.EventHandler(this.btnVisitor_Click);
            // 
            // FrmGateMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 150);
            this.Controls.Add(this.btnVisitor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bteMeeting);
            this.Name = "FrmGateMain";
            this.Text = "道闸控制系统";
            this.Load += new System.EventHandler(this.FrmGateMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bteMeeting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVisitor;
    }
}

