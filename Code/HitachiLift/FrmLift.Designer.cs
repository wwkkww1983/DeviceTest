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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLift));
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnHand = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.cmbFloors = new System.Windows.Forms.ComboBox();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.btnPort = new System.Windows.Forms.Button();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNoCard = new System.Windows.Forms.Button();
            this.btnBackBaud = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPersion = new System.Windows.Forms.ComboBox();
            this.txtBackCardID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbGateState = new System.Windows.Forms.ComboBox();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.btnBackGateState = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnQueryGateCardPermission = new System.Windows.Forms.Button();
            this.btnQueryGateState = new System.Windows.Forms.Button();
            this.txtConfrmCardID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConfrmPackage = new System.Windows.Forms.Button();
            this.cmbSetBaud = new System.Windows.Forms.ComboBox();
            this.btnChangeBaud = new System.Windows.Forms.Button();
            this.btnQueryPackage = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(118, 51);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 0;
            this.btnAuto.Text = "自动派";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnHand
            // 
            this.btnHand.Location = new System.Drawing.Point(118, 80);
            this.btnHand.Name = "btnHand";
            this.btnHand.Size = new System.Drawing.Size(75, 23);
            this.btnHand.TabIndex = 1;
            this.btnHand.Text = "手工派";
            this.btnHand.UseVisualStyleBackColor = true;
            this.btnHand.Click += new System.EventHandler(this.btnHand_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.Location = new System.Drawing.Point(4, 166);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(843, 389);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.Text = "";
            // 
            // cmbFloors
            // 
            this.cmbFloors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFloors.FormattingEnabled = true;
            this.cmbFloors.Location = new System.Drawing.Point(48, 66);
            this.cmbFloors.Name = "cmbFloors";
            this.cmbFloors.Size = new System.Drawing.Size(64, 20);
            this.cmbFloors.TabIndex = 3;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(10, 17);
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
            this.rb2.Location = new System.Drawing.Point(10, 39);
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
            this.rb3.Location = new System.Drawing.Point(10, 63);
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
            this.rb4.Location = new System.Drawing.Point(10, 88);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(77, 16);
            this.rb4.TabIndex = 7;
            this.rb4.TabStop = true;
            this.rb4.Text = "特殊用户3";
            this.rb4.UseVisualStyleBackColor = true;
            // 
            // btnPort
            // 
            this.btnPort.Location = new System.Drawing.Point(118, 22);
            this.btnPort.Name = "btnPort";
            this.btnPort.Size = new System.Drawing.Size(75, 23);
            this.btnPort.TabIndex = 8;
            this.btnPort.Text = "打开串口";
            this.btnPort.UseVisualStyleBackColor = true;
            this.btnPort.Click += new System.EventHandler(this.btnPort_Click);
            // 
            // cmbPorts
            // 
            this.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(48, 25);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(64, 20);
            this.cmbPorts.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb4);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Location = new System.Drawing.Point(199, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(101, 113);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户类型";
            // 
            // btnNoCard
            // 
            this.btnNoCard.Location = new System.Drawing.Point(163, 17);
            this.btnNoCard.Name = "btnNoCard";
            this.btnNoCard.Size = new System.Drawing.Size(87, 23);
            this.btnNoCard.TabIndex = 11;
            this.btnNoCard.Text = "无卡数据包";
            this.btnNoCard.UseVisualStyleBackColor = true;
            this.btnNoCard.Click += new System.EventHandler(this.btnNoCard_Click);
            // 
            // btnBackBaud
            // 
            this.btnBackBaud.Location = new System.Drawing.Point(163, 43);
            this.btnBackBaud.Name = "btnBackBaud";
            this.btnBackBaud.Size = new System.Drawing.Size(87, 23);
            this.btnBackBaud.TabIndex = 12;
            this.btnBackBaud.Text = "返回波特率";
            this.btnBackBaud.UseVisualStyleBackColor = true;
            this.btnBackBaud.Click += new System.EventHandler(this.btnBaud_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbPersion);
            this.groupBox2.Controls.Add(this.txtBackCardID);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.cmbGateState);
            this.groupBox2.Controls.Add(this.cmbBaud);
            this.groupBox2.Controls.Add(this.btnBackGateState);
            this.groupBox2.Controls.Add(this.btnNoCard);
            this.groupBox2.Controls.Add(this.btnBackBaud);
            this.groupBox2.Location = new System.Drawing.Point(555, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 154);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "闸机->选层器";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "波特率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "闸机状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "权限";
            // 
            // cmbPersion
            // 
            this.cmbPersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersion.FormattingEnabled = true;
            this.cmbPersion.Items.AddRange(new object[] {
            "0 不开闸",
            "1 已开闸",
            "255 开闸异常",
            "12 数据出错"});
            this.cmbPersion.Location = new System.Drawing.Point(64, 126);
            this.cmbPersion.Name = "cmbPersion";
            this.cmbPersion.Size = new System.Drawing.Size(93, 20);
            this.cmbPersion.TabIndex = 19;
            // 
            // txtBackCardID
            // 
            this.txtBackCardID.Location = new System.Drawing.Point(64, 99);
            this.txtBackCardID.Name = "txtBackCardID";
            this.txtBackCardID.Size = new System.Drawing.Size(93, 21);
            this.txtBackCardID.TabIndex = 18;
            this.txtBackCardID.Text = "123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "卡号";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "闸机确认卡片权限";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbGateState
            // 
            this.cmbGateState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGateState.FormattingEnabled = true;
            this.cmbGateState.Items.AddRange(new object[] {
            "0   退出使用",
            "255 正常使用",
            "6   数据出错"});
            this.cmbGateState.Location = new System.Drawing.Point(64, 73);
            this.cmbGateState.Name = "cmbGateState";
            this.cmbGateState.Size = new System.Drawing.Size(93, 20);
            this.cmbGateState.TabIndex = 15;
            // 
            // cmbBaud
            // 
            this.cmbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaud.Location = new System.Drawing.Point(64, 46);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(93, 20);
            this.cmbBaud.TabIndex = 14;
            // 
            // btnBackGateState
            // 
            this.btnBackGateState.Location = new System.Drawing.Point(163, 69);
            this.btnBackGateState.Name = "btnBackGateState";
            this.btnBackGateState.Size = new System.Drawing.Size(87, 23);
            this.btnBackGateState.TabIndex = 13;
            this.btnBackGateState.Text = "闸机返回状态";
            this.btnBackGateState.UseVisualStyleBackColor = true;
            this.btnBackGateState.Click += new System.EventHandler(this.btnBackGateState_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtId);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnQueryGateCardPermission);
            this.groupBox3.Controls.Add(this.btnQueryGateState);
            this.groupBox3.Controls.Add(this.txtConfrmCardID);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnConfrmPackage);
            this.groupBox3.Controls.Add(this.cmbSetBaud);
            this.groupBox3.Controls.Add(this.btnChangeBaud);
            this.groupBox3.Controls.Add(this.btnQueryPackage);
            this.groupBox3.Location = new System.Drawing.Point(306, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 154);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选层器->闸机";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(43, 128);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(75, 21);
            this.txtId.TabIndex = 24;
            this.txtId.Text = "3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "卡号";
            // 
            // btnQueryGateCardPermission
            // 
            this.btnQueryGateCardPermission.Location = new System.Drawing.Point(120, 127);
            this.btnQueryGateCardPermission.Name = "btnQueryGateCardPermission";
            this.btnQueryGateCardPermission.Size = new System.Drawing.Size(110, 23);
            this.btnQueryGateCardPermission.TabIndex = 22;
            this.btnQueryGateCardPermission.Text = "查询闸机卡片权限";
            this.btnQueryGateCardPermission.UseVisualStyleBackColor = true;
            this.btnQueryGateCardPermission.Click += new System.EventHandler(this.btnQueryGateCardPermission_Click);
            // 
            // btnQueryGateState
            // 
            this.btnQueryGateState.Location = new System.Drawing.Point(120, 100);
            this.btnQueryGateState.Name = "btnQueryGateState";
            this.btnQueryGateState.Size = new System.Drawing.Size(110, 23);
            this.btnQueryGateState.TabIndex = 21;
            this.btnQueryGateState.Text = "查询闸机状态";
            this.btnQueryGateState.UseVisualStyleBackColor = true;
            this.btnQueryGateState.Click += new System.EventHandler(this.btnQueryGateState_Click);
            // 
            // txtConfrmCardID
            // 
            this.txtConfrmCardID.Location = new System.Drawing.Point(43, 43);
            this.txtConfrmCardID.Name = "txtConfrmCardID";
            this.txtConfrmCardID.Size = new System.Drawing.Size(75, 21);
            this.txtConfrmCardID.TabIndex = 20;
            this.txtConfrmCardID.Text = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "卡号";
            // 
            // btnConfrmPackage
            // 
            this.btnConfrmPackage.Location = new System.Drawing.Point(120, 41);
            this.btnConfrmPackage.Name = "btnConfrmPackage";
            this.btnConfrmPackage.Size = new System.Drawing.Size(110, 23);
            this.btnConfrmPackage.TabIndex = 16;
            this.btnConfrmPackage.Text = "确认包";
            this.btnConfrmPackage.UseVisualStyleBackColor = true;
            this.btnConfrmPackage.Click += new System.EventHandler(this.btnConfrmPackage_Click);
            // 
            // cmbSetBaud
            // 
            this.cmbSetBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetBaud.FormattingEnabled = true;
            this.cmbSetBaud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbSetBaud.Location = new System.Drawing.Point(43, 73);
            this.cmbSetBaud.Name = "cmbSetBaud";
            this.cmbSetBaud.Size = new System.Drawing.Size(75, 20);
            this.cmbSetBaud.TabIndex = 15;
            // 
            // btnChangeBaud
            // 
            this.btnChangeBaud.Location = new System.Drawing.Point(120, 70);
            this.btnChangeBaud.Name = "btnChangeBaud";
            this.btnChangeBaud.Size = new System.Drawing.Size(110, 23);
            this.btnChangeBaud.TabIndex = 11;
            this.btnChangeBaud.Text = "变更波特率";
            this.btnChangeBaud.UseVisualStyleBackColor = true;
            this.btnChangeBaud.Click += new System.EventHandler(this.btnChangeBaud_Click);
            // 
            // btnQueryPackage
            // 
            this.btnQueryPackage.Location = new System.Drawing.Point(120, 12);
            this.btnQueryPackage.Name = "btnQueryPackage";
            this.btnQueryPackage.Size = new System.Drawing.Size(110, 23);
            this.btnQueryPackage.TabIndex = 12;
            this.btnQueryPackage.Text = "查询包";
            this.btnQueryPackage.UseVisualStyleBackColor = true;
            this.btnQueryPackage.Click += new System.EventHandler(this.btnQueryPackage_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "楼层";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "串口";
            // 
            // FrmLift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 561);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbPorts);
            this.Controls.Add(this.btnPort);
            this.Controls.Add(this.cmbFloors);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnHand);
            this.Controls.Add(this.btnAuto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLift";
            this.Text = "日立电梯派梯测试-Demo";
            this.Load += new System.EventHandler(this.FrmLift_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnHand;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.ComboBox cmbFloors;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.Button btnPort;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNoCard;
        private System.Windows.Forms.Button btnBackBaud;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnChangeBaud;
        private System.Windows.Forms.Button btnQueryPackage;
        private System.Windows.Forms.Button btnBackGateState;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbGateState;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.ComboBox cmbSetBaud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPersion;
        private System.Windows.Forms.TextBox txtBackCardID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfrmPackage;
        private System.Windows.Forms.TextBox txtConfrmCardID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnQueryGateState;
        private System.Windows.Forms.Button btnQueryGateCardPermission;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

