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
        public static DataTable GetAllUsers()
        {
            DataTable datatable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT        Users.UserID, Users.PersonID, People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName AS FullName, Users.UserName, Users.IsActive
FROM            Users INNER JOIN
                         People ON Users.PersonID = People.PersonID";

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
        
        static public int AddNew(int PersonID, string UserName, string Password, bool IsActive)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
    VALUES (@PersonID, @UserName, @Password, @IsActive);
SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }
                else
                {
                    ID = -1;
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

        static public bool Delete(int     UserID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"Delete from Users WHERE UserID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", UserID);

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

        static public bool FindWithUserID(int UserID, ref int PersonID, ref string Username, ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT * From Users WHERE UserID LIKE @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    Username = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }

                reader.Close();
            }
            catch {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        static public bool Update(int UserID, int PersonID, string Username, string Password, bool IsActive)
        {
            int RowsAffcted = 0;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Update Users Set UserName = @UserName, Password = @Password, IsActive = @IsActive WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserID", UserID);

            try 
            {
                connection.Open();

                RowsAffcted = command.ExecuteNonQuery();

            }
            catch { }
            finally
            {
                connection.Close();
            }

            return (RowsAffcted > 0);
        }
        static public bool FindWithUserName(string Username, ref int PersonID, ref int UserID, ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT * From Users WHERE UserName LIKE @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", Username);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserID   = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
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
    }
}
