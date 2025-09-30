using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMS.BusinessLier.Release_Detain_License
{
    public class Release_Detain_LicenseLogic
    {
        public static int DetainLicense(DLMS.EntitiesNamespace.Entities.ClsDetainedLicense DLicense)
        {
            if (DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ISDetained(DLicense.LicenseID))
            {
                return -2; //Detained Before
            }
            return DLMS.Data_access.Release_Detain_License.Release_Detain_LicenseData.DetainLicense(DLicense);
            //if -1 not detained
        }
        public static DLMS.EntitiesNamespace.Entities.ClsDetainedLicense? FindbyID(int DetainID)
        {
            if (!DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ISDetained(DetainID))
            {
                return null;
            }
            return DLMS.Data_access.Release_Detain_License.Release_Detain_LicenseData.FindByID(DetainID);

        }
        public static int ReLeaseLicense(int LicenseID, DateTime ReleaseDate, int ReleasedBy, int ReleasedAppID)
        {
            if (!DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ISDetained(LicenseID))
            {
                DLMS.BusinessLier.Application.ApplicationLogic.DeleteApplication(ReleasedAppID);
                return -1; // not in Detain
            }
            if (DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID: LicenseID)?.ExpirationDate < DateTime.Now)
            {
                return -2;
            }
            bool Result = DLMS.Data_access.Release_Detain_License.Release_Detain_LicenseData.ReleaseLicense(LicenseID, ReleaseDate, ReleasedBy, ReleasedAppID);
            if (Result)
            {
                DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.ActivatetLicense(LicenseID);
                return 1;
            }
            return 0;
        }
        public static DataTable? GetAllDetainedLicenses()
        {
            return DLMS.Data_access.Release_Detain_License.Release_Detain_LicenseData.GetAllDetainedLicenses();
        }
        public static DataTable? GetCompletedInfoByDetainedID(int DetainID)
        {
            return DLMS.Data_access.Release_Detain_License.Release_Detain_LicenseData.GetCompletedInfoByDetainedID(DetainID);
        }
    }
}
