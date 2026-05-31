namespace DVLD
{
    partial class frmShowDrivingLicensesHistory
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
            this.driving_License_History1 = new DVLD.Driving_License_History();
            this.showPersonInfoWithFilter1 = new DVLD.ShowPersonInfoWithFilter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // driving_License_History1
            // 
            this.driving_License_History1.Location = new System.Drawing.Point(12, 331);
            this.driving_License_History1.Name = "driving_License_History1";
            this.driving_License_History1.Size = new System.Drawing.Size(839, 271);
            this.driving_License_History1.TabIndex = 0;
            // 
            // showPersonInfoWithFilter1
            // 
            this.showPersonInfoWithFilter1.Location = new System.Drawing.Point(135, 12);
            this.showPersonInfoWithFilter1.Name = "showPersonInfoWithFilter1";
            this.showPersonInfoWithFilter1.PersonID = 0;
            this.showPersonInfoWithFilter1.Size = new System.Drawing.Size(716, 313);
            this.showPersonInfoWithFilter1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 313);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmShowDrivingLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 608);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.showPersonInfoWithFilter1);
            this.Controls.Add(this.driving_License_History1);
            this.Name = "frmShowDrivingLicensesHistory";
            this.Text = "frmShowDrivingLicensesHistory";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Driving_License_History driving_License_History1;
        private ShowPersonInfoWithFilter showPersonInfoWithFilter1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}