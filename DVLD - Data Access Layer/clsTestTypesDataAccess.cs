using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD___Data_Access_Layer
{
    public class clsTestTypesDataAccess
    {
        static public DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Select * From TestTypes";

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


        static public bool Update(int TestTypeID, string TestTypeTitel, string TestTypeDescription, decimal TestTypeFees)
        {
            int RowsAffectted = 0;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Update TestTypes Set TestTypeTitle = @TestTypeTitel, TestTypeDescription = @TestTypeDescription, TestTypeFees = @TestTypeFees WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitel", TestTypeTitel);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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

        static public bool FindTestTypeByID(int TestTypeID, ref string TestTypeTitel, ref string TestTypeDescription,ref decimal TestTypeFees)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Select * From TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    TestTypeTitel = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = (decimal)reader["TestTypeFees"];
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
