using DLMS.EntitiesNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMS.BusinessLier.LocalDrivingLicense
{
    public class LocalDrivingLicenseLogic
    {
        public static int AddNewLocalDrivinLicense(Entities.ClsLicense License)
        {
            if (BusinessLier.Driver.DriverLogic.HasLicenseBefore(License.DriverID, License.LicenseClassID))
            {
                return -2;
            }
            int AppStatus = BusinessLier.Application.ApplicationLogic.GetApplicationStatus(License.ApplicationID);
            if (((List<int>)[3,2]).Contains(AppStatus))
            {
                return -3;
            }
            int NewLicenseID = DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.AddNewLocalDrivinLicense(License);
            // -1 data intergrity violation -- 0 error  >1 good -- -2has lic before -3 app locked;
            if(NewLicenseID>0)
            {
                DLMS.Data_access.Applications.ApplicationData.SetApplicationStatus(License.ApplicationID, 3);
            }
            return NewLicenseID;
        }

        public static DLMS.EntitiesNamespace.Entities.ClsLicense? GetLicenseByLicIDOrLocDriID(int licenseID=-1,int Loc_DLA_ID=-1)
        {
            if(licenseID ==-1 && Loc_DLA_ID == -1)
                return null;
            return DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.GetLicenseByLicIDOrLoc_DLA_ID(licenseID, Loc_DLA_ID);
        }
        public static bool ISDetained(int LicenseID)
        {
            return DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.ISDetained(LicenseID);
        }


    }
}
