namespace CVR_ID
{
    partial class FrmID
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblNation = new System.Windows.Forms.Label();
            this.lblIdCard = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblSecurity = new System.Windows.Forms.Label();
            this.lblValidDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(263, 113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // lblDept
            // 
            this.lblDept.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblDept.Location = new System.Drawing.Point(12, 257);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(213, 23);
            this.lblDept.TabIndex = 14;
            // 
            // lblAddress
            // 
            this.lblAddress.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblAddress.Location = new System.Drawing.Point(12, 223);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(213, 23);
            this.lblAddress.TabIndex = 13;
            // 
            // lblBirthday
            // 
            this.lblBirthday.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblBirthday.Location = new System.Drawing.Point(12, 189);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(213, 23);
            this.lblBirthday.TabIndex = 12;
            // 
            // lblSex
            // 
            this.lblSex.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblSex.Location = new System.Drawing.Point(12, 155);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(213, 23);
            this.lblSex.TabIndex = 11;
            // 
            // lblNation
            // 
            this.lblNation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblNation.Location = new System.Drawing.Point(12, 121);
            this.lblNation.Name = "lblNation";
            this.lblNation.Size = new System.Drawing.Size(213, 23);
            this.lblNation.TabIndex = 10;
            // 
            // lblIdCard
            // 
            this.lblIdCard.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblIdCard.Location = new System.Drawing.Point(12, 87);
            this.lblIdCard.Name = "lblIdCard";
            this.lblIdCard.Size = new System.Drawing.Size(213, 23);
            this.lblIdCard.TabIndex = 9;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblName.Location = new System.Drawing.Point(12, 53);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(213, 23);
            this.lblName.TabIndex = 8;
            // 
            // cmbPorts
            // 
            this.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(12, 12);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(121, 20);
            this.cmbPorts.TabIndex = 16;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(139, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 17;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblSecurity
            // 
            this.lblSecurity.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblSecurity.Location = new System.Drawing.Point(12, 291);
            this.lblSecurity.Name = "lblSecurity";
            this.lblSecurity.Size = new System.Drawing.Size(213, 23);
            this.lblSecurity.TabIndex = 18;
            // 
            // lblValidDate
            // 
            this.lblValidDate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblValidDate.Location = new System.Drawing.Point(12, 325);
            this.lblValidDate.Name = "lblValidDate";
            this.lblValidDate.Size = new System.Drawing.Size(213, 23);
            this.lblValidDate.TabIndex = 19;
            // 
            // FrmID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 358);
            this.Controls.Add(this.lblValidDate);
            this.Controls.Add(this.lblSecurity);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.cmbPorts);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblBirthday);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblNation);
            this.Controls.Add(this.lblIdCard);
            this.Controls.Add(this.lblName);
            this.Name = "FrmID";
            this.Text = "身份证";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblNation;
        private System.Windows.Forms.Label lblIdCard;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblSecurity;
        private System.Windows.Forms.Label lblValidDate;
    }
}

