namespace WebCamera
{
    partial class FrmCamera
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
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSnapShot = new System.Windows.Forms.Button();
            this.pbSnap = new System.Windows.Forms.PictureBox();
            this.pbVideo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(12, 12);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "预览";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnSnapShot
            // 
            this.btnSnapShot.Location = new System.Drawing.Point(12, 235);
            this.btnSnapShot.Name = "btnSnapShot";
            this.btnSnapShot.Size = new System.Drawing.Size(75, 23);
            this.btnSnapShot.TabIndex = 2;
            this.btnSnapShot.Text = "抓怕";
            this.btnSnapShot.UseVisualStyleBackColor = true;
            this.btnSnapShot.Click += new System.EventHandler(this.btnSnapShot_Click);
            // 
            // pbSnap
            // 
            this.pbSnap.Location = new System.Drawing.Point(93, 235);
            this.pbSnap.Name = "pbSnap";
            this.pbSnap.Size = new System.Drawing.Size(265, 185);
            this.pbSnap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSnap.TabIndex = 3;
            this.pbSnap.TabStop = false;
            // 
            // pbVideo
            // 
            this.pbVideo.Location = new System.Drawing.Point(93, 12);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(265, 185);
            this.pbVideo.TabIndex = 4;
            this.pbVideo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 5;
            // 
            // FrmCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 432);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbVideo);
            this.Controls.Add(this.pbSnap);
            this.Controls.Add(this.btnSnapShot);
            this.Controls.Add(this.btnPreview);
            this.Name = "FrmCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USB摄像头";
            ((System.ComponentModel.ISupportInitialize)(this.pbSnap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSnapShot;
        private System.Windows.Forms.PictureBox pbSnap;
        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.Label label1;
    }
}