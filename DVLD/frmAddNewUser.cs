using DVLD___Logic_Layer;
using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddNewUser : Form
    {
        private clsUser _User;
        private int _PersonID;
        public frmAddNewUser()
        {
            InitializeComponent();
        }
        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
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
            _User = new clsUser();
            _User.PersonID = _PersonID;
            _User.Username = tbUsername.Text;
            _User.Password = tbPassword.Text;
            _User.IsActive = chkIsActive.Checked;

            if (_User.Save())
            {
                MessageBox.Show("User Saved Successfully", "User Saved", MessageBoxButtons.OK);
                lblUserID.Text = _User.UserID.ToString();
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
