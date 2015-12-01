namespace QRCode
{
    partial class FrmQRCode
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
            this.btnEncode = new System.Windows.Forms.Button();
            this.txtEncodeInfo = new System.Windows.Forms.TextBox();
            this.txtDecodeInfo = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ckbEncode = new System.Windows.Forms.CheckBox();
            this.txtSourceStr = new System.Windows.Forms.TextBox();
            this.btnQRImage = new System.Windows.Forms.Button();
            this.ckbLogo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(24, 14);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(75, 23);
            this.btnEncode.TabIndex = 0;
            this.btnEncode.Text = "生成二维码";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // txtEncodeInfo
            // 
            this.txtEncodeInfo.Location = new System.Drawing.Point(105, 14);
            this.txtEncodeInfo.Name = "txtEncodeInfo";
            this.txtEncodeInfo.Size = new System.Drawing.Size(400, 21);
            this.txtEncodeInfo.TabIndex = 1;
            // 
            // txtDecodeInfo
            // 
            this.txtDecodeInfo.Location = new System.Drawing.Point(105, 378);
            this.txtDecodeInfo.Name = "txtDecodeInfo";
            this.txtDecodeInfo.ReadOnly = true;
            this.txtDecodeInfo.Size = new System.Drawing.Size(400, 21);
            this.txtDecodeInfo.TabIndex = 3;
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(24, 391);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 23);
            this.btnDecode.TabIndex = 2;
            this.btnDecode.Text = "解码二维码";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(140, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ckbEncode
            // 
            this.ckbEncode.AutoSize = true;
            this.ckbEncode.Location = new System.Drawing.Point(51, 47);
            this.ckbEncode.Name = "ckbEncode";
            this.ckbEncode.Size = new System.Drawing.Size(48, 16);
            this.ckbEncode.TabIndex = 5;
            this.ckbEncode.Text = "加密";
            this.ckbEncode.UseVisualStyleBackColor = true;
            // 
            // txtSourceStr
            // 
            this.txtSourceStr.Location = new System.Drawing.Point(105, 405);
            this.txtSourceStr.Name = "txtSourceStr";
            this.txtSourceStr.ReadOnly = true;
            this.txtSourceStr.Size = new System.Drawing.Size(400, 21);
            this.txtSourceStr.TabIndex = 7;
            // 
            // btnQRImage
            // 
            this.btnQRImage.Location = new System.Drawing.Point(24, 182);
            this.btnQRImage.Name = "btnQRImage";
            this.btnQRImage.Size = new System.Drawing.Size(75, 23);
            this.btnQRImage.TabIndex = 8;
            this.btnQRImage.Text = "选择图片";
            this.btnQRImage.UseVisualStyleBackColor = true;
            this.btnQRImage.Click += new System.EventHandler(this.btnQRImage_Click);
            // 
            // ckbLogo
            // 
            this.ckbLogo.AutoSize = true;
            this.ckbLogo.Location = new System.Drawing.Point(51, 69);
            this.ckbLogo.Name = "ckbLogo";
            this.ckbLogo.Size = new System.Drawing.Size(48, 16);
            this.ckbLogo.TabIndex = 9;
            this.ckbLogo.Text = "Logo";
            this.ckbLogo.UseVisualStyleBackColor = true;
            // 
            // FrmQRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 435);
            this.Controls.Add(this.ckbLogo);
            this.Controls.Add(this.btnQRImage);
            this.Controls.Add(this.txtSourceStr);
            this.Controls.Add(this.ckbEncode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDecodeInfo);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.txtEncodeInfo);
            this.Controls.Add(this.btnEncode);
            this.Name = "FrmQRCode";
            this.Text = "二维码";
            this.Load += new System.EventHandler(this.FrmQRCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.TextBox txtEncodeInfo;
        private System.Windows.Forms.TextBox txtDecodeInfo;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ckbEncode;
        private System.Windows.Forms.TextBox txtSourceStr;
        private System.Windows.Forms.Button btnQRImage;
        private System.Windows.Forms.CheckBox ckbLogo;
    }
}

