using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD___Data_Access_Layer;

namespace DVLD___Logic_Layer
{
    public class clsApplication
    {
        public enum enStatus { New = 1, Cancelled = 2, Completed = 3 }
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }

        public enStatus ApplicationStatus;
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        private enum _enMode { AddNew = 0, Update = 1 }
        private _enMode _Mode;
        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;

            _Mode = _enMode.AddNew;
        }
        public clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate
            , decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = (enStatus)ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = _enMode.Update;
        }

        private bool _Add()
        {
            ApplicationID = clsApplicationDataAccess.NewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ((byte)ApplicationStatus), LastStatusDate, PaidFees, CreatedByUserID);

            return ApplicationID != -1;
        }
        
        public static clsApplication FindApplicationByID(int ApplicationID)
        {
            int applicantPersonID = -1;
            DateTime applicationDate = DateTime.Now;
            int applicationTypeID = -1;
            byte applicationStatus = 0;
            DateTime lastStatusDate = DateTime.Now;
            decimal paidFees = -1;
            int createdByUserID = -1;

            if (clsApplicationDataAccess.FindApplicationByID(ApplicationID, ref applicantPersonID, ref applicationDate, ref applicationTypeID, ref (applicationStatus), ref lastStatusDate, ref paidFees, ref createdByUserID))
            {
                return new clsApplication(ApplicationID, applicantPersonID, applicationDate, applicationTypeID, applicationStatus, lastStatusDate, paidFees, createdByUserID);
            }
            else
            {
                return null;
            }
        }
        private bool _Update()
        {

            return clsApplicationDataAccess.Update(this.ApplicationID, ApplicationDate, ApplicationTypeID, ((byte)ApplicationStatus), LastStatusDate, PaidFees, CreatedByUserID);

        }
        public static bool Cancel(int AppID)
        {

            return clsApplicationDataAccess.Cancel(AppID);

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    return _Add();
                case _enMode.Update:
                    return _Update();
                default:
                    return false;
            }
        }
    }
}