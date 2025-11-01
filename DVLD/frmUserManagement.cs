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
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void _UpdateUsers(DataTable dt)
        {
            dataGridView1.DataSource = dt;
            lblRecords.Text = dataGridView1.RowCount.ToString();

        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            _UpdateUsers(clsUser.GetAllUsers());
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "IsActive")
            {
                mtbFilter.Visible = false;
                cbActive.Visible = true;
                return;
            }
            if (cbFilter.SelectedItem.ToString() != "None")
            {
                mtbFilter.Visible = true;

            }
        }

        private void mtbFilter_TextChanged(object sender, EventArgs e)
        {
            switch (cbFilter.SelectedItem.ToString())
            {
                case "UserID":
                    _UpdateUsers(clsUser.GetUserWithID(mtbFilter.Text));
                    break;

                case "PersonID":
                    _UpdateUsers(clsUser.GetUserWithPersonID(mtbFilter.Text));
                    break;

                case "FullName":
                    _UpdateUsers(clsUser.GetUserWithFullName(mtbFilter.Text));
                    break;
                case "Username":
                    _UpdateUsers(clsUser.GetUserWithUsername(mtbFilter.Text));
                    break;
                default:
                    break;
            }

        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbActive.SelectedItem.ToString() == "All")
            {
                _UpdateUsers(clsUser.GetAllUsers());
            }
            else if (cbActive.SelectedItem.ToString() == "Yes")
            {
                _UpdateUsers(clsUser.GetUsersWithIsActive(true));
            }
            else if (cbActive.SelectedItem.ToString() == "No")
            {
                _UpdateUsers(clsUser.GetUsersWithIsActive(false));
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
