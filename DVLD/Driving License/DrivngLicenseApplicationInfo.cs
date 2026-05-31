using System;
using System.Data;
using System.Windows.Forms;
using DVLD___Logic_Layer;

namespace DVLD
{
    public partial class DrivngLicenseApplicationInfo : UserControl
    {
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        private clsLicenseClasses _LicenseClass;
        public DrivngLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void SetData(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationsID(LocalDrivingLicenseApplicationID);
            _LicenseClass = clsLicenseClasses.GetLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID);
            _LoadData();

        }

        private void _LoadData()
        {

            lblAppID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            lblLicenseClass.Text = _LicenseClass.ClassName;
            lblPassedTests.Text = clsLocalDrivingLicenseApplications.GetPassedTests(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID).ToString() + "/3";
        }


    }
}
