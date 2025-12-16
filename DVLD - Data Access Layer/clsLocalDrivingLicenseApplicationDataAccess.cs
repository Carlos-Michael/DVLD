using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;

namespace DVLD___Data_Access_Layer9
{
    public class clsLocalDrivingLicenseApplicationsDataAccess
    {
        static public int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) VALUES (@ApplicationID, @LicenseClassID) SELECT SCOPE_IDENTITY();";
           
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();

                object Resault = command.ExecuteScalar();

                if (Resault != null && int.TryParse(Resault.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }
            }
            catch 
            {
                ID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ID;
        }
    }
}
