namespace QRCodePrint
{
    partial class FrmHenglsterPrinter
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
            this.btnPrinterEnum = new System.Windows.Forms.Button();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.btnOpenPrinter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrinterEnum
            // 
            this.btnPrinterEnum.Location = new System.Drawing.Point(53, 12);
            this.btnPrinterEnum.Name = "btnPrinterEnum";
            this.btnPrinterEnum.Size = new System.Drawing.Size(86, 29);
            this.btnPrinterEnum.TabIndex = 0;
            this.btnPrinterEnum.Text = "查找打印机";
            this.btnPrinterEnum.UseVisualStyleBackColor = true;
            this.btnPrinterEnum.Click += new System.EventHandler(this.btnPrinterEnum_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(145, 17);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(121, 20);
            this.cmbPrinters.TabIndex = 1;
            // 
            // btnOpenPrinter
            // 
            this.btnOpenPrinter.Location = new System.Drawing.Point(53, 47);
            this.btnOpenPrinter.Name = "btnOpenPrinter";
            this.btnOpenPrinter.Size = new System.Drawing.Size(86, 29);
            this.btnOpenPrinter.TabIndex = 2;
            this.btnOpenPrinter.Text = "打开打印机";
            this.btnOpenPrinter.UseVisualStyleBackColor = true;
            this.btnOpenPrinter.Click += new System.EventHandler(this.btnOpenPrinter_Click);
            // 
            // FrmHenglsterPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 350);
            this.Controls.Add(this.btnOpenPrinter);
            this.Controls.Add(this.cmbPrinters);
            this.Controls.Add(this.btnPrinterEnum);
            this.Name = "FrmHenglsterPrinter";
            this.Text = "亨士乐打印机";
            this.Load += new System.EventHandler(this.FrmHenglsterPrinter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrinterEnum;
        private System.Windows.Forms.ComboBox cmbPrinters;
        private System.Windows.Forms.Button btnOpenPrinter;
    }
}