using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD___Data_Access_Layer
{
    public class clsCountryDataAccess
    {
        public static DataTable GetAllCountries()
        {
            DataTable datatable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT * From Countries";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    datatable.Load(reader);
                }
                reader.Close();
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return datatable;
        }
        public static void Find(int CountryID, ref string CountryName)
        {
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT * From Countries WHERE CountryID =  @CountryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    CountryName = (string)reader["CountryName"];
                }
                reader.Close();
            }
            catch { }
            finally
            {
                connection.Close();
            }

        }

        public static void Find(string CountryName, ref int CountryID)
        {
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT * From Countries WHERE CountryName =  @CountryName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    CountryID = (int)reader["CountryID"];
                }
                reader.Close();
            }
            catch { }
            finally
            {
                connection.Close();
            }

        }
        static void Main(string[] args)
        {

        }
    }
}
