using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD___Logic_Layer;

namespace DVLD
{
    public partial class frmLocalDrivingLicense : Form
    {
        private clsUser _User;
        private static DataTable dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
        public frmLocalDrivingLicense(clsUser User)
        {
            InitializeComponent();

            _User = User;
        }

        private void _RefreshLocalDrivingLicense()
        {
            dgvLocalDrivingLicense.DataSource = dtAllLocalDrivingLicenseApplications;
            if (dgvLocalDrivingLicense.ColumnCount > 0)
            {
                dgvLocalDrivingLicense.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicense.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicense.Columns[2].HeaderText = "National No";
                dgvLocalDrivingLicense.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicense.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicense.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicense.Columns[6].HeaderText = "Status";
            }
            lblRecords.Text = dtAllLocalDrivingLicenseApplications.Rows.Count.ToString();
        }
        private void frmLocalDrivingLIcense_Load(object sender, EventArgs e)
        {
            _RefreshLocalDrivingLicense();
            cbFilter.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNewLocalDrivingLicenseApplication AddNewLocalDrivingLicenseApplication = new frmAddNewLocalDrivingLicenseApplication(_User);
            AddNewLocalDrivingLicenseApplication.ShowDialog();
            _RefreshLocalDrivingLicense();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbStatus.Visible = cbFilter.Text == "Status";
            tbFilterBy.Visible = cbFilter.Text != "None" && cbFilter.Text != "Status" && cbFilter.Text.Trim() != "";
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {           
            string ColumnFilter;
            switch (cbFilter.SelectedItem.ToString())
            {
                case "L.D.L.AppID":
                    ColumnFilter = "LocalDrivingLicenseApplicationID";
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

            if (ColumnFilter == "None" || tbFilterBy.Text.Trim() == "")
            {
                _RefreshLocalDrivingLicense();
            }

            if (ColumnFilter == "LocalDrivingLicenseApplicationID")
            {   
                dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnFilter, tbFilterBy.Text);
            }
            else
            {
                dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnFilter, tbFilterBy.Text);
            }
            lblRecords.Text = dtAllLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "None")
            {
                _RefreshLocalDrivingLicense();
                return;
            }

            dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", "Status", cbStatus.Text);    
            lblRecords.Text = dtAllLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            clsApplication.Cancel(clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationsID((int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value).ApplicationID);
            _RefreshLocalDrivingLicense();
        }

        private void visonTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments testAppiontment = new frmTestAppointments(1, (int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value, _User.UserID);
            testAppiontment.ShowDialog();
            _RefreshLocalDrivingLicense();
        }

        private void writenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments testAppiontment = new frmTestAppointments(2, (int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value, _User.UserID);
            testAppiontment.ShowDialog();
            _RefreshLocalDrivingLicense();
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments testAppiontment = new frmTestAppointments(3, (int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value, _User.UserID);
            testAppiontment.ShowDialog();
            _RefreshLocalDrivingLicense();
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {         
            switch ((int)dgvLocalDrivingLicense.CurrentRow.Cells[5].Value)
            {
                case 0:
                    visonTestToolStripMenuItem.Enabled = true;
                    writenTestToolStripMenuItem.Enabled = false;
                    streetTestToolStripMenuItem.Enabled = false;                    
                    break;
                case 1:
                    visonTestToolStripMenuItem.Enabled = false;
                    writenTestToolStripMenuItem.Enabled = true;
                    streetTestToolStripMenuItem.Enabled = false;                    
                    break;
                case 2:
                    visonTestToolStripMenuItem.Enabled = false;
                    writenTestToolStripMenuItem.Enabled = false;
                    streetTestToolStripMenuItem.Enabled = true;
                    break;
                case 3:
                    visonTestToolStripMenuItem.Enabled = false;
                    writenTestToolStripMenuItem.Enabled = false;
                    streetTestToolStripMenuItem.Enabled = false;
                    issuseLicenseToolStripMenuItem.Enabled = true;
                    break;

            }
            if ((dgvLocalDrivingLicense.CurrentRow.Cells[6].Value).ToString() == "Cancelled")
            {
                visonTestToolStripMenuItem.Enabled = false;
                writenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = false;
                scheduleTestToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = false;
                issuseLicenseToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
            }
            else if ((dgvLocalDrivingLicense.CurrentRow.Cells[6].Value).ToString() == "Completed")
            {
                scheduleTestToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                issuseLicenseToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = true;
            }
            else if ((dgvLocalDrivingLicense.CurrentRow.Cells[6].Value).ToString() == "New")
            {
                scheduleTestToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;                
                showLicenseToolStripMenuItem.Enabled = false;
            }
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Do You Want To Delete Application?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplications.Delete((int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Application Deleted Succefully", "Deleted",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            _RefreshLocalDrivingLicense();
        }

        private void issuseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicense IssueDriving = new frmIssueDrivingLicense((int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value, _User.UserID);
            IssueDriving.ShowDialog();
            _RefreshLocalDrivingLicense();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicense ShowLicense = new frmShowLicense((int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value);
            ShowLicense.ShowDialog();
            _RefreshLocalDrivingLicense();
        }

        private void showDriverHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDrivingLicensesHistory Show = new frmShowDrivingLicensesHistory((int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value);
            Show.ShowDialog();
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "LocalDrivingLicenseApplicationID")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
