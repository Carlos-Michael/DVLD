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
    public partial class frmEditScheduleTest : Form
    {
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        private clsLicenseClasses _LicenseClass;
        private clsTestAppointments _TestAppointment;
        private clsTestTypes _TestType;
        private clsUser _User;
        private clsApplication _Application;
        private clsPeople _Person;
        private enum _enMode { Add, Update}
        private _enMode _Mode { get; set; }

        public frmEditScheduleTest(int TestAppointmentID,int LocalDrivingLicenseApplicationID, int TestTypeID, int UserID, bool IsLocked)
        {
            InitializeComponent();

            if (IsLocked)
            {
                gbTest.Enabled = false;
                gbRetake.Enabled = false;
                btnSave.Enabled = false;             
            }
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationsID(LocalDrivingLicenseApplicationID);
            _LicenseClass = clsLicenseClasses.GetLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID);
            _TestType = clsTestTypes.FindTestTypeByID(TestTypeID);
            _User = clsUser.FindUserWithUserID(UserID);
            _Application = clsApplication.FindApplicationByID(_LocalDrivingLicenseApplication.ApplicationID);
            _Person = clsPeople.FindWithPersonID(_Application.ApplicantPersonID);
            if (TestAppointmentID == -1)
            {
                _Mode = _enMode.Add;
                

            }
            else if (TestAppointmentID != 1)
            {
                _Mode = _enMode.Update;
                _TestAppointment = clsTestAppointments.FindTestAppointmentByID(TestAppointmentID);
                

            }            
        }

        private void frmEditScheduleTest_Load(object sender, EventArgs e)
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
            if (_Mode == _enMode.Add)
            {
                dateTimePicker1.Value = DateTime.Now;
            }
            else
            {                
                dateTimePicker1.Value = _TestAppointment.AppointmentDate;
            }
                dateTimePicker1.MinDate = DateTime.Now;

            gbTest.Text = _TestType.TestTypeTitel;

            if (clsTestAppointments.GetCountOfTestAppointments(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _TestType.TestTypeID, false) != 0)
            {
                gbRetake.Enabled = true;
                if (_Mode == _enMode.Add)
                {
                    retake1.SetData(-1, _TestType.TestTypeID);
                }
                else 
                {
                    retake1.SetData(_TestAppointment.RetakeTestApplictionID, _TestType.TestTypeID);
                }
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {                       
            _TestAppointment = new clsTestAppointments();
                
            _TestAppointment.TestTypeID = _TestType.TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dateTimePicker1.Value;
            _TestAppointment.PaidFees = _TestType.TestTypeFees;
            _TestAppointment.CreatedByUserID = _User.UserID;
            _TestAppointment.IsLocked = false;
            if (gbRetake.Enabled)
            {
                clsApplication RetakeApplication = new clsApplication();
                RetakeApplication.ApplicantPersonID = _Application.ApplicantPersonID;
                RetakeApplication.ApplicationDate = DateTime.Now;
                RetakeApplication.ApplicationStatus = clsApplication.enStatus.New;
                RetakeApplication.LastStatusDate = DateTime.Now;
                RetakeApplication.ApplicationTypeID = 7;
                RetakeApplication.PaidFees = clsApplicationTypes.FindAppliationTypeByID(7).ApplicationFees;
                RetakeApplication.CreatedByUserID = _User.UserID;
                if (RetakeApplication.Save())
                {
                    _TestAppointment.RetakeTestApplictionID = RetakeApplication.ApplicationID;
                }
                else
                { 
                    _TestAppointment.RetakeTestApplictionID = -1;
                }
            }
            else
            {
                    _TestAppointment.RetakeTestApplictionID = -1;
            }
            if (_TestAppointment.Save())
            {
                MessageBox.Show("Appointment Schedule Successfully", "Appointment Scheduled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (gbRetake.Enabled)
                {
                    retake1.SetData(_TestAppointment.RetakeTestApplictionID, _TestType.TestTypeID);
                }
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Appointment Schedule Faild", "Appointment Schedule Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
