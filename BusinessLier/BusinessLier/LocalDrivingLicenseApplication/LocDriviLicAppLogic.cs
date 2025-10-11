using DLMS.EntitiesNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DLMS.BusinessLier.LocalDrivingLicenseApplication
{
    public class LocDriviLicAppLogic
    {
        public class ClsResultProvider
        {
            public int ResultCode;
            public string ResultName="";
            public string ResultMessage="";
            public bool IsSuccess = false;
            public int NewLocAppId;
            public ClsResultProvider(int ResultCode, string ResultName, string ResultMessage, int NewLocAppId, bool IsSuccess)
            {
                this.ResultCode = ResultCode;
                this.ResultName = ResultName;
                this.ResultMessage = ResultMessage;
                this.IsSuccess = IsSuccess;
                this.NewLocAppId = NewLocAppId;
            }
        }

        public static ClsResultProvider AddNewLocalDrivingLicApplication(Entities.ClsApplication App,int LicenseClassID,ref string message)
        {
            if (App == null || App.ApplicantPersonInfo==null)
                return new ClsResultProvider(-1, "Internal Error",
                     "the main application or person is null or empty", -1, false);
            List<short> Result = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetlisenceStatusOfAperson(App.ApplicantPersonId,LicenseClassID);
           
            if (Result.Contains(1))
            {
                return new ClsResultProvider(-1, "system rules violation",
                    "This person already has an incompleted application from this license type", -1, false);
               
            }
            if(Result.Contains(3))
            {
                return new ClsResultProvider(-3, "system rules violation",
                    "This person already has a License from this license class type", -1, false);
               
            }
            short MinAllowedAge = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetMinimumAllowedAge(LicenseClassID);
            if (App.ApplicantPersonInfo?.DateOfBirth.AddYears(MinAllowedAge) > DateTime.Now)
            {

                return new ClsResultProvider(-4, "system rules violation",
                    $"The minmum allowed age is {MinAllowedAge} years old", -1, false);              
            } 

            int NewAppId = DLMS.Data_access.Applications.ApplicationData.AddNewApplication(App, ref message);
            int LocalAppId= DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.AddNewLocalDrivLicenApp(NewAppId, LicenseClassID,ref message);
             if(LocalAppId<=0)
                DLMS.Data_access.Applications.ApplicationData.DeleteApplication(LocalAppId);

             return new ClsResultProvider(1, "Operation Success",
             @$"Local Driving license app with Id= {LocalAppId} added successfully", LocalAppId, true);

           
        }
        public static ClsResultProvider EditLocalDriLicApplicationClass(int Loc_DLA_ID, int NewLicenseClassID)
        {
            if (DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.IsLocalApplicationCanceled(Loc_DLA_ID))
            {
                return new ClsResultProvider(1, "System rules violation",
                       @$"Local Driving license app with Id= {Loc_DLA_ID} Is Canceled you cannot edit it", -1, false);          
            }
            if (DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.IsLocalApplicationCompleted(Loc_DLA_ID))
            {
                return new ClsResultProvider(1, "System rules violation",
                      @$"Local Driving license app with Id= {Loc_DLA_ID} Is Completed you cannot edit it", -1, false);
               
            }
            if (DLMS.BusinessLier.Test.Testlogic.IsSucceededBefore(Loc_DLA_ID, 1) || DLMS.BusinessLier.Test.Testlogic.IsFailedBefore(Loc_DLA_ID, 1))
            {
                return new ClsResultProvider(1, "System rules violation",
                   @$"This Person already pass some tests or has an open appointments releated to this application you cannot modify it", -1, false);
            
            }
            short MinAllowedAge = DLMS.BusinessLier.LicenseClasse.LicenseClassLogic.GetMinimumAllowedAge(NewLicenseClassID);
            int PersonID = GetApplicantPersonIdByLocDriId(Loc_DLA_ID);
            Entities.ClsPerson? Person = DLMS.BusinessLier.Person.PersonLogic.FindPerson(PersonID);
            if(Person!=null&& Person.DateOfBirth.AddYears(MinAllowedAge)> DateTime.Now)            
            {
                return new ClsResultProvider(1, "System rules violation",
                   @$"The minimun allowed age is {MinAllowedAge} years old", -1, false);
            }

            int Status = DLMS.BusinessLier.LocalDrivingLicenseApplication.LocDriviLicAppLogic.HasNewOrCompletedLicenseType(Loc_DLA_ID, NewLicenseClassID);
      
            if (Status == 1)
            {
                return new ClsResultProvider(1, "System rules violation",
                   @$"This Person already has an application from this license class type", -1, false);

            }
            if (Status == 0)
            {
                if (DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.EditLocalDriLicApplicationClass(Loc_DLA_ID, NewLicenseClassID) == 1)
                {
                    return new ClsResultProvider(1, "Operation Success",
                     @$"Local Driving License Updated successfully", Loc_DLA_ID, true);
                    //Edited succesfully
                }
            }
            return  new ClsResultProvider(1, "Internal Error",
                     @$"Due an internal error we cannot update in the moment", Loc_DLA_ID, false);

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
        public static int PassesTests(int Loc_DLA_ID)
        {
            return DLMS.Data_access.localDrivingLicenseApplication.localDrivingLicenseApplicationData.PassedTests(Loc_DLA_ID);
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
       

    }
}
