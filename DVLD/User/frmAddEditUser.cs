using DVLD___Logic_Layer;
using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddEditUser : Form
    {
        private clsUser _User;
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

            if (_UserID == -1)
            {
                lblTitle.Text = "Add New User";
                _Mode = _enMode.AddNew;
            }
            else 
            {
                lblTitle.Text = "Update User";
                _Mode = _enMode.Edit;
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

            lblUserID.Text = _UserID.ToString();
            tbUsername.Text = _User.Username;
            tbPassword.Text = _User.Password;
            tbConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;

        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            tabAddUser.SelectedIndex = 1;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _User.PersonID = showPersonInfoWithFilter1.PersonID;
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
