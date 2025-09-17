using System;
using System.Data;
using DVLD___Data_Access_Layer;

namespace DVLD___Logic_Layer
{
    public class clsCountry
    {
        public int CountryID;
        public string CountryName;

        public clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }
        public static clsCountry Find(int CountryID)
        {
            string countryName = string.Empty;

            clsCountryDataAccess.Find(CountryID, ref countryName);

            return new clsCountry(CountryID, countryName);
        }
        public static clsCountry Find(string CountryName)
        {
            int countryID = -1;
            clsCountryDataAccess.Find(CountryName, ref countryID);

            return new clsCountry(countryID, CountryName);
        }

    }
}
