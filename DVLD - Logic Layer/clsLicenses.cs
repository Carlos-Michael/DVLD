using System;
using System.Data;
using DVLD___Data_Access_Layer;

namespace DVLD___Logic_Layer
{
    public class clsLicenses
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssuseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssuseReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicenses()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssuseDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = string.Empty;
            this.PaidFees = -1;
            this.IsActive = false;
            this.IssuseReason = 0;
            this.CreatedByUserID = -1;
        }

        public clsLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssuseDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssuseReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssuseDate = IssuseDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssuseReason = IssuseReason;
            this.CreatedByUserID = CreatedByUserID;
        }

        public bool IssuseLicense()
        {
            this.LicenseID = clsLicensesDataAccess.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssuseDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssuseReason, this.CreatedByUserID);

            return (this.LicenseID > -1);
        }

        public static clsLicenses FindLicenseByApplicationID(int ApplicationID)
        {
            int licenseID = -1;
            int driverID = -1;
            int licenseClass = -1;
            DateTime issuseDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            string notes = string.Empty;
            decimal paidFees = -1;
            bool isActive = false;
            byte issuseReason = 0;
            int createdByUserID = -1;

            if (clsLicensesDataAccess.FindLicenseByApplicationID(ApplicationID, ref licenseID, ref driverID, ref licenseClass, ref issuseDate, ref expirationDate, ref notes, ref paidFees, ref isActive, ref issuseReason, ref createdByUserID))
            {
                return new clsLicenses(licenseID, ApplicationID, driverID, licenseClass, issuseDate, expirationDate, notes, paidFees, isActive, issuseReason, createdByUserID);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExist(int DriverID, int LicenseClassID)
        {
            return clsLicensesDataAccess.IsExist(DriverID, LicenseClassID);
        }

        public static DataTable GetAllLocalDrivingLicense(int DriverID)
        {
            return clsLicensesDataAccess.GetAllLocalDrivingLicenses(DriverID);
        }
    }
}

