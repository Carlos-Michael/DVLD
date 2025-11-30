using DVLD___Logic_Layer;
using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddEditUser : Form
    {
        private clsUser _User;
        private int _PersonID;
        private int _UserID;
        private enum _enMode { AddNew = 0, Edit = 1 }
        private _enMode _Mode;
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }
        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;

            if (_UserID == -1)
            {
                lblTitle.Text = "Add New User";
                _Mode = _enMode.AddNew;
            }
            else 
            {
                lblTitle.Text = "Update User";
                _Mode = _enMode.Edit;
                gbFilter.Enabled = false;
            }
            _LoadData();

        }

        private void _LoadData()
        {
            if (_Mode == _enMode.AddNew)
            {
                _User = new clsUser();
                return;
            }

            _User = clsUser.FindUserWithUserID(_UserID);
            showPersonInfo1.SetData(_User.PersonID);

            lblUserID.Text = _UserID.ToString();
            tbUsername.Text = _User.Username;
            tbPassword.Text = _User.Password;
            tbConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;

            cbFilter.SelectedIndex = 1;
            mtbFilter.Text = _User.PersonID.ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilter.SelectedItem.ToString())
            {
                case "PersonID":
                    mtbFilter.Visible = true;
                    mtbFilter.Mask = "099999";
                    break;
                case "National No":
                    mtbFilter.Visible = true;
                    mtbFilter.Mask = "";
                    break;
                case "None":
                    mtbFilter.Visible = false;
                    break;

            }
        }
        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            if (mtbFilter.Text != "")
            {
                switch (cbFilter.SelectedItem.ToString())
                {
                    case "PersonID":
                        _PersonID = int.Parse(mtbFilter.Text);
                        showPersonInfo1.SetData(_PersonID);
                        break;
                    case "National No":
                        _PersonID = (int)clsPeople.GetPeopleWithNationalNo(mtbFilter.Text).Rows[0][0];
                        showPersonInfo1.SetData(_PersonID);
                        break;
                    case "None":
                        break;

                }
            }
            else
            {
                MessageBox.Show("Enter PersonID Or NationalNo First", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabAddUser.SelectedIndex = 1;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditPerson AddPerson = new frmAddEditPerson(-1);
            AddPerson.DataBack += showPersonInfo1.SetData;
            AddPerson.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _User.PersonID = _PersonID;
            _User.Username = tbUsername.Text;
            _User.Password = tbPassword.Text;
            _User.IsActive = chkIsActive.Checked;

            if (_User.Save())
            {
                MessageBox.Show("User Saved Successfully", "User Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (_Mode == _enMode.AddNew)
                {
                    _UserID = _User.UserID;
                    lblUserID.Text = _UserID.ToString();
                }
            }
            else
            {
                MessageBox.Show("User Save Faild", "User Save Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void tbUsername_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                errorProvider1.SetError((TextBox)sender, "This Field Cannot Be Empty");
                return;
            }

            if (tbPassword.Text != tbConfirmPassword.Text)
            {
                errorProvider1.SetError(tbConfirmPassword, "The Password Not Matched");
            }
        }
    }
}
