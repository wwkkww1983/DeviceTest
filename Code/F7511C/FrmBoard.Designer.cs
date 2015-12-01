namespace F7511C
{
    partial class FrmBoard
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
            this.Enable_Button = new System.Windows.Forms.Button();
            this.WDT_Number = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Disable_Button = new System.Windows.Forms.Button();
            this.Read_Button = new System.Windows.Forms.Button();
            this.WDT_GroupBox = new System.Windows.Forms.GroupBox();
            this.DI_GroupBox = new System.Windows.Forms.GroupBox();
            this.DI8 = new System.Windows.Forms.CheckBox();
            this.DI7 = new System.Windows.Forms.CheckBox();
            this.DI6 = new System.Windows.Forms.CheckBox();
            this.DI5 = new System.Windows.Forms.CheckBox();
            this.DI4 = new System.Windows.Forms.CheckBox();
            this.DI3 = new System.Windows.Forms.CheckBox();
            this.DI2 = new System.Windows.Forms.CheckBox();
            this.DI1 = new System.Windows.Forms.CheckBox();
            this.Write_Button = new System.Windows.Forms.Button();
            this.DO_GroupBox = new System.Windows.Forms.GroupBox();
            this.DO1 = new System.Windows.Forms.CheckBox();
            this.DO2 = new System.Windows.Forms.CheckBox();
            this.DO3 = new System.Windows.Forms.CheckBox();
            this.DO4 = new System.Windows.Forms.CheckBox();
            this.DO5 = new System.Windows.Forms.CheckBox();
            this.DO6 = new System.Windows.Forms.CheckBox();
            this.DO7 = new System.Windows.Forms.CheckBox();
            this.DO8 = new System.Windows.Forms.CheckBox();
            this.WDT_GroupBox.SuspendLayout();
            this.DI_GroupBox.SuspendLayout();
            this.DO_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Enable_Button
            // 
            this.Enable_Button.Location = new System.Drawing.Point(10, 86);
            this.Enable_Button.Name = "Enable_Button";
            this.Enable_Button.Size = new System.Drawing.Size(67, 25);
            this.Enable_Button.TabIndex = 2;
            this.Enable_Button.Text = "Enable";
            this.Enable_Button.Click += new System.EventHandler(this.Enable_Button_Click);
            // 
            // WDT_Number
            // 
            this.WDT_Number.Location = new System.Drawing.Point(67, 34);
            this.WDT_Number.MaxLength = 10;
            this.WDT_Number.Name = "WDT_Number";
            this.WDT_Number.Size = new System.Drawing.Size(58, 21);
            this.WDT_Number.TabIndex = 1;
            this.WDT_Number.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timer:";
            // 
            // Disable_Button
            // 
            this.Disable_Button.Location = new System.Drawing.Point(86, 86);
            this.Disable_Button.Name = "Disable_Button";
            this.Disable_Button.Size = new System.Drawing.Size(68, 25);
            this.Disable_Button.TabIndex = 2;
            this.Disable_Button.Text = "Disable";
            this.Disable_Button.Click += new System.EventHandler(this.Disable_Button_Click);
            // 
            // Read_Button
            // 
            this.Read_Button.Location = new System.Drawing.Point(357, 37);
            this.Read_Button.Name = "Read_Button";
            this.Read_Button.Size = new System.Drawing.Size(48, 26);
            this.Read_Button.TabIndex = 23;
            this.Read_Button.Text = "Read";
            this.Read_Button.Click += new System.EventHandler(this.Read_Button_Click);
            // 
            // WDT_GroupBox
            // 
            this.WDT_GroupBox.Controls.Add(this.Enable_Button);
            this.WDT_GroupBox.Controls.Add(this.WDT_Number);
            this.WDT_GroupBox.Controls.Add(this.label1);
            this.WDT_GroupBox.Controls.Add(this.Disable_Button);
            this.WDT_GroupBox.Location = new System.Drawing.Point(415, 12);
            this.WDT_GroupBox.Name = "WDT_GroupBox";
            this.WDT_GroupBox.Size = new System.Drawing.Size(163, 146);
            this.WDT_GroupBox.TabIndex = 22;
            this.WDT_GroupBox.TabStop = false;
            this.WDT_GroupBox.Text = "WDT";
            // 
            // DI_GroupBox
            // 
            this.DI_GroupBox.Controls.Add(this.DI8);
            this.DI_GroupBox.Controls.Add(this.DI7);
            this.DI_GroupBox.Controls.Add(this.DI6);
            this.DI_GroupBox.Controls.Add(this.DI5);
            this.DI_GroupBox.Controls.Add(this.DI4);
            this.DI_GroupBox.Controls.Add(this.DI3);
            this.DI_GroupBox.Controls.Add(this.DI2);
            this.DI_GroupBox.Controls.Add(this.DI1);
            this.DI_GroupBox.Location = new System.Drawing.Point(12, 12);
            this.DI_GroupBox.Name = "DI_GroupBox";
            this.DI_GroupBox.Size = new System.Drawing.Size(336, 69);
            this.DI_GroupBox.TabIndex = 12;
            this.DI_GroupBox.TabStop = false;
            this.DI_GroupBox.Text = "DI";
            // 
            // DI8
            // 
            this.DI8.Location = new System.Drawing.Point(19, 26);
            this.DI8.Name = "DI8";
            this.DI8.Size = new System.Drawing.Size(38, 26);
            this.DI8.TabIndex = 0;
            this.DI8.Text = "8";
            // 
            // DI7
            // 
            this.DI7.Location = new System.Drawing.Point(58, 26);
            this.DI7.Name = "DI7";
            this.DI7.Size = new System.Drawing.Size(38, 26);
            this.DI7.TabIndex = 0;
            this.DI7.Text = "7";
            // 
            // DI6
            // 
            this.DI6.Location = new System.Drawing.Point(96, 26);
            this.DI6.Name = "DI6";
            this.DI6.Size = new System.Drawing.Size(38, 26);
            this.DI6.TabIndex = 0;
            this.DI6.Text = "6";
            // 
            // DI5
            // 
            this.DI5.Location = new System.Drawing.Point(134, 26);
            this.DI5.Name = "DI5";
            this.DI5.Size = new System.Drawing.Size(38, 26);
            this.DI5.TabIndex = 0;
            this.DI5.Text = "5";
            // 
            // DI4
            // 
            this.DI4.Location = new System.Drawing.Point(173, 26);
            this.DI4.Name = "DI4";
            this.DI4.Size = new System.Drawing.Size(38, 26);
            this.DI4.TabIndex = 0;
            this.DI4.Text = "4";
            // 
            // DI3
            // 
            this.DI3.Location = new System.Drawing.Point(211, 26);
            this.DI3.Name = "DI3";
            this.DI3.Size = new System.Drawing.Size(38, 26);
            this.DI3.TabIndex = 0;
            this.DI3.Text = "3";
            // 
            // DI2
            // 
            this.DI2.Location = new System.Drawing.Point(250, 26);
            this.DI2.Name = "DI2";
            this.DI2.Size = new System.Drawing.Size(38, 26);
            this.DI2.TabIndex = 0;
            this.DI2.Text = "2";
            // 
            // DI1
            // 
            this.DI1.Location = new System.Drawing.Point(288, 26);
            this.DI1.Name = "DI1";
            this.DI1.Size = new System.Drawing.Size(38, 26);
            this.DI1.TabIndex = 0;
            this.DI1.Text = "1";
            // 
            // Write_Button
            // 
            this.Write_Button.Location = new System.Drawing.Point(357, 115);
            this.Write_Button.Name = "Write_Button";
            this.Write_Button.Size = new System.Drawing.Size(48, 26);
            this.Write_Button.TabIndex = 24;
            this.Write_Button.Text = "Write";
            this.Write_Button.Click += new System.EventHandler(this.Write_Button_Click);
            // 
            // DO_GroupBox
            // 
            this.DO_GroupBox.Controls.Add(this.DO6);
            this.DO_GroupBox.Controls.Add(this.DO7);
            this.DO_GroupBox.Controls.Add(this.DO8);
            this.DO_GroupBox.Controls.Add(this.DO4);
            this.DO_GroupBox.Controls.Add(this.DO5);
            this.DO_GroupBox.Controls.Add(this.DO2);
            this.DO_GroupBox.Controls.Add(this.DO3);
            this.DO_GroupBox.Controls.Add(this.DO1);
            this.DO_GroupBox.Location = new System.Drawing.Point(12, 87);
            this.DO_GroupBox.Name = "DO_GroupBox";
            this.DO_GroupBox.Size = new System.Drawing.Size(336, 69);
            this.DO_GroupBox.TabIndex = 13;
            this.DO_GroupBox.TabStop = false;
            this.DO_GroupBox.Text = "DO";
            // 
            // DO1
            // 
            this.DO1.Location = new System.Drawing.Point(288, 29);
            this.DO1.Name = "DO1";
            this.DO1.Size = new System.Drawing.Size(38, 26);
            this.DO1.TabIndex = 7;
            this.DO1.Text = "1";
            // 
            // DO2
            // 
            this.DO2.Location = new System.Drawing.Point(250, 28);
            this.DO2.Name = "DO2";
            this.DO2.Size = new System.Drawing.Size(38, 26);
            this.DO2.TabIndex = 11;
            this.DO2.Text = "2";
            // 
            // DO3
            // 
            this.DO3.Location = new System.Drawing.Point(211, 28);
            this.DO3.Name = "DO3";
            this.DO3.Size = new System.Drawing.Size(38, 26);
            this.DO3.TabIndex = 10;
            this.DO3.Text = "3";
            // 
            // DO4
            // 
            this.DO4.Location = new System.Drawing.Point(173, 28);
            this.DO4.Name = "DO4";
            this.DO4.Size = new System.Drawing.Size(38, 26);
            this.DO4.TabIndex = 13;
            this.DO4.Text = "4";
            // 
            // DO5
            // 
            this.DO5.Location = new System.Drawing.Point(134, 28);
            this.DO5.Name = "DO5";
            this.DO5.Size = new System.Drawing.Size(38, 26);
            this.DO5.TabIndex = 12;
            this.DO5.Text = "5";
            // 
            // DO6
            // 
            this.DO6.Location = new System.Drawing.Point(96, 28);
            this.DO6.Name = "DO6";
            this.DO6.Size = new System.Drawing.Size(38, 26);
            this.DO6.TabIndex = 16;
            this.DO6.Text = "6";
            // 
            // DO7
            // 
            this.DO7.Location = new System.Drawing.Point(57, 28);
            this.DO7.Name = "DO7";
            this.DO7.Size = new System.Drawing.Size(39, 26);
            this.DO7.TabIndex = 14;
            this.DO7.Text = "7";
            // 
            // DO8
            // 
            this.DO8.Location = new System.Drawing.Point(19, 28);
            this.DO8.Name = "DO8";
            this.DO8.Size = new System.Drawing.Size(38, 26);
            this.DO8.TabIndex = 15;
            this.DO8.Text = "8";
            // 
            // FrmBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 168);
            this.Controls.Add(this.DO_GroupBox);
            this.Controls.Add(this.Read_Button);
            this.Controls.Add(this.WDT_GroupBox);
            this.Controls.Add(this.DI_GroupBox);
            this.Controls.Add(this.Write_Button);
            this.Name = "FrmBoard";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmBoard_Load);
            this.WDT_GroupBox.ResumeLayout(false);
            this.WDT_GroupBox.PerformLayout();
            this.DI_GroupBox.ResumeLayout(false);
            this.DO_GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Enable_Button;
        private System.Windows.Forms.TextBox WDT_Number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Disable_Button;
        private System.Windows.Forms.Button Read_Button;
        private System.Windows.Forms.GroupBox WDT_GroupBox;
        private System.Windows.Forms.GroupBox DI_GroupBox;
        private System.Windows.Forms.CheckBox DI8;
        private System.Windows.Forms.CheckBox DI7;
        private System.Windows.Forms.CheckBox DI6;
        private System.Windows.Forms.CheckBox DI5;
        private System.Windows.Forms.CheckBox DI4;
        private System.Windows.Forms.CheckBox DI3;
        private System.Windows.Forms.CheckBox DI2;
        private System.Windows.Forms.CheckBox DI1;
        private System.Windows.Forms.Button Write_Button;
        private System.Windows.Forms.GroupBox DO_GroupBox;
        private System.Windows.Forms.CheckBox DO6;
        private System.Windows.Forms.CheckBox DO7;
        private System.Windows.Forms.CheckBox DO8;
        private System.Windows.Forms.CheckBox DO4;
        private System.Windows.Forms.CheckBox DO5;
        private System.Windows.Forms.CheckBox DO2;
        private System.Windows.Forms.CheckBox DO3;
        private System.Windows.Forms.CheckBox DO1;
    }
}

