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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
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
            this.cmbPrinters.Size = new System.Drawing.Size(148, 20);
            this.cmbPrinters.TabIndex = 1;
            // 
            // btnOpenPrinter
            // 
            this.btnOpenPrinter.Location = new System.Drawing.Point(53, 55);
            this.btnOpenPrinter.Name = "btnOpenPrinter";
            this.btnOpenPrinter.Size = new System.Drawing.Size(86, 29);
            this.btnOpenPrinter.TabIndex = 2;
            this.btnOpenPrinter.Text = "打开打印机";
            this.btnOpenPrinter.UseVisualStyleBackColor = true;
            this.btnOpenPrinter.Click += new System.EventHandler(this.btnOpenPrinter_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "打印条码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(53, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "打印二维码";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(53, 184);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 29);
            this.button3.TabIndex = 5;
            this.button3.Text = "打印字符";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(145, 98);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 21);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(145, 146);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 21);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(145, 189);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(148, 21);
            this.textBox3.TabIndex = 8;
            // 
            // FrmHenglsterPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 350);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOpenPrinter);
            this.Controls.Add(this.cmbPrinters);
            this.Controls.Add(this.btnPrinterEnum);
            this.Name = "FrmHenglsterPrinter";
            this.Text = "亨士乐打印机";
            this.Load += new System.EventHandler(this.FrmHenglsterPrinter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrinterEnum;
        private System.Windows.Forms.ComboBox cmbPrinters;
        private System.Windows.Forms.Button btnOpenPrinter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}