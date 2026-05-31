using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD___Data_Access_Layer;

namespace DVLD___Logic_Layer
{
    public class clsLicenseClasses
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }   
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }
        
        public clsLicenseClasses(int LicenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

        }
        static public DataTable GetLicenseClasses()
        {
            return clsLicenseClassesDataAccess.GetLicenseClass();
        }

        static public clsLicenseClasses GetLicenseClassByClassName(string ClassName)
        {
            int licenseClassID = -1;
            string classDescription = string.Empty;
            byte minimumAllowedAge = 0;
            byte defaultValidityLength = 0;
            decimal classFees = -1;
            if (clsLicenseClassesDataAccess.GetLicenseClassByClassName(ClassName, ref licenseClassID, ref classDescription, ref minimumAllowedAge, ref defaultValidityLength, ref classFees))
            {
                return new clsLicenseClasses(licenseClassID, ClassName, classDescription, minimumAllowedAge, defaultValidityLength, classFees);
            }
            else 
            {
                return null;
            }
        }

        static public clsLicenseClasses GetLicenseClassByID(int LicenseClassID)
        {
            string className = string.Empty;
            string classDescription = string.Empty;
            byte minimumAllowedAge = 0;
            byte defaultValidityLength = 0;
            decimal classFees = -1;
            if (clsLicenseClassesDataAccess.GetLicenseClassByID(LicenseClassID, ref className,ref classDescription, ref minimumAllowedAge, ref defaultValidityLength, ref classFees))
            {
                return new clsLicenseClasses(LicenseClassID, className, classDescription, minimumAllowedAge, defaultValidityLength, classFees);
            }
            else
            {
                return null;
            }
        }

    }
}
