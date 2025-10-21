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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (clsUser.Login(tbUsername.Text, tbPassword.Text))
            {
                Form frmHomeScreen = new Form1();
                this.Hide();
                frmHomeScreen.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Login Faild Username or Password Is Incorrect", "Login Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
