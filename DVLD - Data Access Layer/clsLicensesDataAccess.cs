using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DVLD___Data_Access_Layer
{
    public class clsLicensesDataAccess
    {
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssuseDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, int IssuseReason, int CreatedByUserID)
        {
            int ID;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "INSERT INTO [dbo].[Licenses]           ([ApplicationID],[DriverID],[LicenseClass],[IssueDate],[ExpirationDate],[Notes],[PaidFees],[IsActive],[IssueReason],[CreatedByUserID])     VALUES           (@ApplicationID, @DriverID, @LicenseClass, @IssuseDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssuseReason, @CreatedByUserID);Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssuseDate", IssuseDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes == " " || Notes == string.Empty)
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssuseReason", IssuseReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            
            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    ID = InsertedID;
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

        public static bool FindLicenseByApplicationID(int ApplicationID, ref int LicenseID, ref int DriverID, ref int LicenseClass, ref DateTime IssuseDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssuseReason, ref int CreatedByUserID)
        {
            bool IsFound;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Select * From Licenses Where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    LicenseID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssuseDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = reader["Notes"].ToString();
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssuseReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];


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

        static public bool IsExist(int DriverID, int LicenseClass)
        { 
            bool IsFound;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Select IsFound=1 From Licenses Where DriverID = @DriverID AND LicenseClass = @LicenseClass";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;
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

        static public DataTable GetAllLocalDrivingLicenses(int DriverID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT        Licenses.LicenseID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive, Licenses.ApplicationID
FROM            Licenses INNER JOIN
                         LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
WHERE        (Licenses.DriverID = @DriverID)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

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
    }
}
