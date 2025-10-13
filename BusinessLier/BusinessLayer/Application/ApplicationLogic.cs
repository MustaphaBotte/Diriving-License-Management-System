using System.Data;
using DLMS;
using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
namespace DLMS.BusinessLier.Application
{
    public class ApplicationLogic
    {
      
        public static bool SetApplicationStatus(int LocDriLicID,byte Status)
        {
            //1 =new ; 2= canceled; 3=Completed
            int ApplicationID = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetAppIdByLocalDrivingId(LocDriLicID);

            DLMS.EntitiesNamespace.Entities.ClsApplication? App = DLMS.BusinessLier.Application.ApplicationLogic.GetApplicationByID(ApplicationID);
            if (App == null)
                return false;

            int CurrentStatus = (int)App.ApplicationStatus;
            if (CurrentStatus == 2 || CurrentStatus == 3)
            {
                return false;
            }

            return DLMS.Data_access.Applications.ApplicationData.SetApplicationStatus(ApplicationID, Status);
        }
        public static int DeleteApplication(int AppID)
        {          
            return  DLMS.Data_access.Applications.ApplicationData.DeleteApplication(AppID);
            //in database we set the on delete cascade so deleting only the Main App will also delete the local app linked to it
        }
        public static Entities.ClsApplication? GetApplicationByID(int AppID)
        {
            Entities.ClsApplication? App = Data_access.Applications.ApplicationData.GetApplicationByID(AppID);
            if(App!=null)
            {
                App.ApplicantPersonInfo = Person.PersonLogic.FindPerson(App.ApplicantPersonId);
                App.CreatedByUser       = User.UserLogic.FindUserByIdOrUser(App.CreatedByUserId);
                App.ApplicationTypeInfo = 
                ApplicationTypes.ApplicationTypesLogic.GetApplicationTypeByIdOrName((int)App.ApplicationType);
                return App;
            }
            return null;
        }       
        public static int GetApplicationStatus(int AppID)
        {
            return DLMS.Data_access.Applications.ApplicationData.GetApplicationStatusByID(AppID);
        }
        public static int AddNewApplication(DLMS.EntitiesNamespace.Entities.ClsApplication application, ref string message)
        {
            return DLMS.Data_access.Applications.ApplicationData.AddNewApplication(application,ref message);
        }
        public static bool Exists(int AppId)
        {
            return DLMS.Data_access.Applications.ApplicationData.Exists(AppId);
        }


        public static int GetActiveApplicationID(uint PersonId, uint ApplicationTypeID)
        {
           return  DLMS.Data_access.Applications.ApplicationData.GetActiveApplicationID(PersonId, ApplicationTypeID);
        }
        public static bool DoesPersonHaveActiveApplication(uint PersonId, uint ApplicationTypeID)
        {
            return (GetActiveApplicationID(PersonId, ApplicationTypeID) > 0);
        }
        public static int GetActiveApplicationIDForLicenseClass(uint PersonId, uint ApplicationTypeID, uint LicenseClassID)
        {
           return DLMS.Data_access.Applications.ApplicationData.GetActiveApplicationIDForLicenseClass(PersonId, ApplicationTypeID, LicenseClassID);
        }
    }

}
 