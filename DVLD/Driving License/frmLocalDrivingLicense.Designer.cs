namespace DVLD
{
    partial class frmLocalDrivingLicense
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvLocalDrivingLicense = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.scheduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visonTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.issuseLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showDriverHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicense)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(309, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(501, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Driving License";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(79, 612);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(14, 13);
            this.lblRecords.TabIndex = 22;
            this.lblRecords.Text = "0";
            // 
            // cbFilter
            // 
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(75, 313);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(135, 21);
            this.cbFilter.TabIndex = 19;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Filter By:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 612);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "# Records:";
            // 
            // dgvLocalDrivingLicense
            // 
            this.dgvLocalDrivingLicense.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicense.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicense.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalDrivingLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicense.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalDrivingLicense.Location = new System.Drawing.Point(12, 340);
            this.dgvLocalDrivingLicense.Name = "dgvLocalDrivingLicense";
            this.dgvLocalDrivingLicense.ReadOnly = true;
            this.dgvLocalDrivingLicense.Size = new System.Drawing.Size(1194, 266);
            this.dgvLocalDrivingLicense.TabIndex = 16;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.toolStripSeparator1,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripSeparator2,
            this.scheduleTestToolStripMenuItem,
            this.toolStripSeparator3,
            this.issuseLicenseToolStripMenuItem,
            this.toolStripSeparator4,
            this.showLicenseToolStripMenuItem,
            this.toolStripSeparator5,
            this.showDriverHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 188);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_32;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Delete_32_2;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Delete_321;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // scheduleTestToolStripMenuItem
            // 
            this.scheduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visonTestToolStripMenuItem,
            this.writenTestToolStripMenuItem,
            this.streetTestToolStripMenuItem});
            this.scheduleTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Schedule_Test_32;
            this.scheduleTestToolStripMenuItem.Name = "scheduleTestToolStripMenuItem";
            this.scheduleTestToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.scheduleTestToolStripMenuItem.Text = "Schedule Test";
            // 
            // visonTestToolStripMenuItem
            // 
            this.visonTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Vision_Test_32;
            this.visonTestToolStripMenuItem.Name = "visonTestToolStripMenuItem";
            this.visonTestToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.visonTestToolStripMenuItem.Text = "Vison Test";
            this.visonTestToolStripMenuItem.Click += new System.EventHandler(this.visonTestToolStripMenuItem_Click);
            // 
            // writenTestToolStripMenuItem
            // 
            this.writenTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Written_Test_32;
            this.writenTestToolStripMenuItem.Name = "writenTestToolStripMenuItem";
            this.writenTestToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.writenTestToolStripMenuItem.Text = "Writen Test";
            this.writenTestToolStripMenuItem.Click += new System.EventHandler(this.writenTestToolStripMenuItem_Click);
            // 
            // streetTestToolStripMenuItem
            // 
            this.streetTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Street_Test_32;
            this.streetTestToolStripMenuItem.Name = "streetTestToolStripMenuItem";
            this.streetTestToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.streetTestToolStripMenuItem.Text = "Street Test";
            this.streetTestToolStripMenuItem.Click += new System.EventHandler(this.streetTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
            // 
            // issuseLicenseToolStripMenuItem
            // 
            this.issuseLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.issuseLicenseToolStripMenuItem.Name = "issuseLicenseToolStripMenuItem";
            this.issuseLicenseToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.issuseLicenseToolStripMenuItem.Text = "Issuse License";
            this.issuseLicenseToolStripMenuItem.Click += new System.EventHandler(this.issuseLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(175, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(175, 6);
            // 
            // showDriverHistoryToolStripMenuItem
            // 
            this.showDriverHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.showDriverHistoryToolStripMenuItem.Name = "showDriverHistoryToolStripMenuItem";
            this.showDriverHistoryToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.showDriverHistoryToolStripMenuItem.Text = "Show Driver History";
            this.showDriverHistoryToolStripMenuItem.Click += new System.EventHandler(this.showDriverHistoryToolStripMenuItem_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "None",
            "New",
            "Canceled",
            "Completed"});
            this.cbStatus.Location = new System.Drawing.Point(216, 314);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(87, 21);
            this.cbStatus.TabIndex = 25;
            this.cbStatus.Visible = false;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::DVLD.Properties.Resources.Close_32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1089, 612);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 40);
            this.button2.TabIndex = 24;
            this.button2.Text = "Close";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = global::DVLD.Properties.Resources.New_Application_64;
            this.btnAdd.Location = new System.Drawing.Point(1114, 267);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 67);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(371, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(377, 228);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.Location = new System.Drawing.Point(216, 314);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(159, 20);
            this.tbFilterBy.TabIndex = 26;
            this.tbFilterBy.TextChanged += new System.EventHandler(this.tbFilterBy_TextChanged);
            this.tbFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterBy_KeyPress);
            // 
            // frmLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 656);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvLocalDrivingLicense);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLocalDrivingLicense";
            this.Text = "frmLocalDrivingLIcense";
            this.Load += new System.EventHandler(this.frmLocalDrivingLIcense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicense)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicense;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visonTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issuseLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem showDriverHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TextBox tbFilterBy;
    }
}