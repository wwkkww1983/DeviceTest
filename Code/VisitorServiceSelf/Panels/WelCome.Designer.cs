namespace VisitorServiceSelf.Panels
{
    partial class WelCome
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxAdvert1 = new VisitorServiceSelf.Panels.PictureBoxAdvert();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdvert1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(178, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎使用自助系统";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBoxAdvert1
            // 
            this.pictureBoxAdvert1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxAdvert1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxAdvert1.Location = new System.Drawing.Point(29, 130);
            this.pictureBoxAdvert1.Name = "pictureBoxAdvert1";
            this.pictureBoxAdvert1.Size = new System.Drawing.Size(654, 374);
            this.pictureBoxAdvert1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAdvert1.TabIndex = 1;
            this.pictureBoxAdvert1.TabStop = false;
            // 
            // WelCome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxAdvert1);
            this.Controls.Add(this.label1);
            this.Name = "WelCome";
            this.Size = new System.Drawing.Size(718, 566);
            this.Load += new System.EventHandler(this.WelCome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdvert1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private PictureBoxAdvert pictureBoxAdvert1;
    }
}
