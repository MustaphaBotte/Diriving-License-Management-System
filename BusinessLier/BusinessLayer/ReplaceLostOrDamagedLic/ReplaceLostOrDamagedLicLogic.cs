using DLMS.EntitiesNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DLMS.EntitiesNamespace.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace DLMS.BusinessLier.ReplaceLostOrDamagedLic
{
    public class ReplaceLostOrDamagedLicLogic
    {

        public static int ReplaceLicense(int LicenseID, Entities.ClsApplication.enApplicationType AppType, int CreatedBy,string Notes,out int ApplicationID)
        {
            ApplicationID = -1;
            int AppTypeID = (int)AppType;
            if (AppTypeID != 3 && AppTypeID != 4)
                return 0;

            if (!User.UserLogic.Exists(CreatedBy))
                return 0;

            Entities.ClsLicense? License = LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID: LicenseID);
            Entities.ClsApplication? oldApp = DLMS.BusinessLier.Application.ApplicationLogic.GetApplicationByID(License.ApplicationID);

            if (License == null || oldApp == null)
                return 0;

           
            Entities.ClsApplication NewApp = new Entities.ClsApplication();
            NewApp.ApplicationStatus = Entities.ClsApplication.enApplicationStatus.New;
            NewApp.ApplicantPersonId = oldApp.ApplicantPersonId;
            NewApp.ApplicantionDate = DateTime.Now;
            NewApp.ApplicationType = (Entities.ClsApplication.enApplicationType)((int)AppTypeID);
            NewApp.CreatedByUserId = CreatedBy;
            NewApp.LastStatusDate = DateTime.Now;
            NewApp.PaidFees = AppTypeID == 3 ? ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.ReplaceLostDrivingLicense) :
                                               ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.ReplaceDamagedDrivingLicense);
            NewApp.CreatedByUserId = CreatedBy;          
            string ER = "";
            ApplicationID = DLMS.BusinessLier.Application.ApplicationLogic.AddNewApplication(NewApp, ref ER);


            Entities.ClsLicense Newlicense = new Entities.ClsLicense();
            Newlicense.ApplicationID = ApplicationID;
            Newlicense.DriverID = License.DriverID;
            Newlicense.IsActive = true;
            Newlicense.CreatedByUserID = License.CreatedByUserID;
            Newlicense.ExpirationDate = License.ExpirationDate;
            Newlicense.IssueDate = License.IssueDate;
            Newlicense.PaidFees = License.PaidFees;
            Newlicense.IssueReason = (Entities.ClsLicense.enIssueReason)(AppTypeID == 3 ? 4 : 3);
            Newlicense.Notes = Notes.Length > 250 ? "" : Notes;
            Newlicense.LicenseClassID = License.LicenseClassID;
            int NewLicenseID = DLMS.Data_access.LocalDrivingLicense.LocalDriLicenseData.AddNewLocalDrivinLicense(Newlicense);
            // 0 error / -1  //Driver OR LicenseClassId or Application no longer exists
            if (ApplicationID > 1)
            {
                DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.DiActivateLicense(LicenseID);
                DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ActivatetLicense(NewLicenseID);
                DLMS.Data_access.Applications.ApplicationData.SetApplicationStatus(Newlicense.ApplicationID, 3);
            }
            return NewLicenseID;
        }
       
    }
}
