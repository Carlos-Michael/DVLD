using DVLD;
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
    public partial class frmAddNewLocalDrivingLicenseApplication : Form
    {
        private clsUser _CurrentUser;
        private clsLicenseClasses _LicenseClass;
        private clsApplication _Application;
        private clsApplicationTypes _ApplicationType;
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplications;
        public frmAddNewLocalDrivingLicenseApplication(clsUser user)
        {
            InitializeComponent();

            _CurrentUser = user;
            _ApplicationType = clsApplicationTypes.FindAppliationTypeByID(1);
        }

        private void _FillClasses()
        {
            DataTable dt = clsLicenseClasses.GetLicenseClasses();
            foreach (DataRow Row in dt.Rows)
            {
                cbClasses.Items.Add(Row["ClassName"]);
            }
            
        }
        private void _LoadData()
        {
            _FillClasses();

            lblDate.Text = DateTime.Now.ToString();
            lblUser.Text = _CurrentUser.Username;
            lblFees.Text = _ApplicationType.ApplicationFees.ToString();
        }

        private void frmAddNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
            cbClasses.SelectedIndex = 2;
        }

        private void cbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LicenseClass = clsLicenseClasses.GetLicenseClassByClassName(cbClasses.SelectedItem.ToString());

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabNewApplication.SelectedIndex = 1;    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsLicenses.IsExist(clsDrivers.FindDriverByPersonID(showPersonInfoWithFilter1.PersonID).DriverID, _LicenseClass.LicenseClassID))
            {
                MessageBox.Show("Person Already Have License Of This Class");
                return;
            }
            _LocalDrivingLicenseApplications = new clsLocalDrivingLicenseApplications();
            _LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplications.IsExist(showPersonInfoWithFilter1.PersonID, _LicenseClass.LicenseClassID);
            if (_LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID != -1)
            {
                MessageBox.Show($"Choose Another License Class , The selected Person Already \n have an active application for the selected class with id = {_LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Application = new clsApplication();
            _Application.ApplicantPersonID = showPersonInfoWithFilter1.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = _ApplicationType.ApplicationTypeID;
            _Application.ApplicationStatus = clsApplication.enStatus.New;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = _ApplicationType.ApplicationFees;
            _Application.CreatedByUserID = _CurrentUser.UserID;

            if (_Application.Save())
            {
                _LocalDrivingLicenseApplications.ApplicationID = _Application.ApplicationID;
                _LocalDrivingLicenseApplications.LicenseClassID = _LicenseClass.LicenseClassID;

                if (_LocalDrivingLicenseApplications.Add())
                {
                    MessageBox.Show("Local Driving License Application Added Successfully", "Local Driving License Application Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblApplicationID.Text = _LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID.ToString();
                }
                else
                {
                    MessageBox.Show("Local Driving License Application Add Faild", "Local Driving License Application Add Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
