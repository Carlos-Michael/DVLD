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
    public partial class frmTestAppointments : Form
    {
        private clsTestTypes _TestType;
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        private clsUser _User;
        public frmTestAppointments(int TestTypeID, int LocalDrivingLicenseID, int UserID)
        {
            InitializeComponent();

            _TestType = clsTestTypes.FindTestTypeByID(TestTypeID);
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationsID(LocalDrivingLicenseID);
            _User = clsUser.FindUserWithUserID(UserID);
        }

        private void _Refresh()
        {
            dgvAppointments.DataSource = clsTestAppointments.GetTestAppointmentsWithLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _TestType.TestTypeID);
            if (dgvAppointments.ColumnCount > 0)
            {
                dgvAppointments.Columns[0].HeaderText = "Test Appointment ID";
                dgvAppointments.Columns[1].HeaderText = "Local Driving ID";
                dgvAppointments.Columns[2].HeaderText = "Test Type Titel";
                dgvAppointments.Columns[3].HeaderText = "Class Name";
                dgvAppointments.Columns[4].HeaderText = "Appointment Date";
                dgvAppointments.Columns[5].HeaderText = "Paid Fees";
                dgvAppointments.Columns[6].HeaderText = "Full Name";
                dgvAppointments.Columns[7].HeaderText = "Is Locked";
            }
            lblRecords.Text = dgvAppointments.RowCount.ToString();
        }
        private void frmTestAppointments_Load(object sender, EventArgs e)
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

            drivngLicenseApplicationInfo1.SetData(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
            application_Info1.SetData(_LocalDrivingLicenseApplication.ApplicationID);
            _Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!clsTestAppointments.IsExist(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _TestType.TestTypeID, false) && clsTestAppointments.GetCountOfTestAppointments(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _TestType.TestTypeID, true) != 1)
            {
                frmEditScheduleTest editScheduleTest = new frmEditScheduleTest(-1, _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _TestType.TestTypeID, _User.UserID, false);
                editScheduleTest.ShowDialog();
                dgvAppointments.DataSource = clsTestAppointments.GetTestAppointmentsWithLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _TestType.TestTypeID);
            }
            else if (clsTestAppointments.GetCountOfTestAppointments(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _TestType.TestTypeID, true) == 1)
            {
                MessageBox.Show("Person Have Passed The Test Successfully", "TestPassed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Person Already have an active appointment for this test", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditScheduleTest editScheduleTest = new frmEditScheduleTest((int)dgvAppointments.CurrentRow.Cells[0].Value, _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _TestType.TestTypeID, _User.UserID, (bool)(dgvAppointments.CurrentRow.Cells[3].Value));
            editScheduleTest.ShowDialog();
            dgvAppointments.DataSource = clsTestAppointments.GetTestAppointmentsWithLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _TestType.TestTypeID);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((bool)(dgvAppointments.CurrentRow.Cells[3].Value) == false)
            {
                frmTakeTest takeTest = new frmTakeTest((int)(dgvAppointments.CurrentRow.Cells[0].Value), _User.UserID);
                takeTest.ShowDialog();
                _Refresh();
            }
        }
    }
}
