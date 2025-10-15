using DLMS.EntitiesNamespace;
using System.Data;


namespace DLMS.BusinessLier.InternationDriLicense
{
    public class InternationDriLicenseLogic
    {
        public static int AddNewInternationDrivingLicense(int LicenseID,int CreatedBy,out int ApplicationID)
        {
            ApplicationID = -1;
            Entities.ClsLicense? License = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID:LicenseID);
            if (License == null || License.LicenseClassInfo == null || License.DriverInfo == null)
                return 0;


            if (!DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ISActive(License.LicenseID))
            {
                return -2;
            }
            if (HasActiveInternationalLicense(License.DriverID))
            {
                return -3;
            }
            if (License.LicenseClassInfo.LicenseCLassId != 3)
                return -4;


            if (!DLMS.BusinessLier.User.UserLogic.Exists(CreatedBy))
                return 0;

            DLMS.EntitiesNamespace.Entities.ClsInternationalLicense internationalLicense = new DLMS.EntitiesNamespace.Entities.ClsInternationalLicense();
            internationalLicense.CreatedByUserID = CreatedBy;
            internationalLicense.DriverID = License.DriverID;
            internationalLicense.IssueUsingLocLicID = License.LicenseID;
            internationalLicense.IsActive = true;
            internationalLicense.IssueDate = DateTime.Now;
            internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            internationalLicense.ApplicationID = AddNewInternationLicenseApplication(License.DriverInfo.PersonID, CreatedBy);
            ApplicationID = internationalLicense.ApplicationID;

            int NewIntLicID = DLMS.Data_access.InternationalDrivingLicense.InternationDriLicenseData.IssueNewInternationDrivingLicense(internationalLicense);
            if (NewIntLicID > 0)
            {
                DLMS.Data_access.Applications.ApplicationData.SetApplicationStatus(internationalLicense.ApplicationID, 3);
            }
            else
            {
                DLMS.BusinessLier.Application.ApplicationLogic.DeleteApplication(internationalLicense.ApplicationID);
            }
            return NewIntLicID;
            //-1 if Driver OR IssueUsingLocalDriID or Application no longer exists
            // 0 internal unknown error             
        }      
        public static bool HasActiveInternationalLicense(int DriverID)
        {
            return DLMS.Data_access.InternationalDrivingLicense.InternationDriLicenseData.HasActiveInternationalLicense(DriverID,out int ID);
        }
        public static int GetActiveInternationalID(int DriverID)
        {
            int ID = -1;
            DLMS.Data_access.InternationalDrivingLicense.InternationDriLicenseData.HasActiveInternationalLicense(DriverID, out ID);
            return ID;
        }
        public static int AddNewInternationLicenseApplication(int PersonID,int CreatedBy)
        {
            string errors = "";
             Entities.ClsApplication Application = new Entities.ClsApplication();
            Application.ApplicantionDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.ApplicantPersonId = PersonID;
            Application.ApplicationStatus = DLMS.EntitiesNamespace.Entities.ClsApplication.enApplicationStatus.New; //new
            Application.ApplicationType = DLMS.EntitiesNamespace.Entities.ClsApplication.enApplicationType.NewInternationalLicense; ; //International License
            Application.CreatedByUserId = CreatedBy;
            Application.PaidFees =
            ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.NewInternationalLicense);
            return DLMS.Data_access.Applications.ApplicationData.AddNewApplication(Application, ref errors);
        }
        public static Entities.ClsInternationalLicense? GetLicenseByInterNatID(int InterNationalLicID)
        {
            Entities.ClsInternationalLicense? internationalLicense = Data_access.InternationalDrivingLicense.InternationDriLicenseData.GetLicenseByInterNatID(InterNationalLicID);
            if(internationalLicense!=null)
            {
                internationalLicense.CreatedByUserInfo = DLMS.BusinessLier.User.UserLogic.FindUserByIdOrUser(internationalLicense.CreatedByUserID);
                internationalLicense.IssueUsingLicenseInfo = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(Loc_DLA_ID: internationalLicense.IssueUsingLocLicID);
                return internationalLicense;
            }
            return null;
        }

        public static DataTable? GetAllInternationalLicenses()
        {
            return DLMS.Data_access.InternationalDrivingLicense.InternationDriLicenseData.GetAllInternationalLicenses();
        }
    }
}
