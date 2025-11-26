using System;
using System.Data;
using DVLD___Data_Access_Layer;

namespace DVLD___Logic_Layer
{
    public class clsUser
    {

        public int UserID{get; set;}
        public int PersonID{get; set;}
        public string Username{get; set;}
        public string Password{get; set;}
        public bool IsActive{get; set;}
        private enum _enMode {AddNew = 0, Update = 1}
        private _enMode _Mode;

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            Username = string.Empty;
            Password = string.Empty;
            IsActive = false;
            _Mode = _enMode.AddNew;
        }
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

        private bool _AddNew()
        {
            this.UserID = clsUserDataAccess.AddNew(this.PersonID, this.Username, this.Password, this.IsActive);

            return UserID != -1;
        }

        public bool Save()
        {
            if (_Mode == _enMode.AddNew)
            {
                return _AddNew();
            }
            return false;
        }
    }
}
