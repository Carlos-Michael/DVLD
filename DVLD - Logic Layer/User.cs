using System;
using DVLD___Data_Access_Layer;

namespace DVLD___Logic_Layer
{
    public class clsUser
    {
        public static bool Login (string Useraname, string Password)
        {
            return clsUserDataAccess.Login (Useraname, Password);
        }
    }
}
