using System;
using System.Data;
using System.Data.SqlClient;

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


        static public int IsExist(int PersonID, int LicenseClassID)
        {
            int ApplicationID;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT        LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID FROM            
LocalDrivingLicenseApplications INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID 
WHERE        (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID) AND (Applications.ApplicantPersonID = @PersonID)  AND (Applications.ApplicationStatus = 1)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                }
                else
                {
                    ApplicationID = -1;
                }
                reader.Close();
            }
            catch
            {
                ApplicationID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ApplicationID;
        }

        static public DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "SELECT * From LocalDrivingLicenseApplications_View";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        
        static public bool FindLocalDrivingLicenseApplicationsWithID(int ID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT * From LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID LIKE @ID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID.ToString() + '%');

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }

                reader.Close();
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }

        public static int GetPassedTests(int LocalDrivingLicenseApplicationID)
        {
            int PassedTests;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT        PassedTestCount
FROM            LocalDrivingLicenseApplications_View
WHERE        (LocalDrivingLicenseApplicationID = @ID)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                object Resault = command.ExecuteScalar();

                if (Resault != null && int.TryParse(Resault.ToString(), out int Count))
                {
                    PassedTests = Count;
                }
                else
                {
                    PassedTests = -1;
                }
            }
            catch
            {
                PassedTests = -1;
            }
            finally
            {
                connection.Close();
            }
            return PassedTests;
        }
    

        
        static public bool Delete(int LocalDrivingLicenseApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Delete from LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);
        }
            
    }
}

