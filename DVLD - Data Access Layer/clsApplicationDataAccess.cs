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
    }
}
