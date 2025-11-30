using DVLD___Logic_Layer;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmChangePassword : Form
    {
        private int _UserID;
        private int _PersonID;
        private clsUser _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadData()
        {
            _User = clsUser.FindUserWithUserID(_UserID);
            _PersonID = _User.PersonID;
            userInfo1.SetData(_UserID);
            showPersonInfo1.SetData(_PersonID);
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (tbCurrentPassword.Text != _User.Password)
            {
                errorProvider1.SetError(tbConfirmPassword, "The Password Not Matched");
            }

            if (((TextBox)sender).Text == "")
            {
                errorProvider1.SetError((TextBox)sender, "This Field Cannot Be Empty");
            }
                
            if (tbPassword.Text != tbConfirmPassword.Text)
            {
                errorProvider1.SetError(tbConfirmPassword, "The Password Not Matched");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbCurrentPassword.Text == _User.Password && tbPassword.Text == tbConfirmPassword.Text)
            {
                _User.Password = tbConfirmPassword.Text;
                if (_User.Save())
                {
                    MessageBox.Show("Password Changed Successfully", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Password Change Faild", "Password Didn\'t Changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
