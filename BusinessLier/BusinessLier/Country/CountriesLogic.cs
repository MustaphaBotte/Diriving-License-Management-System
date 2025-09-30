using DLMS.EntitiesNamespace;
using System.Data;


namespace DLMS.BusinessLier.Country
{
    public static class CountriesLogic
    {
        public static Entities.ClsCountry? FinCountry(short ID = -1, string CountryName = "")
        {
            return DLMS.Data_access.Country.CountryData.FindCountry(ID, CountryName);
        }
        public static DataTable? GetAllCountries()
        {
            return DLMS.Data_access.Country.CountryData.GetAllCountries();
        }

    }
}
