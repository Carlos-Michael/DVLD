using System;
using System.Windows.Forms;
using DVLD___Logic_Layer;

namespace DVLD
{
    public partial class frmLoginScreen : Form
    {

        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void _RememberMe()
        {
            if (chkRemember.Checked == true)
            {
                Properties.Settings.Default.Username = tbUsername.Text;
                Properties.Settings.Default.Password = tbPassword.Text;

            }
            else
            {
                Properties.Settings.Default.Username = null;
                Properties.Settings.Default.Password = null;
            }
            Properties.Settings.Default.Save();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (clsUser.Login(tbUsername.Text, tbPassword.Text))
            {
                _RememberMe();
                Form frmHomeScreen = new frmHomePage(tbUsername.Text);
                this.Hide();
                frmHomePage.Logout += this.Logout;
                frmHomeScreen.ShowDialog();
                
                

            }
            else
            {
                MessageBox.Show("Login Faild Username or Password Is Incorrect", "Login Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
   
        }

        private void Logout()
        {
            this.Show();
        }
        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            tbUsername.Text = Properties.Settings.Default.Username;
            tbPassword.Text = Properties.Settings.Default.Password;
        }
    }
}
