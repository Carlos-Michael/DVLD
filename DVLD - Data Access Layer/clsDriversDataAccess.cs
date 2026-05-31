using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Data_Access_Layer
{
    public class clsDriversDataAccess
    {
        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int DriverID;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "INSERT INTO [dbo].[Drivers] ([PersonID], [CreatedByUserID], [CreatedDate]) VALUES (@PersonID, @CreatedByUserID, @CreatedDate); Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    DriverID = InsertedID;
                }
                else
                {
                    DriverID = -1;
                }
            }
            catch
            {
                DriverID = -1;
            }
            finally
            {
                connection.Close();
            }

            return DriverID;
        }
        public static bool FindDriverByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFound;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Select * From Drivers Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                }
                else
                {
                    IsFound = false;
                }
            }
            catch
            {
                    IsFound = false;

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        static public DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Select * From Drivers_View";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

    }
}
