using DVLD___Data_Access_Layer;
using DVLD___Data_Access_Layer9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Logic_Layer
{
    public class clsLocalDrivingLicenseApplications
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public bool Add()
        {
            LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsDataAccess.AddNewLocalDrivingLicenseApplication(ApplicationID, LicenseClassID);

            return LocalDrivingLicenseApplicationID != -1;
        }

    }
}
