using DVLD___Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmUserManagement : Form
    {
        static private DataTable _dtAllUsers  = clsUser.GetAllUsers();
        private DataTable _dtUsers  = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void _RefreshUsers()
        {
            dataGridView1.DataSource = _dtUsers;

            if (dataGridView1.ColumnCount > 0)
            {
                dataGridView1.Columns[0].HeaderText = "User ID";
                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[2].HeaderText = "Full Name";
                dataGridView1.Columns[3].HeaderText = "UserName";
                dataGridView1.Columns[4].HeaderText = "Is Active";
            }

            lblRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            _RefreshUsers();
            cbActive.SelectedIndex = 0;
            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {                
            cbActive.Visible = cbFilter.Text == "Is Active"; 
            tbFilterBy.Visible = cbFilter.Text != "None" && cbFilter.Text != "Is Active" && cbFilter.Text.Trim() !=  "";
            
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            string ColumnFilter;
            switch(cbFilter.Text)
            {
                case "User ID":
                    ColumnFilter = "UserID";
                    break;

                case "Person ID":
                    ColumnFilter = "PersonID";
                    break;

                case "Full Name":
                    ColumnFilter = "FullName";
                    break;
                case "Username":
                    ColumnFilter = "UserName";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

           if (tbFilterBy.Text.Trim() == "" || ColumnFilter == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecords.Text = dataGridView1.RowCount.ToString();
                return;
            }
            if (ColumnFilter == "UserID" || ColumnFilter == "PersonID")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnFilter, tbFilterBy.Text);
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnFilter, tbFilterBy.Text);
            }
            lblRecords.Text = _dtUsers.Rows.Count.ToString();


        }
        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbActive.Text == "All")
            {
                dataGridView1.DataSource = _dtUsers;
                lblRecords.Text = dataGridView1.RowCount.ToString();
                return;
            }
            _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsActive", cbActive.Text == "Yes");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditUser AddUser = new frmAddEditUser(-1);
            AddUser.ShowDialog();
            _RefreshUsers();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You Sure Do You Want To Delete This User ?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (clsUser.Delete((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully", "User Deleted ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _RefreshUsers();
                }
                else
                {
                    MessageBox.Show("User Delete Faild", "User Delete Faild ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo UserInfo = new frmShowUserInfo((int)dataGridView1.CurrentRow.Cells[0].Value, (int)dataGridView1.CurrentRow.Cells[1].Value);
            UserInfo.ShowDialog();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser AddUser = new frmAddEditUser(-1);
            AddUser.ShowDialog();
            _RefreshUsers();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser EditUser = new frmAddEditUser((int)dataGridView1.CurrentRow.Cells[0].Value);
            EditUser.ShowDialog();
            _RefreshUsers();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword((int)dataGridView1.CurrentRow.Cells[0].Value);
            ChangePassword.ShowDialog();
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "User ID" || cbFilter.Text == "Person ID")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
