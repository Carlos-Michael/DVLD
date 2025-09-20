using DVLD___Data_Access_Layer;
using System;
using System.Data;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Xml.Linq;

namespace DVLD___Logic_Layer
{
    public class clsPeople
    {
        public int PersonID { get; set; }

        public string NationalNo { get; set; }
        
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Byte Gender { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int CountryID { get; set; }

        public string ImagePath { get; set; }

        private enum _enMode { AddNew = 0, Edit = 1 }

        private _enMode _Mode;

        public clsPeople()
        {
            PersonID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Gender = 0;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            CountryID = -1;
            ImagePath = string.Empty;
            this._Mode = _enMode.AddNew;
        }
        
        public clsPeople(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName
            , DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email, int CountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;

            this._Mode = _enMode.Edit;
        }
        public static DataTable GetAllPeople()
        {
            return clsPeopleDataAccess.GetAllPeople();
        }
        public static DataTable GetPeopleWithPersonID(string PersonID)
        {
             return clsPeopleDataAccess.GetPeopleWithPersonID(PersonID);
        }

        public static DataTable GetPeopleWithNationalNo(string NationalNo)
        {
            return clsPeopleDataAccess.GetPeopleWithNationalNo(NationalNo);
        }
        public static DataTable GetPeopleWithFirstName(string firstName)
        {
            return clsPeopleDataAccess.GetPeopleWithFirstName(firstName);
        }

        public static DataTable GetPeopleWithSecondName(string secondName)
        {
            return clsPeopleDataAccess.GetPeopleWithSecondName(secondName);
        }

        public static DataTable GetPeopleWithThirdName(string thirdName)
        {
            return clsPeopleDataAccess.GetPeopleWithThirdName(thirdName);
        }

        public static DataTable GetPeopleWithLastName(string lastName)
        {
            return clsPeopleDataAccess.GetPeopleWithLastName(lastName);
        }
        public static DataTable GetPeopleWithGender(string gender)
        {
            return clsPeopleDataAccess.GetPeopleWithGender(gender);
        }

        public static DataTable GetPeopleWithAddress(string address)
        {
            return clsPeopleDataAccess.GetPeopleWithAddress(address);
        }

        public static DataTable GetPeopleWithPhone(string phone)
        {
            return clsPeopleDataAccess.GetPeopleWithPhone(phone);
        }

        public static DataTable GetPeopleWithEmail(string email)
        {
            return clsPeopleDataAccess.GetPeopleWithEmail(email);
        }

        public static DataTable GetPeopleWithNationalty(string Nationalty)
        {
            return clsPeopleDataAccess.GetPeopleWithNationalty(Nationalty);
        }

        public static clsPeople FindWithPersonID(int PersonID)
        {
            string nationalNo = string.Empty;
            string firstName = string.Empty;
            string secondName = string.Empty;
            string thirdName = string.Empty;
            string lastName = string.Empty;
            DateTime dateOfBirth = DateTime.Now;
            byte gender = 1;
            string address = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            int countryID = -1;
            string imagePath = null;

            clsPeopleDataAccess.FindWithPersonID(PersonID, ref nationalNo, ref firstName, ref secondName, ref thirdName, ref lastName
                , ref dateOfBirth, ref address, ref gender, ref phone, ref email, ref countryID, ref imagePath);

            return new clsPeople(PersonID, nationalNo, firstName, secondName,thirdName, lastName, dateOfBirth, gender, address, phone, email, countryID, imagePath);

                }

        private bool _AddNew()
        {
            this.PersonID = clsPeopleDataAccess.AddNew(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName
                , this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);

            return (PersonID != -1);
        }

        private bool _Update()
        {
            return clsPeopleDataAccess.Update(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName
                , this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);
        }


        public bool Save()
        {
            if (_Mode == _enMode.AddNew)
            {
                return _AddNew();
            }
            else if (_Mode == _enMode.Edit)
            {
                return _Update();
            }
            else
            {
                return false;
            }
        }

        public static bool IsExist(string NationalNo)
        {
            return clsPeopleDataAccess.IsExist(NationalNo);
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleDataAccess.DeletePerson(PersonID);
        }

        static void Main(string[] args)
        {
        }
    }
}
