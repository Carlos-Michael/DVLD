using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD___Data_Access_Layer;

namespace DVLD___Logic_Layer
{
    public class clsTestTypes
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitel { get; set; }
        public decimal TestTypeFees { get; set; }
        public string TestTypeDescription { get; set; }

        public clsTestTypes(int TestTypeID, string TestTypeTitel, string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitel = TestTypeTitel;
            this.TestTypeFees = TestTypeFees;
            this.TestTypeDescription = TestTypeDescription;
        }
        static public DataTable GetTestTypes()
        {
            return clsTestTypesDataAccess.GetAllTestTypes();
        }


        private bool _Update()
        {

            return clsTestTypesDataAccess.Update(TestTypeID, TestTypeTitel, TestTypeDescription, TestTypeFees);
        }

        public bool Save()
        {
            return _Update();
        }

        static public clsTestTypes FindTestTypeByID(int testTypeID)
        {
            string testTypetitel = string.Empty;
            string testTypeDescription = string.Empty;
            decimal testTypefees = -1;
            if (clsTestTypesDataAccess.FindTestTypeByID(testTypeID, ref testTypetitel, ref testTypeDescription, ref testTypefees))
            {
                return new clsTestTypes(testTypeID, testTypetitel, testTypeDescription, testTypefees);
            }
            else
            {
                return null;
            }

        }
    }
}