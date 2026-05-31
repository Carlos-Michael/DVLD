using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD___Data_Access_Layer
{
    public class clsTestsDataAccess
    {
        public static int AddNew(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int ID;
            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "INSERT INTO [dbo].[Tests] ([TestAppointmentID] ,[TestResult] ,[Notes] ,[CreatedByUserID]) VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes == " " || Notes == string.Empty)
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else 
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
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
    }
}
