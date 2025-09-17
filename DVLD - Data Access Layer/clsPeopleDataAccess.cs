using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DVLD___Data_Access_Layer
{
    public class clsPeopleDataAccess
    {
        public static DataTable GetAllPeople()
        {
            DataTable datatable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT        People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName
, People.DateOfBirth, People.Gendor, People.Address, People.Phone, People.Email,
Countries.CountryName AS Nationalty FROM            People INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID";

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

        public static DataTable GetPeopleWithFilter(string Filter, string Value)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "SELECT        People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName" +
                ", People.DateOfBirth, People.Gendor, People.Address, People.Phone, People.Email," +
                "Countries.CountryName AS Nationalty FROM            People INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID" +
                $" Where {Filter} LIKE @Value ";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Value", Value + '%');

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                reader.Close();
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }
        public static DataTable GetPeopleWithNationalNo(string NatinoalNo)
        {
            return GetPeopleWithFilter("NationalNo", NatinoalNo);
        }

        public static DataTable GetPeopleWithPersonID(string PersonID)
        {
            return GetPeopleWithFilter("PersonID", PersonID);
        }

        public static DataTable GetPeopleWithFirstName(string FirstName)
        {
            return GetPeopleWithFilter("FirstName", FirstName);
        }
        public static DataTable GetPeopleWithSecondName(string secondName)
        {
            return GetPeopleWithFilter("SecondName", secondName);
        }

        public static DataTable GetPeopleWithThirdName(string thirdName)
        {
            return GetPeopleWithFilter("ThirdName", thirdName);
        }

        public static DataTable GetPeopleWithLastName(string lastName)
        {
            return GetPeopleWithFilter("LastName", lastName);
        }

        public static DataTable GetPeopleWithGender(string gender)
        {
            return GetPeopleWithFilter("Gendor", gender);
        }

        public static DataTable GetPeopleWithAddress(string address)
        {
            return GetPeopleWithFilter("Address", address);
        }

        public static DataTable GetPeopleWithPhone(string phone)
        {
            return GetPeopleWithFilter("Phone", phone);
        }

        public static DataTable GetPeopleWithEmail(string email)
        {
            return GetPeopleWithFilter("Email", email);
        }

        public static DataTable GetPeopleWithNationalty(string Nationalty)
        {
            return GetPeopleWithFilter("CountryName", Nationalty);
        }

        public static void FindWithPersonID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName
            , ref string LastName, ref DateTime DateOfBirth, ref string Address, ref byte Gender, ref string Phone, ref string Email, ref int CountryID
            , ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    CountryID = (int)reader["NationalityCountryID"];
                    ImagePath = (reader["ImagePath"]).ToString();
                }
                reader.Close();
            }
            catch { }
            finally
            {
                connection.Close();
            }


        }

        static public int AddNew(string NationalNo,string FirstName, string SecondName, string ThirdName,string LastName, DateTime DateOfBirth
            , byte Gendor, string Address, string Phone, string Email, int CountryID, string ImagePath)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName,LastName, DateOfBirth, Gendor, Email, Phone, Address, NationalityCountryID, ImagePath)
    VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName,@LastName,  @DateOfBirth, @Gendor, @Email, @Phone, @Address, @CountryID, @ImagePath);
SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@Gendor", Gendor);

            if ((ImagePath) == null)
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }



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

        static public bool Update(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth
            , byte Gendor, string Address, string Phone, string Email, int CountryID, string ImagePath)
        {
            int RowsAffected = -1;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"Update People SET FirstName = @FirstName, SecondName = @SecondName, ThirdName = @ThirdName, LastName = @LastName
, Email = @Email, Phone = @Phone, Address = @Address, DateOfBirth = @DateOfBirth, NationalityCountryID = @CountryID, Gendor = @Gendor, ImagePath = @ImagePath
Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            if ((ImagePath) == null)
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }



            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
                

            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }
        static public bool IsExist(string NationalNo)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT isfound = 1 FROM People WHERE NationalNo = @NationalNo;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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
