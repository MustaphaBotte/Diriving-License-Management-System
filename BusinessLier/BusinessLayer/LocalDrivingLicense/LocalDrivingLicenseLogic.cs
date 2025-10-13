using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;


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
            int LocAppID= DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetLocDriLicAppInfoByApplicationID(License.ApplicationID)?.LocDriApplicationID??-1;
            if(!Test.Testlogic.PassedAllTests(LocAppID))
            {
                return -4;
            }
            if (!DLMS.BusinessLier.Driver.DriverLogic.Exists(License.DriverID) )
            {
                return 0; //internal error ui dev didnt create a new driver;
            }
           
            int NewLicenseID = DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.AddNewLocalDrivinLicense(License);
            // -1 data intergrity violation -- 0 error  >1 good -- -2has lic before -3 app locked;
            if(NewLicenseID>0)
            {
                DLMS.Data_access.Applications.ApplicationData.SetApplicationStatus(License.ApplicationID, 3);
            }
            return NewLicenseID;
        }
        public static Entities.ClsLicense? GetLicenseByLicIDOrLocDriID(int licenseID=-1,int Loc_DLA_ID=-1)
        {
            if(licenseID ==-1 && Loc_DLA_ID == -1)
                return null;
            Entities.ClsLicense? License = DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.GetLicenseByLicIDOrLoc_DLA_ID(licenseID, Loc_DLA_ID);
            if(License!=null)
            {
                License.DriverInfo = Driver.DriverLogic.GetDriverById(License.DriverID);
                License.LicenseClassInfo = LicenseClasse.LicenseClassLogic.GetLisenceClassById(License.LicenseClassID);
                License.DetainInfo = Release_Detain_License.Release_Detain_LicenseLogic.FindbyID(License.LicenseID);
                return License;
            }
            return null;
        }
        public static bool ISDetained(int LicenseID)
        {
            return DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.ISDetained(LicenseID);
        }
        public static bool ISActive(int LicenseID)
        {
            return DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.ISActive(LicenseID);
        }
        public static bool DiActivateLicense(int LicenseID)
        {
            return DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.DiActivateLicense(LicenseID);
        }
        public static bool ActivatetLicense(int LicenseID)
        {
            return DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.ActivatetLicense(LicenseID);
        }


        public static DataTable? GetAllLocalDriverLicenses(int DriverID)
        {
            return DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.GetAllDriverLicenses(DriverID);
        }
        public static DataTable? GetAllInternationalDriverLicenses(int DriverID)
        {
            return DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.GetAllInternationalDriverLicenses(DriverID);
        }
        public static List<short> GetlisenceStatusOfAperson(int personID, int LicenseClassId)
        {
            if (personID <= 0 || LicenseClassId <= 0)
                return new List<short>();

            return DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.GetlisenceStatusOfAperson(personID, LicenseClassId);
        }


    }
}
