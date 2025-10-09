using DLMS.Data_access;
using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
using System.Data;
using static DLMS.EntitiesNamespace.Entities;

namespace DLMS.BusinessLier.ApplicationTypes
{
    public class ApplicationTypesLogic
    {
        public static Entities.ClsApplicationType? GetApplicationTypeByIdOrName(int AppTypeID)
        {
            return DLMS.Data_access.Applications_Types.AppLicationsTypesData.GetAppTypeById(AppTypeID);
        }
        public static DataTable? GetAllApplicationTypes()
        {
            return DLMS.Data_access.Applications_Types.AppLicationsTypesData.GetAllApplicationTypes();
        }
        public static bool UpdateApplicationType(Entities.ClsApplicationType UpdatedObj)
        { 
            return DLMS.Data_access.Applications_Types.AppLicationsTypesData.UpdateApplicationType(UpdatedObj);
        }
        public static decimal  GetApplicationFees(Entities.ClsApplication.enApplicationType AppType)
        {
            return DLMS.Data_access.Applications_Types.AppLicationsTypesData.GetFeesOfApplication((int)AppType);
        }
        public static string? GetAppTypeTitleByAppID(int AppID)
        {
            return DLMS.Data_access.Applications_Types.AppLicationsTypesData.GetAppTypeTitleByAppID(AppID);
        }
    }
}
