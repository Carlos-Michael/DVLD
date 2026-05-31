using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD___Data_Access_Layer;
using System.Threading;

namespace DVLD___Logic_Layer
{
    public class clsTestAppointments
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID {get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }    
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplictionID { get; set; }
        private enum _enMode { Add, Update}
        private _enMode _Mode { get; set; }

        public clsTestAppointments()
        {
            TestAppointmentID = -1;
            TestTypeID = 1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplictionID = -1;
            _Mode = _enMode.Add;

        }

        public clsTestAppointments(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplictionID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this. AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplictionID = RetakeTestApplictionID;
            _Mode = _enMode.Update;
        }

        static public DataTable GetTestAppointmentsWithLocalDrivingLicenseApplicationID(int ID, int TestTypeID)
        {
            return clsTestAppointmentDataAccess.GetTestAppointmentsWithApplicationID(ID, TestTypeID);
        }

        static public int GetCountOfTestAppointments(int LocalDrivingLicenseApplicationID, int TestTypeID, bool TestResult)
        {
            return clsTestAppointmentDataAccess.GetCountOfTestAppointment(LocalDrivingLicenseApplicationID, TestTypeID, TestResult);
        }

        private bool Add()
        {
            this.TestAppointmentID = clsTestAppointmentDataAccess.SchudleAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplictionID);
            return (TestAppointmentID > -1);

        }

        public static bool IsExist(int ID, int TestTypeID, bool IsLocked)
        {
            return clsTestAppointmentDataAccess.IsExist(ID, TestTypeID, IsLocked);
        }

        public static clsTestAppointments FindTestAppointmentByID(int ID)
        {
            int testTypeID = 1;
            int localDrivingLicenseApplicationID = -1;
            DateTime appointmentDate = DateTime.Now;
            decimal paidFees = -1;
            int createdByUserID = -1;
            bool isLocked = false;
            int retakeTestApplictionID = -1;

            if (clsTestAppointmentDataAccess.FindTestAppointmentByID(ID, ref testTypeID, ref localDrivingLicenseApplicationID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked, ref retakeTestApplictionID))
            {
                return new clsTestAppointments(ID, testTypeID, localDrivingLicenseApplicationID, appointmentDate, paidFees, createdByUserID, isLocked, retakeTestApplictionID);
            }
            else
            {
                return null;
            }
        }

        private bool _Update()
        {
            return clsTestAppointmentDataAccess.Update(this.TestAppointmentID, this.AppointmentDate);
        }
        public bool Save()
        { 
            switch (_Mode)
            {
                case _enMode.Add:
                    return Add();
                case _enMode.Update:
                    return _Update();
                    default :
                    return false;
            }
        }

        public bool Lock()
        {
            return clsTestAppointmentDataAccess.Lock(this.TestAppointmentID);
        }
    }
}
