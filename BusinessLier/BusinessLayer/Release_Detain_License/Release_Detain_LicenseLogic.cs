using DLMS.EntitiesNamespace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DLMS.BusinessLier.Release_Detain_License
{
    public class Release_Detain_LicenseLogic
    {
        public static int DetainLicense(int LicenseID,int DetainedBY,decimal Fees)
        {
            if (!DLMS.BusinessLier.User.UserLogic.Exists(DetainedBY))
            {
                return 0; //Detained Before
            }
            if (DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ISDetained(LicenseID))
            {
                return -2; //Detained Before
            }
            if (DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID:LicenseID)==null)
            {
                return -3; //license no longer exists
            }
            DLMS.EntitiesNamespace.Entities.ClsDetainedLicense DLicense = new DLMS.EntitiesNamespace.Entities.ClsDetainedLicense();
            DLicense.DetainDate = DateTime.Now;
            DLicense.ReleaseDate = null;
            DLicense.CreatedByUserID = DetainedBY;
            DLicense.IsReleased = false;
            DLicense.LicenseID = LicenseID;
            DLicense.Fees = Fees;
            DLicense.ReleaseApplicationID = null;
            DLicense.ReleasedByUserID = null;
            DLicense.ReleaseApplicationID = null;

            return DLMS.Data_access.Release_Detain_License.Release_Detain_LicenseData.DetainLicense(DLicense);       
            //if -1 not detained
        }
        public static Entities.ClsDetainedLicense? FindbyLicenseID(int LicenseID)
        {
           
            Entities.ClsDetainedLicense? D_License = Data_access.Release_Detain_License.Release_Detain_LicenseData.FindByLicenseID(LicenseID);
            if(D_License!=null)
            {
                //if i made only this  D_License.LicensenInfo = --- i wil get infinite calls between license and detainlicense object so i get it from data access not business
                D_License.LicensenInfo = Data_access.LocalDrivingLicense.LocalDriLicenseData.GetLicenseByLicIDOrLoc_DLA_ID(licenseID: D_License.LicenseID);
                if (D_License.LicensenInfo != null)
                {
                    D_License.LicensenInfo.DriverInfo = DLMS.BusinessLier.Driver.DriverLogic.GetDriverById(D_License.LicensenInfo.DriverID);
                    D_License.LicensenInfo.LicenseClassInfo = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetLisenceClassById(D_License.LicensenInfo.LicenseClassID);
                    D_License.DetainedByUser = DLMS.BusinessLier.User.UserLogic.FindUserByIdOrUser(D_License.CreatedByUserID);
                    D_License.ReleasedByUser = D_License.ReleasedByUserID !=null? DLMS.BusinessLier.User.UserLogic.FindUserByIdOrUser((int)D_License.ReleasedByUserID):null;
                }
                return D_License;
            }
            return null;
        }
        public static DLMS.EntitiesNamespace.Entities.ClsDetainedLicense? FindbyDetainID(int DetainID)
        {          
            Entities.ClsDetainedLicense? D_License = Data_access.Release_Detain_License.Release_Detain_LicenseData.FindByDetainID(DetainID);
            if (D_License != null)
            {
                D_License.LicensenInfo = Data_access.LocalDrivingLicense.LocalDriLicenseData.GetLicenseByLicIDOrLoc_DLA_ID(licenseID: D_License.LicenseID);
                if(D_License.LicensenInfo !=null)
                {
                    D_License.LicensenInfo.DriverInfo = DLMS.BusinessLier.Driver.DriverLogic.GetDriverById(D_License.LicensenInfo.DriverID);
                    D_License.LicensenInfo.LicenseClassInfo = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetLisenceClassById(D_License.LicensenInfo.LicenseClassID);
                }
                return D_License;
            }
            return null;
        }
        public static DataTable? GetAllDetainedLicenses()
        {
            return DLMS.Data_access.Release_Detain_License.Release_Detain_LicenseData.GetAllDetainedLicenses();
        }
   
        public static int ReLeaseLicense(int LicenseID,int ReleasedBy,out int ReleasedAppID)
        {
            ReleasedAppID = 1;
            if (!DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ISDetained(LicenseID))
            {
                return -1; // not in Detain
            }
            if (DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID: LicenseID)?.ExpirationDate < DateTime.Now)
            {
                return -2;
            }
            
            Entities.ClsLicense? License = DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.GetLicenseByLicIDOrLocDriID(licenseID: LicenseID);
            Entities.ClsApplication? App = new Entities.ClsApplication();
            if (License == null || License.DriverInfo == null)
                return 0;
            App.ApplicationStatus = Entities.ClsApplication.enApplicationStatus.New;
            App.ApplicantPersonId = License.DriverInfo.PersonID;
            App.ApplicantionDate = DateTime.Now;
            App.ApplicationType = Entities.ClsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;//release
            App.LastStatusDate = DateTime.Now;
            App.PaidFees = ApplicationTypes.ApplicationTypesLogic.GetApplicationFees(Entities.ClsApplication.enApplicationType.ReleaseDetainedDrivingLicsense);
            App.CreatedByUserId = ReleasedBy;

            string ER = "";
            ReleasedAppID = DLMS.BusinessLier.Application.ApplicationLogic.AddNewApplication(App, ref ER);


            bool Result = DLMS.Data_access.Release_Detain_License.Release_Detain_LicenseData.ReleaseLicense(LicenseID, DateTime.Now, ReleasedBy, ReleasedAppID);
            if (Result)
            {
                DLMS.BusinessLier.LocalDrivingLicense.LocalDrivingLicenseLogic.ActivatetLicense(LicenseID);
                DLMS.Data_access.Applications.ApplicationData.SetApplicationStatus(ReleasedAppID, 3); 
            }
            return 1;
        }

    }
}
