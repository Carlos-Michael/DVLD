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
    public partial class frmManageDrivers : Form
    {
        DataTable dtAllDrivers = clsDrivers.GetAllDrivers();

        private void _Refresh()
        {
            dgvDrivers.DataSource = dtAllDrivers;
            if (dgvDrivers.ColumnCount > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[2].HeaderText = "National No";
                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
            }
            lblRecords.Text = dtAllDrivers.Rows.Count.ToString();
        }
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterBy.Visible = (cbFilter.Text != "None");
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            string ColumnFilter;
            switch (cbFilter.Text)
            {
                case "Driver ID":
                    ColumnFilter = "DriverID";
                    break;

                case "Person ID":
                    ColumnFilter = "PersonID";
                    break;

                case "National No":
                    ColumnFilter = "NationalNo";
                    break;

                case "Full Name":
                    ColumnFilter = "FullName";
                    break;
                default:
                    ColumnFilter = "None";
                    break;
            }

            if (tbFilterBy.Text.Trim() == "" || ColumnFilter == "None")
            {
                dtAllDrivers.DefaultView.RowFilter = "";
                lblRecords.Text = dtAllDrivers.Rows.Count.ToString();
                return;
            }

            if (ColumnFilter == "DriverID" || ColumnFilter == "PersonID")
            {
                dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnFilter, tbFilterBy.Text);
            }
            else
            {
                dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnFilter, tbFilterBy.Text);
            }
            lblRecords.Text = dtAllDrivers.Rows.Count.ToString();
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Driver ID" || cbFilter.Text == "Person ID")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
