using DVLD___Data_Access_Layer;
using DVLD___Data_Access_Layer9;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Logic_Layer
{
    public class clsLocalDrivingLicenseApplications
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLocalDrivingLicenseApplications()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
        }
        public clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }
        public bool Add()
        {
            LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsDataAccess.AddNewLocalDrivingLicenseApplication(ApplicationID, LicenseClassID);

            return LocalDrivingLicenseApplicationID != -1;
        }

        static public int IsExist(int PersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.IsExist(PersonID, LicenseClassID);
        }

        static public DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetAllLocalDrivingLicenseApplications();
        }
        static public int GetPassedTests(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetPassedTests(LocalDrivingLicenseApplicationID);
        }        
        static public clsLocalDrivingLicenseApplications FindLocalDrivingLicenseApplicationsID(int ID)
        {
            int applicationID = -1;
            int licenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationsDataAccess.FindLocalDrivingLicenseApplicationsWithID(ID, ref applicationID, ref licenseClassID))
            {
                return new clsLocalDrivingLicenseApplications(ID, applicationID, licenseClassID);
            }
            else 
            {
                return null;
            }

        }

        static public bool Delete(int ID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.Delete(ID);
        }


    }
}


