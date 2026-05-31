using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD___Data_Access_Layer;

namespace DVLD___Logic_Layer
{
    public class clsDrivers
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }       
        public clsDrivers(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
        }

        public clsDrivers()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
        }

        public bool _AddNewDriver()
        {
            this.DriverID = clsDriversDataAccess.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return (DriverID > 0);
        }

        public static clsDrivers FindDriverByPersonID(int PersonID)
        {
            int driverID = -1;
            int createdByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriversDataAccess.FindDriverByPersonID(PersonID, ref driverID, ref createdByUserID, ref CreatedDate))
            {
                return new clsDrivers(driverID, PersonID, createdByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriversDataAccess.GetAllDrivers();
        }

    }
}

