using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD___Data_Access_Layer
{
    public class clsUserDataAccess
    {
        public static bool Login(string Username, string Password)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT isfound = 1 FROM Users WHERE Username = @Username and Password = @Password;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
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
