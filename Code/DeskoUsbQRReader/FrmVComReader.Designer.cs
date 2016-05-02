namespace DeskoUsbQRReader
{
    partial class FrmVComReader
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
            this.rtbCode = new System.Windows.Forms.RichTextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // rtbCode
            // 
            this.rtbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCode.Location = new System.Drawing.Point(7, 38);
            this.rtbCode.Name = "rtbCode";
            this.rtbCode.Size = new System.Drawing.Size(619, 361);
            this.rtbCode.TabIndex = 0;
            this.rtbCode.Text = "";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(135, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 30);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "打开串口";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbPorts
            // 
            this.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(8, 9);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(121, 20);
            this.cmbPorts.TabIndex = 2;
            // 
            // FrmVComReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 408);
            this.Controls.Add(this.cmbPorts);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.rtbCode);
            this.Name = "FrmVComReader";
            this.Text = "Usb 二维码阅读器";
            this.Load += new System.EventHandler(this.FrmVComReader_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbCode;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cmbPorts;
    }
}

