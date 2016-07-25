namespace QRReader
{
    partial class FrmCodeReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCodeReader));
            this.btnOpen = new System.Windows.Forms.Button();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.rtbCode = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVirtualComPort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(188, 13);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 31);
            this.btnOpen.TabIndex = 19;
            this.btnOpen.Text = "旧串口";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cmbPorts
            // 
            this.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(9, 16);
            this.cmbPorts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(160, 24);
            this.cmbPorts.TabIndex = 18;
            // 
            // rtbCode
            // 
            this.rtbCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCode.Location = new System.Drawing.Point(7, 93);
            this.rtbCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbCode.Name = "rtbCode";
            this.rtbCode.Size = new System.Drawing.Size(968, 528);
            this.rtbCode.TabIndex = 21;
            this.rtbCode.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "二维码：";
            // 
            // btnVirtualComPort
            // 
            this.btnVirtualComPort.Location = new System.Drawing.Point(296, 13);
            this.btnVirtualComPort.Margin = new System.Windows.Forms.Padding(4);
            this.btnVirtualComPort.Name = "btnVirtualComPort";
            this.btnVirtualComPort.Size = new System.Drawing.Size(131, 31);
            this.btnVirtualComPort.TabIndex = 23;
            this.btnVirtualComPort.Text = "新USB(虚拟串口)";
            this.btnVirtualComPort.UseVisualStyleBackColor = true;
            this.btnVirtualComPort.Click += new System.EventHandler(this.btnVirtualComPort_Click);
            // 
            // FrmCodeReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 639);
            this.Controls.Add(this.btnVirtualComPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbCode);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.cmbPorts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmCodeReader";
            this.Text = "Desko-GSRU500-二维码阅读器(RS232)";
            this.Load += new System.EventHandler(this.FrmQRCodeReader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.RichTextBox rtbCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVirtualComPort;
    }
}

