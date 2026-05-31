using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
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

        public clsUser(int UserID, int PersonID, string Username, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            _Mode = _enMode.Update;
        }
        public static bool Login (string Useraname, string Password)
        {
            return clsUserDataAccess.Login (Useraname, Password);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }        
        public static clsUser FindUserWithUserID(int UserID)
        {
            int personID = -1;
            string username = string.Empty;
            string password = string.Empty;
            bool isActive = false;

            if (clsUserDataAccess.FindWithUserID(UserID, ref personID, ref username, ref password, ref isActive))
            {
                return new clsUser(UserID, personID, username, password, isActive);
            }
            else
            {
                return null;
            }

        }
        static public clsUser FindUserWithUserName(string UserName)
        {
            int userID = -1;
            int personID = -1;
            string password = string.Empty;
            bool isActive = false;

            if (clsUserDataAccess.FindWithUserName(UserName, ref personID, ref userID, ref password, ref isActive))
            {
                return new clsUser(userID, personID, UserName, password, isActive);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNew()
        {
            this.UserID = clsUserDataAccess.AddNew(this.PersonID, this.Username, this.Password, this.IsActive);

            return UserID != -1;
        }


        private  bool _Update()
        {
            return clsUserDataAccess.Update(this.UserID, this.PersonID, this.Username, this.Password, this.IsActive);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    return _AddNew();

                case _enMode.Update:
                    return _Update();

                default:
                    return false;
            }

        }
        static public bool Delete(int ID)
        {
            return clsUserDataAccess.Delete(ID);
        }

    }
}
