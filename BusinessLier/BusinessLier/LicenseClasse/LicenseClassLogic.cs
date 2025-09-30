using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMS.BusinessLier.LicenseClasse
{
    public class LicenseClassLogic
    {
        public static DataTable? GetAllLicenseClasses()
        {
            return DLMS.Data_access.LicenceClasses.LicenceClass.GetAllLicenseClasses();         
        }

        public static List<short> GetlisenceStatusOfAperson(int personID, int LicenseClassId)
        {
            if (personID <= 0 || LicenseClassId <= 0)
                return new List<short>();

            return DLMS.Data_access.LicenceClasses.LicenceClass.GetlisenceStatusOfAperson(personID,LicenseClassId);
        }
        public static  decimal GetlisenceFees(int LicenseClassId)
        {
            return DLMS.Data_access.LicenceClasses.LicenceClass.GetlisenceFees(LicenseClassId);
        }
        public static int GetlisenceValidityLength(int LicenseClassId)
        {
            return DLMS.Data_access.LicenceClasses.LicenceClass.GetlisenceValidityLength(LicenseClassId);
        }
       
        public static EntitiesNamespace.Entities.ClsLicenseClass? GetLisenceClassById(int LicenseClaassId=-1,string classname="")
        {
            return DLMS.Data_access.LicenceClasses.LicenceClass.GetLicenseClassByID(LicenseClaassId, classname);
        }
        public static short GetMinimumAllowedAge(int LicenseClaassId )
        {
            return DLMS.Data_access.LicenceClasses.LicenceClass.GetMinAllowedAge(LicenseClaassId);
        }
    }
}
