using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD___Logic_Layer;

namespace DVLD
{
    public partial class frmLocalDrivingLicense : Form
    {
        private clsUser _User;
        public frmLocalDrivingLicense(clsUser User)
        {
            InitializeComponent();

            _User = User;
        }

        private void _UpdateLocalDrivingLicense(DataTable dataTable)
        {
            dgvLocalDrivingLicense.DataSource = dataTable;
            lblRecords.Text = dataTable.Rows.Count.ToString();
        }
        private void frmLocalDrivingLIcense_Load(object sender, EventArgs e)
        {
            _UpdateLocalDrivingLicense(clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNewLocalDrivingLicenseApplication AddNewLocalDrivingLicenseApplication = new frmAddNewLocalDrivingLicenseApplication(_User);
            AddNewLocalDrivingLicenseApplication.ShowDialog();
            _UpdateLocalDrivingLicense(clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications());
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilter.SelectedItem.ToString())
            {
                case "D.L.AppID":
                    mtbFilter.Visible = true;
                    mtbFilter.Mask = "099999";
                    break;

                case "National No":
                    cbStatus.Visible = false;
                    mtbFilter.Visible = true;
                    mtbFilter.Mask = "";
                    break;

                case "Full Name":
                    cbStatus.Visible = false;
                    mtbFilter.Visible = true;
                    mtbFilter.Mask = "L?????";
                    break;

                case "Status":
                    mtbFilter.Visible = false;
                    cbStatus.Visible = true;
                    cbStatus.SelectedIndex = 0;
                    break;

                case "None":
                    mtbFilter.Visible = false;
                    cbStatus.Visible = false;
                    _UpdateLocalDrivingLicense(clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications());
                    break;

            }
        }

        private void mtbFilter_TextChanged(object sender, EventArgs e)
        {
            if (mtbFilter.Text == "")
            {
                _UpdateLocalDrivingLicense(clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications());
                return;
            }

            switch (cbFilter.SelectedItem.ToString())
            {
                case "D.L.AppID":
                    _UpdateLocalDrivingLicense(clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsWithID(int.Parse(mtbFilter.Text)));
                    break;

                case "National No":
                    _UpdateLocalDrivingLicense(clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsWithNationalNo(mtbFilter.Text));
                    break;

                case "Full Name":
                    _UpdateLocalDrivingLicense(clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsWithFullName(mtbFilter.Text));
                    break;
                
                default:
                    break;

            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbStatus.SelectedItem.ToString())
            {
                case "New":
                    _UpdateLocalDrivingLicense(clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsWithStatus("New"));
                    break;
                case "Cancelled":
                    _UpdateLocalDrivingLicense(clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsWithStatus("Cancelled"));
                    break;
                case "Completed":
                    _UpdateLocalDrivingLicense(clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsWithStatus("Completed"));
                    break;

            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            clsApplications.Cancel(clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationsID((int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value).ApplicationID);
            _UpdateLocalDrivingLicense(clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications());
        }
    }
}
