using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMS.BusinessLier.InternationDriLicense
{
    public class InternationDriLicenseLogic
    {
        public static int AddNewInternationDrivingLicense(Entities.ClsInternationalLicense internationalLicense, ref string Errors)
        {
            if(!DLMS.BusinessLier.Driver.DriverLogic.HasLicenseBefore(internationalLicense.DriverID,3))
            {
                return -4;
            }

            if(!DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.ISActive(internationalLicense.IssueUsingLocLicID))
            {
                return -2;
            }
            if (DLMS.Data_access.InternationalDrivingLicense.InternationDriLicenseData.HasActiveInternationalLicense(internationalLicense.DriverID))
            {
                return -3;
            }

            if (!DLMS.Data_access.Applications.ApplicationData.Exists(internationalLicense.Application.ApplicationId))           
                return -1;

            int NewIntLicID = DLMS.Data_access.InternationalDrivingLicense.InternationDriLicenseData.IssueNewInternationDrivingLicense(internationalLicense);
            if(NewIntLicID>0)
            {
                DLMS.Data_access.Applications.ApplicationData.SetApplicationStatus(internationalLicense.Application.ApplicationId, 3);
            }
            else
            {
                DLMS.BusinessLier.Application.ApplicationLogic.DeleteApplication(internationalLicense.Application.ApplicationId);
            }
            return NewIntLicID;
            //-1 if Driver OR IssueUsingLocalDriID or Application no longer exists
            // 0 internal unknown error             
        }
        public static bool HasActiveInternationalLicense(int DriverID)
        {
            return DLMS.Data_access.InternationalDrivingLicense.InternationDriLicenseData.HasActiveInternationalLicense(DriverID);
        }
        public static int AddNewInternationLicenseApplication(DLMS.EntitiesNamespace.Entities.ClsApplication App)
        {
            string errors = "";
            return DLMS.Data_access.Applications.ApplicationData.AddNewApplication(App, ref errors);
        }
        public static DLMS.EntitiesNamespace.Entities.ClsInternationalLicense? GetLicenseByInterNatID(int InterNationalLicID)
        {
            return DLMS.Data_access.InternationalDrivingLicense.InternationDriLicenseData.GetLicenseByInterNatID(InterNationalLicID);
        }
    }
}
