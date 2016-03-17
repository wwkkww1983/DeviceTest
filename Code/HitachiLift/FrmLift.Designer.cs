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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(118, 12);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 0;
            this.btnAuto.Text = "自动派";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnHand
            // 
            this.btnHand.Location = new System.Drawing.Point(118, 41);
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
            this.richTextBox1.Size = new System.Drawing.Size(914, 376);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(199, 16);
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
            this.rb2.Location = new System.Drawing.Point(276, 16);
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
            this.rb3.Location = new System.Drawing.Point(359, 16);
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
            this.rb4.Location = new System.Drawing.Point(442, 16);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(77, 16);
            this.rb4.TabIndex = 7;
            this.rb4.TabStop = true;
            this.rb4.Text = "特殊用户2";
            this.rb4.UseVisualStyleBackColor = true;
            // 
            // FrmLift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 482);
            this.Controls.Add(this.rb4);
            this.Controls.Add(this.rb3);
            this.Controls.Add(this.rb2);
            this.Controls.Add(this.rb1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnHand);
            this.Controls.Add(this.btnAuto);
            this.Name = "FrmLift";
            this.Text = "电梯";
            this.Load += new System.EventHandler(this.FrmLift_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnHand;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb4;
    }
}

