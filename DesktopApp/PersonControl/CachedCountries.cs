using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//this lier will send the exported countries from db as an cached dictionnary to avoid
//that eache control to fill his own dictionnary
namespace DesktopApp.PersonControl
{
    class CachedCountries
    {
        private static DataTable Countries = new DataTable();
        public static Dictionary<short, object> CountriesAsDict = new Dictionary<short, object>();
        public static Dictionary<short,object>? GetAllCountreis()
        {
            if(CountriesAsDict.Count>0)
            {
                return CountriesAsDict;
            }
           
            if(Countries.Rows.Count<=0)
            {
                Countries = DLMS.BusinessLier.Country.CountriesLogic.GetAllCountries();
                if(Countries==null)
                {
                    return null;
                }
            }

            for(short i =0;i< CachedCountries.Countries?.Rows.Count;i++)
            {
                short  Key = Convert.ToInt16(Countries.Rows[i][0]);
                object Value = Countries.Rows[i][1];
                 CountriesAsDict.Add(key:Key,value:Value );              
            }
            return CountriesAsDict;

        }

    }
}
