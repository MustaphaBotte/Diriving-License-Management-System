using System.Data;
using DLMS;
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
            if(App.ApplicationStatus ==2 || App.ApplicationStatus==3)
            {
                return false;
            }

            return DLMS.Data_access.Applications.ApplicationData.SetApplicationStatus(ApplicationID, Status);
        }
        public static int DeleteApplication(int AppID)
        {          
          //  if(DLMS.Data_access.Applications.ApplicationData.GetApplicationTypeByID(AppID))
            return  DLMS.Data_access.Applications.ApplicationData.DeleteApplication(AppID);
        }
        public static EntitiesNamespace.Entities.ClsApplication? GetApplicationByID(int AppID)
        {
            return DLMS.Data_access.Applications.ApplicationData.GetApplicationByID(AppID);
        }       
        public static int GetApplicationStatus(int AppID)
        {
            return DLMS.Data_access.Applications.ApplicationData.GetApplicationStatusByID(AppID);
        }

        public static int AddNewApplication(DLMS.EntitiesNamespace.Entities.ClsApplication application, ref string message)
        {
            return DLMS.Data_access.Applications.ApplicationData.AddNewApplication(application,ref message);
        }

    }
}
