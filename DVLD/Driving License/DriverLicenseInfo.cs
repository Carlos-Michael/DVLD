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
    public partial class DriverLicenseInfo : UserControl
    {
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplications;
        private clsApplication _Application;
        private clsLicenseClasses _LicenseClass;
        private clsLicenses _License;
        private clsPeople _Person;
        public DriverLicenseInfo()
        {
            InitializeComponent();

            
        }

        public void SetData(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationsID(LocalDrivingLicenseApplicationID);
            _Application = clsApplication.FindApplicationByID(_LocalDrivingLicenseApplications.ApplicationID);
            _LicenseClass = clsLicenseClasses.GetLicenseClassByID(_LocalDrivingLicenseApplications.LicenseClassID);
            _License = clsLicenses.FindLicenseByApplicationID(_Application.ApplicationID);
            _Person = clsPeople.FindWithPersonID(_Application.ApplicantPersonID);

            _LoadData();
        }

        private void _LoadData()
        {
            lblClass.Text = _LicenseClass.ClassName;
            lblName.Text = _Person.FirstName + ' ' + _Person.SecondName + ' ' + _Person.ThirdName + ' ' + _Person.LastName;
            lblNationalNo.Text = _Person.NationalNo;
            lblGendor.Text = _Person.Gender == 0 ? "Male" : "Female";
            lblIssuseDate.Text = _License.IssuseDate.ToShortDateString();
            lblNotes.Text = _License.Notes == null ? "Null" : _License.Notes;
            lblIsActive.Text = _License.IsActive ? "True" : "False";
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortTimeString();
            lblIsDetaiend.Text = "False";

            switch (_License.IssuseReason)
            {
                case 1:
                    lblIssuseReason.Text = "Frist Time";
                    break;
                case 2:
                    lblIssuseReason.Text = "Renew";
                    break;
                case 3:
                    lblIssuseReason.Text = "Replacement For Damged";
                    break;
                case 4:
                    lblIssuseReason.Text = "Replacement For Lost";
                    break;
            }
            pbImage.ImageLocation = _Person.ImagePath;
        }
    }
}
