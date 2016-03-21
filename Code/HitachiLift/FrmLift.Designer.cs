namespace HitachiLift
{
    partial class FrmLift
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
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnHand = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cmbFloors = new System.Windows.Forms.ComboBox();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.btnPort = new System.Windows.Forms.Button();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNoCard = new System.Windows.Forms.Button();
            this.btnBaud = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnChangeBaud = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(118, 39);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 0;
            this.btnAuto.Text = "自动派";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnHand
            // 
            this.btnHand.Location = new System.Drawing.Point(118, 68);
            this.btnHand.Name = "btnHand";
            this.btnHand.Size = new System.Drawing.Size(75, 23);
            this.btnHand.TabIndex = 1;
            this.btnHand.Text = "手工派";
            this.btnHand.UseVisualStyleBackColor = true;
            this.btnHand.Click += new System.EventHandler(this.btnHand_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(9, 99);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(921, 406);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // cmbFloors
            // 
            this.cmbFloors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFloors.FormattingEnabled = true;
            this.cmbFloors.Location = new System.Drawing.Point(12, 56);
            this.cmbFloors.Name = "cmbFloors";
            this.cmbFloors.Size = new System.Drawing.Size(100, 20);
            this.cmbFloors.TabIndex = 3;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(3, 20);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(71, 16);
            this.rb1.TabIndex = 4;
            this.rb1.TabStop = true;
            this.rb1.Text = "普通用户";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(80, 20);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(77, 16);
            this.rb2.TabIndex = 5;
            this.rb2.TabStop = true;
            this.rb2.Text = "特殊用户1";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(163, 20);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(77, 16);
            this.rb3.TabIndex = 6;
            this.rb3.TabStop = true;
            this.rb3.Text = "特殊用户2";
            this.rb3.UseVisualStyleBackColor = true;
            // 
            // rb4
            // 
            this.rb4.AutoSize = true;
            this.rb4.Location = new System.Drawing.Point(246, 20);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(77, 16);
            this.rb4.TabIndex = 7;
            this.rb4.TabStop = true;
            this.rb4.Text = "特殊用户2";
            this.rb4.UseVisualStyleBackColor = true;
            // 
            // btnPort
            // 
            this.btnPort.Location = new System.Drawing.Point(118, 10);
            this.btnPort.Name = "btnPort";
            this.btnPort.Size = new System.Drawing.Size(75, 23);
            this.btnPort.TabIndex = 8;
            this.btnPort.Text = "串口";
            this.btnPort.UseVisualStyleBackColor = true;
            this.btnPort.Click += new System.EventHandler(this.btnPort_Click);
            // 
            // cmbPorts
            // 
            this.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(12, 13);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(100, 20);
            this.cmbPorts.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb4);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Location = new System.Drawing.Point(199, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 50);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnNoCard
            // 
            this.btnNoCard.Location = new System.Drawing.Point(6, 20);
            this.btnNoCard.Name = "btnNoCard";
            this.btnNoCard.Size = new System.Drawing.Size(75, 23);
            this.btnNoCard.TabIndex = 11;
            this.btnNoCard.Text = "无卡数据包";
            this.btnNoCard.UseVisualStyleBackColor = true;
            this.btnNoCard.Click += new System.EventHandler(this.btnNoCard_Click);
            // 
            // btnBaud
            // 
            this.btnBaud.Location = new System.Drawing.Point(87, 20);
            this.btnBaud.Name = "btnBaud";
            this.btnBaud.Size = new System.Drawing.Size(75, 23);
            this.btnBaud.TabIndex = 12;
            this.btnBaud.Text = "返回波特率";
            this.btnBaud.UseVisualStyleBackColor = true;
            this.btnBaud.Click += new System.EventHandler(this.btnBaud_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNoCard);
            this.groupBox2.Controls.Add(this.btnBaud);
            this.groupBox2.Location = new System.Drawing.Point(12, 511);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 57);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "闸机->选层器";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnChangeBaud);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(515, 511);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(415, 57);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选层器->闸机";
            // 
            // btnChangeBaud
            // 
            this.btnChangeBaud.Location = new System.Drawing.Point(6, 20);
            this.btnChangeBaud.Name = "btnChangeBaud";
            this.btnChangeBaud.Size = new System.Drawing.Size(75, 23);
            this.btnChangeBaud.TabIndex = 11;
            this.btnChangeBaud.Text = "变更波特率";
            this.btnChangeBaud.UseVisualStyleBackColor = true;
            this.btnChangeBaud.Click += new System.EventHandler(this.btnChangeBaud_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "返回波特率";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FrmLift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 573);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbPorts);
            this.Controls.Add(this.btnPort);
            this.Controls.Add(this.cmbFloors);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnHand);
            this.Controls.Add(this.btnAuto);
            this.Name = "FrmLift";
            this.Text = "电梯";
            this.Load += new System.EventHandler(this.FrmLift_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnHand;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox cmbFloors;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.Button btnPort;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNoCard;
        private System.Windows.Forms.Button btnBaud;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnChangeBaud;
        private System.Windows.Forms.Button button2;
    }
}

