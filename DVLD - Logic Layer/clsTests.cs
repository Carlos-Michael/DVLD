using DVLD___Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Logic_Layer
{
    public class clsTests
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTests(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
        }
        public clsTests()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;
        }

        public bool AddNew()
        {
            this.TestID = clsTestsDataAccess.AddNew(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

            return (TestID > -1);
        }

    }
}
