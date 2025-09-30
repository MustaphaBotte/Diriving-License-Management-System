using DLMS.Data_access.Person;
using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMS.BusinessLier.Driver
{
  public class DriverLogic
    {
        public static DataTable? GetAllDrivers()
        {
            return DLMS.Data_access.Driver.DriverData.GetAllDrivers();
        }

        public static bool IsAlreadyDriver(int PersonID)
        {
            return DLMS.Data_access.Driver.DriverData.AlreadyDriver(PersonID);

        }
        public static int GetDriverID(int PersonID)
        {
            return DLMS.Data_access.Driver.DriverData.GetDriverID(PersonID);
        }
        public static bool HasLicenseBefore(int DriverID,int LicenseClassId)
        {
            return DLMS.Data_access.Driver.DriverData.IsDriverHasLicense(DriverID,LicenseClassId);
        }
        public static int AddNewDriver(Entities.ClsDriver Driver)
        {
            if(IsAlreadyDriver(Driver.PersonID))
            {
               return DLMS.Data_access.Driver.DriverData.GetDriverID(Driver.PersonID);
            }            
            int NewDriverId = DLMS.Data_access.Driver.DriverData.AddNewDriver(Driver);
            // 0 = internal error / -1 means license or person no longer exists /
            // otherwise operation success
            return NewDriverId;
        }
        public static DLMS.EntitiesNamespace.Entities.ClsDriver? GetDriverById(int DriverID)
        {
            return DLMS.Data_access.Driver.DriverData.GetDriverById(DriverID);
        }
        public static DataTable? GetAllLocalDriverLicenses(int DriverID)
        {
            return DLMS.Data_access.Driver.DriverData.GetAllDriverLicenses(DriverID);
        }
        public static DataTable? GetAllInternationalDriverLicenses(int DriverID)
        {
            return DLMS.Data_access.Driver.DriverData.GetAllInternationalDriverLicenses(DriverID);
        }

    }
}
