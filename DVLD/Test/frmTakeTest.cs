using DVLD.Properties;
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
    public partial class frmTakeTest : Form
    {
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        private clsLicenseClasses _LicenseClass;
        private clsTestAppointments _TestAppointment;
        private clsTestTypes _TestType;
        private clsUser _User;
        private clsPeople _Person;
        
        public frmTakeTest(int TestAppointmentID, int CreatedByUserID)
        {
            InitializeComponent();
            _TestAppointment = clsTestAppointments.FindTestAppointmentByID(TestAppointmentID);
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationsID(_TestAppointment.LocalDrivingLicenseApplicationID);
            _LicenseClass = clsLicenseClasses.GetLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID);
            _TestType = clsTestTypes.FindTestTypeByID(_TestAppointment.TestTypeID);
            _User = clsUser.FindUserWithUserID(CreatedByUserID);
            _Person = clsPeople.FindWithPersonID(clsApplication.FindApplicationByID(_LocalDrivingLicenseApplication.ApplicationID).ApplicantPersonID);
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            lblTitle.Text = _TestType.TestTypeTitel;

            switch (_TestType.TestTypeID)
            {
                case 1:
                    pbTestImage.Image = Resources.Vision_512;
                    break;
                case 2:
                    pbTestImage.Image = Resources.Written_Test_512;
                    break;
                case 3:
                    pbTestImage.Image = Resources.driving_test_512;
                    break;
            }
            lblAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblClass.Text = _LicenseClass.ClassName;
            lblTrial.Text = clsTestAppointments.GetCountOfTestAppointments(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _TestType.TestTypeID, false).ToString();
            lblFees.Text = _TestType.TestTypeFees.ToString();
            lblName.Text = _Person.FirstName + ' ' + _Person.SecondName + ' ' + _Person.ThirdName + ' ' + _Person.LastName;
            lblDate.Text = _TestAppointment.AppointmentDate.ToShortDateString();
            gbTest.Text = _TestType.TestTypeTitel;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTests Test = new clsTests();

            Test.TestAppointmentID = _TestAppointment.TestAppointmentID;
            Test.TestResult = rbPass.Checked;
            Test.Notes = richTextBox1.Text;
            Test.CreatedByUserID = _User.UserID;

            if (Test.AddNew())
            {
                MessageBox.Show("Test Taked Successfully", "Test Taked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTestID .Text = Test.TestID.ToString();
            }
            _TestAppointment.Lock();
            btnSave.Enabled = false;
        }
    }
}
