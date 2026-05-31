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
    public partial class frmIssueDrivingLicense : Form
    {
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        private clsApplication _Application;
        private clsLicenseClasses _LicenseClass;
        private clsDrivers _Driver;
        private clsUser _User;
        private clsLicenses _License;
        public frmIssueDrivingLicense(int LocalDrivingLicenseApplicationID, int UserID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationsID(LocalDrivingLicenseApplicationID);
            _Application = clsApplication.FindApplicationByID(_LocalDrivingLicenseApplication.ApplicationID);
            _User = clsUser.FindUserWithUserID(UserID);
            _LicenseClass = clsLicenseClasses.GetLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID);            
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            drivngLicenseApplicationInfo1.SetData(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
            application_Info1.SetData(_Application.ApplicationID);
        }

        private bool _AddDriver()
        {
            _Driver = new clsDrivers();

            _Driver.PersonID = _Application.ApplicantPersonID;
            _Driver.CreatedDate = DateTime.Now;
            _Driver.CreatedByUserID = _User.UserID;

            return _Driver._AddNewDriver();
        }

        private bool _IssuseLicense()
        {
            _License = new clsLicenses();

            _License.ApplicationID = _Application.ApplicationID;
            _License.DriverID = _Driver.DriverID;
            _License.LicenseClass = _LocalDrivingLicenseApplication.LicenseClassID;
            _License.IssuseDate = DateTime.Now;
            _License.ExpirationDate = DateTime.Now.AddYears(_LicenseClass.DefaultValidityLength);
            _License.Notes = rtbNotes.Text;
            _License.PaidFees = _Application.PaidFees;
            _License.IsActive = true;
            _License.IssuseReason = 1;
            _License.CreatedByUserID = _User.UserID;

            return _License.IssuseLicense();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_AddDriver())   
            {
                if (_IssuseLicense())
                {
                    if (MessageBox.Show("License Issused Successfully", "Licesne Issused", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        _Application.ApplicationStatus = clsApplication.enStatus.Completed;
                        _Application.Save();
                    }                    
                }
                else
                {
                    if (MessageBox.Show("License Issuse Faild", "Licesne Didn't Issuse", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
