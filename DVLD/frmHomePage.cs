using System;
using System.Windows.Forms;
using DVLD___Logic_Layer;

namespace DVLD
{
    public partial class frmHomePage : Form
    {
        public delegate void LogoutHandler();
        static public event LogoutHandler Logout;

        private clsUser _User;
        public frmHomePage(string Username)
        {
            InitializeComponent();

            _User = clsUser.FindUserWithUserName(Username);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void peopleManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmPeople = new frmPeople();
            frmPeople.Show();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmUser = new frmUserManagement();
            frmUser.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmShowUserInfo userInfo = new frmShowUserInfo(_User.UserID, _User.PersonID);
            userInfo.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(_User.UserID);
            changePassword.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout?.Invoke();
            this.Hide();
        }

        private void frmHomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes applicationTyps = new frmManageApplicationTypes();
            applicationTyps.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes manageTestTypes = new frmManageTestTypes();
            manageTestTypes.ShowDialog();
        }
    }
}
