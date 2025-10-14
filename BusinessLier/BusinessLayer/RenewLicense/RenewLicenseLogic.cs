using DLMS.EntitiesNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DLMS.EntitiesNamespace.Entities;

namespace DLMS.BusinessLier.RenewLicense
{
    public class RenewLicenseLogic
    {

        public static int RenewLicense(int LicenseID,int CreatedBy,string Notes,out int ApplicationID)
        {
            ApplicationID = -1;

            if (!User.UserLogic.Exists(CreatedBy))
                return 0;
            Entities.ClsLicense? License = LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID: LicenseID);
            Entities.ClsApplication? oldApp = DLMS.BusinessLier.Application.ApplicationLogic.GetApplicationByID(License.ApplicationID);

            if (License == null || oldApp == null)
                return 0;

            Entities.ClsApplication NewApp = new DLMS.EntitiesNamespace.Entities.ClsApplication();
            NewApp.ApplicationStatus = DLMS.EntitiesNamespace.Entities.ClsApplication.enApplicationStatus.New;
            NewApp.ApplicantPersonId = oldApp.ApplicantPersonId;
            NewApp.ApplicantionDate = DateTime.Now;
            NewApp.ApplicationType = DLMS.EntitiesNamespace.Entities.ClsApplication.enApplicationType.RenewDrivingLicense;//renew
            NewApp.LastStatusDate = DateTime.Now;
            NewApp.PaidFees =
            DLMS.BusinessLier.ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.RenewDrivingLicense);
            
            NewApp.CreatedByUserId = CreatedBy;
            string ER="";
            int NewAppId = DLMS.BusinessLier.Application.ApplicationLogic.AddNewApplication(NewApp, ref ER);
            ApplicationID = NewAppId;

            DLMS.EntitiesNamespace.Entities.ClsLicense Newlicense = new DLMS.EntitiesNamespace.Entities.ClsLicense();
            Newlicense.ApplicationID = NewAppId;
            Newlicense.DriverID = License.DriverID;
            Newlicense.IsActive = true;
            Newlicense.CreatedByUserID = CreatedBy;
            Newlicense.ExpirationDate = DateTime.Now.AddYears(License.LicenseClassInfo.DefaultValidityLength);
            Newlicense.IssueDate = DateTime.Now;
            Newlicense.PaidFees = License.LicenseClassInfo.ClassFees;
            Newlicense.IssueReason = Entities.ClsLicense.enIssueReason.Renew;// renew
            Newlicense.Notes = Notes.Length>250?"":Notes;
            Newlicense.LicenseClassID = License.LicenseClassID;


            int NewLicenseID = DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.AddNewLocalDrivinLicense(Newlicense);
            // 0 error / -1  //Driver OR LicenseClassId or Application no longer exists
            if (NewLicenseID > 1)
            {
                DLMS.Data_access.Applications.ApplicationData.SetApplicationStatus(Newlicense.ApplicationID, 3);
                DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.DiActivateLicense(License.LicenseID);
                DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ActivatetLicense(NewLicenseID);
            }
            return NewLicenseID;
        }
      
    }
}
