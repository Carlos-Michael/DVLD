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
    public class clsTestAppointmentDataAccess
    {
        public static DataTable GetTestAppointmentsWithApplicationID(int ID, int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Select TestAppointmentID, AppointmentDate, PaidFees, IsLocked From TestAppointments WHERE LocalDrivingLicenseApplicationID = @ID AND TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch { }

            finally
            {
                connection.Close();
            }
            return dt;
        }
  
        static public bool FindTestAppointmentByID(int ID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicatonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Select * From TestAppointments WHERE TestAppointmentID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    if (reader["RetakeTestApplicationID"].ToString() == "")
                    {
                        RetakeTestApplicatonID = -1;
                    }
                    else 
                    {
                        RetakeTestApplicatonID = int.Parse(reader["RetakeTestApplicationID"].ToString());
                    }
                }
                reader.Close();
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
        static public int GetCountOfTestAppointment(int ID, int TestTypeID, bool TestResult)
        {
            int Trial;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = @"SELECT COUNT(*) FROM TestAppointments INNER jOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
            WHERE LocalDrivingLicenseApplicationID = @ID AND TestTypeID = @TestTypeID AND TestResult = @TestResult;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestResult", TestResult);

            try
            {
                connection.Open();

                object Resault = command.ExecuteScalar();

                if (Resault != null && int.TryParse(Resault.ToString(), out int Count))
                {
                    Trial = Count;
                }
                else 
                { 
                    Trial = -1;
                }
            }
            catch 
            {
                Trial = -1;
            }
            finally
            {
                connection.Close();

            }
            return Trial;
        }

        static public int SchudleAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedBy, bool IsLoked, int RetakeTestApplicationID)
        {
            int ID;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID) VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID ,@IsLocked ,@RetakeTestApplicationID);SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedBy);
            command.Parameters.AddWithValue("@IsLocked", IsLoked);
            if (RetakeTestApplicationID == -1)
            { 
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else 
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
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

        static public bool IsExist(int ID, int TestTypeID, bool IsLocked)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "SELECT IsFound = 1 From TestAppointments WHERE LocalDrivingLicenseApplicationID = @ID AND TestTypeID = @TestTypeID AND IsLocked = @IsLocked";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();

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

        static public bool Update(int TestAppointmentID, DateTime AppointmentDate)
        {
            int RowsAffected = -1;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Update TestAppointments Set AppointmentDate = @Date Where TestAppointmentID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Date", AppointmentDate);
            command.Parameters.AddWithValue("@ID", TestAppointmentID);


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
            return RowsAffected > -1;
        }
        static public bool Lock(int TestAppointmentID)
        {
            int RowsAffected = -1;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "Update TestAppointments Set IsLocked = 1 Where TestAppointmentID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", TestAppointmentID);


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
            return RowsAffected > -1;
        }
    }
}
