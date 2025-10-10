using DLMS.EntitiesNamespace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMS.BusinessLier.LocalDrivingLicenseApplication
{
    public class LocDriviLicAppLogic
    {
        public static int AddNewLocalDrivingLicApplication(Entities.ClsApplication App,int LicenseClassID,ref string message)
        {
            if (App == null)
                return 0;
            List<short> Result = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetlisenceStatusOfAperson(App.ApplicantPersonId,LicenseClassID);
            if(Result.Contains(1))
            {
                return -1;
            }
            if(Result.Contains(3))
            {
                return -3;
            }       
            return DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.AddNewLocalDrivLicenApp(App, LicenseClassID,ref message);
            //0 Internal Error
            //-1 Has An Open Application
            //-2 Has License
            // 1<x its Ok>>ID
        }
        public static bool Exists(int LocDriAppID)
        {
            return DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.Exists(LocDriAppID);

        }

        public static Entities.ClsLocDriApplication? GetLocDriLicAppInfo(int LocDriAppID)
        {
            Entities.ClsLocDriApplication? LocApp= DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.GetLocDriLicAppInfo(LocDriAppID);
            if(LocApp!=null)
            {
                LocApp.ApplicantPersonInfo = Person.PersonLogic.FindPerson(LocApp.ApplicantPersonId);
                LocApp.CreatedByUser       = User.UserLogic.FindUserByIdOrUser(LocApp.CreatedByUserId);
                LocApp.ApplicationTypeInfo = ApplicationTypes.ApplicationTypesLogic.GetApplicationTypeByIdOrName((int)LocApp.ApplicationType);
                LocApp.LicenseClassInfo    = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetLisenceClassById(LocApp.LicenseClassID);
                return LocApp;
            }
            return null;
         }
        public static DataTable? GetAllLocalApplications()
        {
            return DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.GetAllLocalApplications();
        }
        public static int GetAppIdByLocalDrivingId(int LocDriLicId)
        {
            return DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.GetApplicationIdByLocDriId(LocDriLicId);
        }
        public static int GetApplicantPersonIdByLocDriId(int LocDriID)
        {
            return DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.GetApplicantPersonIdByLocDriId(LocDriID);
        }
        public static bool IsLocalApplicationCanceled(int LocAppId)
        {
            if (LocAppId <= 0)
                return false;
            return DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.IsLocalApplicationCanceled(LocAppId);
        }
        public static bool IsLocalApplicationCompleted(int LocAppId)
        {
            if (LocAppId <= 0)
                return false;
            return DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.IsLocalApplicationCompleted(LocAppId);
        }
        public static int HasNewOrCompletedLicenseType(int LocAppId,int LicenseClassID)
        {
            if (LocAppId <= 0)
                return -1;
            try
            {
                int PersonID = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.GetApplicantPersonIdByLocDriId(LocAppId);
                if(PersonID<=0)
                {
                    return -1;
                }
                if( DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.HasNewOrCompletedLicenseType(PersonID,LicenseClassID))
                {
                    return 1;
                }
                return 0;
            }
            catch
            {
                return -1; //internal error
            }

        }
        public static int EditLocalDriLicApplicationClass(int Loc_DLA_ID, int NewLicenseClassID)
        {
            if(DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.IsLocalApplicationCanceled(Loc_DLA_ID))
            {
                return -2;
            }
            if (DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.IsLocalApplicationCompleted(Loc_DLA_ID))
            {
                return -3;
            }
            if(DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(Loc_DLA_ID,1)|| DLMS.BusinessLier.Test.Testlogic.IsFailedBefore(Loc_DLA_ID, 1))
            {
                return -5;
            }
            int Status = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.HasNewOrCompletedLicenseType(Loc_DLA_ID, NewLicenseClassID);
      
            if(Status ==1)
            {
                return -4;
            }
            if(Status==0)
            {
                if (DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.EditLocalDriLicApplicationClass(Loc_DLA_ID, NewLicenseClassID) == 1)
                {
                    return 1; //Edited succesfully
                }
            }         
            return 0;

            //0 Internal Error
            //-2 App Canceled
            //-3 App Completed
            //-4 means already has a one
            // 1 Ok>>ID
        }

        public static int PassesTests(int Loc_DLA_ID)
        {
            return DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.PassedTests(Loc_DLA_ID);
        }

    }
}
