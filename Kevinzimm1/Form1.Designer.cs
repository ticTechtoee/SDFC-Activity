namespace Kevinzimm1
{
    partial class sdfcactivityFrm
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
            this.BtnLoadFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbBoxStaffName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CustomtimePicker = new System.Windows.Forms.DateTimePicker();
            this.CmbActivities = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkNote = new System.Windows.Forms.CheckBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.LblNULL = new System.Windows.Forms.Label();
            this.txtStaffCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMinutesEntry = new System.Windows.Forms.TextBox();
            this.txtNumericInput = new System.Windows.Forms.TextBox();
            this.CustomdatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnLoadFile
            // 
            this.BtnLoadFile.Location = new System.Drawing.Point(13, 13);
            this.BtnLoadFile.Name = "BtnLoadFile";
            this.BtnLoadFile.Size = new System.Drawing.Size(75, 23);
            this.BtnLoadFile.TabIndex = 0;
            this.BtnLoadFile.Text = "Load File";
            this.BtnLoadFile.UseVisualStyleBackColor = true;
            this.BtnLoadFile.Click += new System.EventHandler(this.BtnLoadFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Staff Code";
            // 
            // CmbBoxStaffName
            // 
            this.CmbBoxStaffName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CmbBoxStaffName.FormattingEnabled = true;
            this.CmbBoxStaffName.Location = new System.Drawing.Point(185, 84);
            this.CmbBoxStaffName.Name = "CmbBoxStaffName";
            this.CmbBoxStaffName.Size = new System.Drawing.Size(194, 21);
            this.CmbBoxStaffName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time";
            // 
            // CustomtimePicker
            // 
            this.CustomtimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.CustomtimePicker.Location = new System.Drawing.Point(185, 150);
            this.CustomtimePicker.Name = "CustomtimePicker";
            this.CustomtimePicker.ShowUpDown = true;
            this.CustomtimePicker.Size = new System.Drawing.Size(195, 20);
            this.CustomtimePicker.TabIndex = 3;
            // 
            // CmbActivities
            // 
            this.CmbActivities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CmbActivities.FormattingEnabled = true;
            this.CmbActivities.Location = new System.Drawing.Point(16, 209);
            this.CmbActivities.Name = "CmbActivities";
            this.CmbActivities.Size = new System.Drawing.Size(364, 21);
            this.CmbActivities.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Activities";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Minutes";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(16, 336);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(367, 96);
            this.txtNote.TabIndex = 7;
            this.txtNote.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Note";
            // 
            // chkNote
            // 
            this.chkNote.AutoSize = true;
            this.chkNote.Location = new System.Drawing.Point(117, 478);
            this.chkNote.Name = "chkNote";
            this.chkNote.Size = new System.Drawing.Size(150, 17);
            this.chkNote.TabIndex = 8;
            this.chkNote.Text = "Include Note in Message?";
            this.chkNote.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(15, 527);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(166, 33);
            this.BtnOk.TabIndex = 9;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(213, 527);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(166, 33);
            this.BtnClose.TabIndex = 10;
            this.BtnClose.Text = "CLOSE";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 594);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Last Entry:";
            // 
            // LblNULL
            // 
            this.LblNULL.AutoSize = true;
            this.LblNULL.Location = new System.Drawing.Point(80, 594);
            this.LblNULL.Name = "LblNULL";
            this.LblNULL.Size = new System.Drawing.Size(35, 13);
            this.LblNULL.TabIndex = 18;
            this.LblNULL.Text = "NULL";
            // 
            // txtStaffCode
            // 
            this.txtStaffCode.Location = new System.Drawing.Point(16, 84);
            this.txtStaffCode.Name = "txtStaffCode";
            this.txtStaffCode.Size = new System.Drawing.Size(138, 20);
            this.txtStaffCode.TabIndex = 1;
            this.txtStaffCode.TextChanged += new System.EventHandler(this.txtStaffCode_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(182, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Staff Name";
            // 
            // txtMinutesEntry
            // 
            this.txtMinutesEntry.Location = new System.Drawing.Point(16, 280);
            this.txtMinutesEntry.Name = "txtMinutesEntry";
            this.txtMinutesEntry.Size = new System.Drawing.Size(166, 20);
            this.txtMinutesEntry.TabIndex = 5;
            // 
            // txtNumericInput
            // 
            this.txtNumericInput.Location = new System.Drawing.Point(225, 280);
            this.txtNumericInput.Name = "txtNumericInput";
            this.txtNumericInput.Size = new System.Drawing.Size(154, 20);
            this.txtNumericInput.TabIndex = 6;
            // 
            // CustomdatePicker
            // 
            this.CustomdatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CustomdatePicker.Location = new System.Drawing.Point(16, 150);
            this.CustomdatePicker.Name = "CustomdatePicker";
            this.CustomdatePicker.Size = new System.Drawing.Size(138, 20);
            this.CustomdatePicker.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Date";
            // 
            // sdfcactivityFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 630);
            this.Controls.Add(this.CustomdatePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumericInput);
            this.Controls.Add(this.txtMinutesEntry);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtStaffCode);
            this.Controls.Add(this.LblNULL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.chkNote);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbActivities);
            this.Controls.Add(this.CustomtimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbBoxStaffName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnLoadFile);
            this.MaximizeBox = false;
            this.Name = "sdfcactivityFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activity Tracking";
            this.Load += new System.EventHandler(this.sdfcactivityFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoadFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbBoxStaffName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker CustomtimePicker;
        private System.Windows.Forms.ComboBox CmbActivities;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkNote;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblNULL;
        private System.Windows.Forms.TextBox txtStaffCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMinutesEntry;
        private System.Windows.Forms.TextBox txtNumericInput;
        private System.Windows.Forms.DateTimePicker CustomdatePicker;
        private System.Windows.Forms.Label label4;
    }
}

