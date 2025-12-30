using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD___Data_Access_Layer;

namespace DVLD___Logic_Layer
{
    public class clsApplications
    {
        public enum enStatus { New = 1, Canceled = 2, Completed = 3 }
        public int ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        
        public enStatus ApplicationStatus;
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }


        public bool Add()
        {
            ApplicationID = clsApplicationDataAccess.NewApplication(ApplicationPersonID, ApplicationDate, ApplicationTypeID, ((byte)ApplicationStatus), LastStatusDate, PaidFees, CreatedByUserID);
   
            return ApplicationID != -1;
        }

        public static bool Cancel(int AppID)
        {
            return clsApplicationDataAccess.Cancel(AppID);
        }

    }
}
