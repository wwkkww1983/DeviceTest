namespace GateTest
{
    partial class FrmGateTest
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
            this.btnOpenGate = new System.Windows.Forms.Button();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenGate
            // 
            this.btnOpenGate.Location = new System.Drawing.Point(508, 20);
            this.btnOpenGate.Name = "btnOpenGate";
            this.btnOpenGate.Size = new System.Drawing.Size(100, 30);
            this.btnOpenGate.TabIndex = 0;
            this.btnOpenGate.Text = "开闸";
            this.btnOpenGate.UseVisualStyleBackColor = true;
            this.btnOpenGate.Click += new System.EventHandler(this.btnOpenGate_Click);
            // 
            // cmbPorts
            // 
            this.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(6, 26);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(89, 20);
            this.cmbPorts.TabIndex = 1;
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(101, 20);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(65, 30);
            this.btnOpenPort.TabIndex = 2;
            this.btnOpenPort.Text = "打开串口";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // rtb
            // 
            this.rtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb.Location = new System.Drawing.Point(6, 68);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(614, 402);
            this.rtb.TabIndex = 3;
            this.rtb.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenGate);
            this.groupBox1.Controls.Add(this.cmbPorts);
            this.groupBox1.Controls.Add(this.btnOpenPort);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 60);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 482);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTest";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开闸测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTest_FormClosing);
            this.Load += new System.EventHandler(this.FrmTest_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenGate;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

