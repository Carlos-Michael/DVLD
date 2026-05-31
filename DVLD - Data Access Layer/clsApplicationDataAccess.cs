using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLD___Data_Access_Layer
{
    public class clsApplicationDataAccess
    {
        static public int NewApplication(int ApplicationPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"Insert INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
    VALUES (@ApplicationPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID)
SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object Resault = command.ExecuteScalar();

                if (Resault != null && int.TryParse(Resault.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
                }
                else
                {
                    ApplicationID = -1;
                }
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

        public static bool Cancel(int AppID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Update Applications SET ApplicationStatus = 2 WHERE ApplicationID = @AppID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppID", AppID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();


            }
            catch
            {
                RowsAffected = 0;
            }
            finally
            {
                connection.Close();
            }
           
            return RowsAffected > 0;

        }

        public static bool FindApplicationByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate
            , ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool isFound;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Select * From Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    isFound = false;
                }

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

        public static bool Update(int AppID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Update Applications SET ApplicationDate = @ApplicationDate, ApplicationTypeID = @ApplicationTypeID, ApplicationStatus = @ApplicationStatus, LastStatusDate = @LastStatusDate, PaidFees = @PaidFees, CreatedByUserID = @CreatedByUserID WHERE ApplicationID = @AppID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppID", AppID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", ApplicationStatus);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();


            }
            catch
            {
                RowsAffected = 0;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;

        }

    }
}
