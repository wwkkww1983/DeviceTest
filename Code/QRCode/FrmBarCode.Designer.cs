namespace QRCode
{
    partial class FrmBarCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtEncodeInfo = new System.Windows.Forms.TextBox();
            this.btnEncode = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEncodeInfo
            // 
            this.txtEncodeInfo.Location = new System.Drawing.Point(97, 30);
            this.txtEncodeInfo.Name = "txtEncodeInfo";
            this.txtEncodeInfo.Size = new System.Drawing.Size(298, 21);
            this.txtEncodeInfo.TabIndex = 3;
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(16, 28);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(75, 23);
            this.btnEncode.TabIndex = 2;
            this.btnEncode.Text = "生成二维码";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(97, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FrmBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 324);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtEncodeInfo);
            this.Controls.Add(this.btnEncode);
            this.Name = "FrmBarCode";
            this.Text = "FrmBarCode";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEncodeInfo;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}