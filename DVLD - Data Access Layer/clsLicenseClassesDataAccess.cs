using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD___Data_Access_Layer
{
    public class clsLicenseClassesDataAccess
    {
        static public DataTable GetLicenseClass()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "SELECT * From LicenseClasses";

            SqlCommand command = new SqlCommand(query, connection);

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

        static public bool GetLicenseClassByClassName(string ClassName, ref int LicenseClassID, ref string ClassDescription, ref byte MinimumAllowedAge
            , ref byte DefultValidityLength, ref decimal ClassFees)
        {
            bool isActive = false;

            SqlConnection connection = new SqlConnection(clsDatabaseSettings.connectionstring);

            string query = "SELECT * From LicenseClasses WHERE ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isActive = true;
                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];
                }

                reader.Close();

            }
            catch 
            {
                isActive = false;
            }
            finally
            {
                connection.Close();
            }
            
            return isActive;
        }
    }
}

