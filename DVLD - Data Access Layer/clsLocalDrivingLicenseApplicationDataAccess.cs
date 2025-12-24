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


        static public int IsExist(int PersonID, int LicenseClassID)
        {
            int ApplicationID;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT        LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID FROM            LocalDrivingLicenseApplications INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID WHERE        (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID) AND (Applications.ApplicantPersonID = @PersonID)";

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
        static public DataTable GetLocalDrivingLicenseApplicationsWithID(int ID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);
            
            string query = @"SELECT * From LocalDrivingLicenseApplications_View WHERE LocalDrivingLicenseApplicationID LIKE @ID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID.ToString() + '%');

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

        static public DataTable GetLocalDrivingLicenseApplicationsWithNationalNo(string NationalNo)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT * From LocalDrivingLicenseApplications_View WHERE NationalNo LIKE @NationalNo ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo + '%');

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

        static public DataTable GetLocalDrivingLicenseApplicationsWithFullName(string FullName)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT * From LocalDrivingLicenseApplications_View WHERE FullName LIKE @FullName ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FullName", FullName + '%');

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

        static public DataTable GetLocalDrivingLicenseApplicationsWithStatus(string Status)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT * From LocalDrivingLicenseApplications_View WHERE Status LIKE @Status ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Status", Status + '%');

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

    }
}

