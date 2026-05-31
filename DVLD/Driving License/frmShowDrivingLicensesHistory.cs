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
    public partial class frmShowDrivingLicensesHistory : Form
    {

        public frmShowDrivingLicensesHistory(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();            
            driving_License_History1.SetData(LocalDrivingLicenseApplicationID);
            showPersonInfoWithFilter1.SetData(clsApplication.FindApplicationByID(clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationsID(LocalDrivingLicenseApplicationID).ApplicationID).ApplicantPersonID);
        }

    }
}
