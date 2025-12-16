namespace DVLD
{
    partial class ShowPersonInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.mtbFilter = new System.Windows.Forms.MaskedTextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbPersonInfo = new System.Windows.Forms.GroupBox();
            this.showPersonInfo1 = new DVLD.ShowPersonInfo();
            this.gbFilter.SuspendLayout();
            this.gbPersonInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnAddUser);
            this.gbFilter.Controls.Add(this.btnSearchUser);
            this.gbFilter.Controls.Add(this.mtbFilter);
            this.gbFilter.Controls.Add(this.cbFilter);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(707, 55);
            this.gbFilter.TabIndex = 3;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Image = global::DVLD.Properties.Resources.AddPerson_32;
            this.btnAddUser.Location = new System.Drawing.Point(426, 15);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(35, 34);
            this.btnAddUser.TabIndex = 15;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Image = global::DVLD.Properties.Resources.SearchPerson;
            this.btnSearchUser.Location = new System.Drawing.Point(385, 15);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(35, 34);
            this.btnSearchUser.TabIndex = 14;
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // mtbFilter
            // 
            this.mtbFilter.Location = new System.Drawing.Point(210, 24);
            this.mtbFilter.Name = "mtbFilter";
            this.mtbFilter.PromptChar = ' ';
            this.mtbFilter.Size = new System.Drawing.Size(159, 20);
            this.mtbFilter.TabIndex = 13;
            this.mtbFilter.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbFilter.Visible = false;
            // 
            // cbFilter
            // 
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "PersonID",
            "National No"});
            this.cbFilter.Location = new System.Drawing.Point(69, 22);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(135, 21);
            this.cbFilter.TabIndex = 12;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filter By:";
            // 
            // gbPersonInfo
            // 
            this.gbPersonInfo.Controls.Add(this.showPersonInfo1);
            this.gbPersonInfo.Location = new System.Drawing.Point(3, 74);
            this.gbPersonInfo.Name = "gbPersonInfo";
            this.gbPersonInfo.Size = new System.Drawing.Size(707, 235);
            this.gbPersonInfo.TabIndex = 2;
            this.gbPersonInfo.TabStop = false;
            this.gbPersonInfo.Text = "Person Info";
            // 
            // showPersonInfo1
            // 
            this.showPersonInfo1.Location = new System.Drawing.Point(6, 19);
            this.showPersonInfo1.Name = "showPersonInfo1";
            this.showPersonInfo1.Size = new System.Drawing.Size(695, 210);
            this.showPersonInfo1.TabIndex = 0;
            // 
            // ShowPersonInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.gbPersonInfo);
            this.Name = "ShowPersonInfoWithFilter";
            this.Size = new System.Drawing.Size(716, 313);
            this.Load += new System.EventHandler(this.ShowPersonInfoWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.gbPersonInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.MaskedTextBox mtbFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbPersonInfo;
        private ShowPersonInfo showPersonInfo1;
    }
}
