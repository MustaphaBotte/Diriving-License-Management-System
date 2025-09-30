using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMS.BusinessLier.RenewLicense
{
    public class RenewLicenseLogic
    {
        public static int RenewLicense(EntitiesNamespace.Entities.ClsLicense NewLicense, EntitiesNamespace.Entities.ClsLicense OldLicense, ref string ER)
        {
            if(OldLicense==null || OldLicense.ExpirationDate>DateTime.Now)
            {
                return -3;
            }
            if(!OldLicense.IsActive)
            {
                return -2;
            }
           
            int NewLicenseID = DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.AddNewLocalDrivinLicense(NewLicense);
            // 0 error / -1  //Driver OR LicenseClassId or Application no longer exists
            if(NewLicenseID>1)
            {
                DLMS.Data_access.Applications.ApplicationData.SetApplicationStatus(NewLicense.ApplicationID, 3);
                DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.DiActivateLicense(OldLicense.LicenseID);
                DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.ActivatetLicense(NewLicenseID);
            }
            return NewLicenseID;
        }
    }
}
