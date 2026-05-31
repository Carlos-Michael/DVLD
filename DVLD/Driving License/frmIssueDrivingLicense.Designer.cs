namespace DVLD
{
    partial class frmIssueDrivingLicense
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.application_Info1 = new DVLD.Application_Info();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.drivngLicenseApplicationInfo1 = new DVLD.DrivngLicenseApplicationInfo();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.application_Info1);
            this.groupBox1.Location = new System.Drawing.Point(12, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Basic Info";
            // 
            // application_Info1
            // 
            this.application_Info1.Location = new System.Drawing.Point(6, 19);
            this.application_Info1.Name = "application_Info1";
            this.application_Info1.Size = new System.Drawing.Size(628, 178);
            this.application_Info1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.drivngLicenseApplicationInfo1);
            this.groupBox2.Location = new System.Drawing.Point(12, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(684, 135);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Driving License Application Info";
            // 
            // drivngLicenseApplicationInfo1
            // 
            this.drivngLicenseApplicationInfo1.Location = new System.Drawing.Point(6, 19);
            this.drivngLicenseApplicationInfo1.Name = "drivngLicenseApplicationInfo1";
            this.drivngLicenseApplicationInfo1.Size = new System.Drawing.Size(628, 107);
            this.drivngLicenseApplicationInfo1.TabIndex = 0;
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(83, 358);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(613, 118);
            this.rtbNotes.TabIndex = 91;
            this.rtbNotes.Text = "";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DVLD.Properties.Resources.Notes_32;
            this.pictureBox9.Location = new System.Drawing.Point(59, 359);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(22, 15);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 93;
            this.pictureBox9.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 361);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 92;
            this.label11.Text = "Notes:";
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::DVLD.Properties.Resources.Close_32;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(456, 503);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 40);
            this.button4.TabIndex = 95;
            this.button4.Text = "Close";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(579, 503);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 40);
            this.btnSave.TabIndex = 94;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmIssueDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 555);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmIssueDrivingLicense";
            this.Text = "Issue Driving License";
            this.Load += new System.EventHandler(this.frmIssueDrivingLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Application_Info application_Info1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DrivngLicenseApplicationInfo drivngLicenseApplicationInfo1;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnSave;
    }
}