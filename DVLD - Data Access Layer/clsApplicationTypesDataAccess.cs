using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DVLD___Data_Access_Layer
{
    public class clsApplicationTypesDataAccess
    {

        static public DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Select * From ApplicationTypes";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }    
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        static public bool Update(int AppTypeID, string AppTypeTitel, decimal AppFees)
        {
            int RowsAffectted = 0;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Update ApplicationTypes Set ApplicationTypeTitle = @AppTypeTitel, ApplicationFees = @AppFees WHERE ApplicationTypeID = @AppTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppTypeTitel", AppTypeTitel);
            command.Parameters.AddWithValue("@AppFees", AppFees);
            command.Parameters.AddWithValue("@AppTypeID", AppTypeID);

            try
            {
                connection.Open();

                RowsAffectted = command.ExecuteNonQuery();
                
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return (RowsAffectted > 0);
        }

        static public bool FindApplicationTypeByID(int AppTypeID, ref string AppTypeTitel, ref decimal AppFees)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Select * From ApplicationTypes WHERE ApplicationTypeID = @AppTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppTypeID", AppTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    AppTypeTitel = (string)reader["ApplicationTypeTitle"];
                    AppFees = (decimal)reader["ApplicationFees"];
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }
    }

}
