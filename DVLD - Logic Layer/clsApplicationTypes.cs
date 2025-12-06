using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD___Data_Access_Layer;

namespace DVLD___Logic_Layer
{
    public class clsApplicationTypes
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitel { get; set; }
        public decimal ApplicationFees {  get; set; }

        public clsApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitel, decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitel = ApplicationTypeTitel;
            this.ApplicationFees = ApplicationFees;
        }
        static public DataTable GetApplicationTypes()
        {
            return clsApplicationTypesDataAccess.GetAllApplicationTypes();
        }

        private bool _Update()
        {

            return clsApplicationTypesDataAccess.Update(ApplicationTypeID, ApplicationTypeTitel, ApplicationFees);
        }

        public bool Save()
        {
            return _Update();
        }

        static public clsApplicationTypes FindAppliationTypeByID(int AppTypeID)
        {
            string AppTypetitel = string.Empty;
            decimal Appfees = -1;
            if( clsApplicationTypesDataAccess.FindApplicationTypeByID(AppTypeID, ref AppTypetitel, ref Appfees))
            {
                return new clsApplicationTypes(AppTypeID, AppTypetitel, Appfees);
            }
            else
            {
                return null;
            }
        }
    }
}
