using System;
using System.Data;
using DVLD___Data_Access_Layer;

namespace DVLD___Logic_Layer
{
    public class clsUser
    {
        public static bool Login (string Useraname, string Password)
        {
            return clsUserDataAccess.Login (Useraname, Password);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }

        public static DataTable GetUserWithID(string ID)
        {
            return clsUserDataAccess.GetUserWithID(ID);
        }

        public static DataTable GetUserWithPersonID(string ID)
        {
            return clsUserDataAccess.GetUserWithPersonID(ID);
        }

        public static DataTable GetUserWithFullName(string FullName)
        {
            return clsUserDataAccess.GetUserWithFullName(FullName);
        }

        public static DataTable GetUserWithUsername(string Username)
        {
            return clsUserDataAccess.GetUserWithUsername(Username);
        }

        public static DataTable GetUsersWithIsActive(bool IsActive)
        {
            return clsUserDataAccess.GetUserWithIsActive(IsActive);
        }

    }
}
