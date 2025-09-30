using DLMS.Data_access;
using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DLMS.BusinessLier.ApplicationTypes
{
    public class ApplicationTypesLogic
    {
        public static Entities.ClsApplicationType? GetApplicationTypeByIdOrName(int AppTypeID = -1, string AppTypeName = "")
        {
            return DLMS.Data_access.Applications_Types.AppLicationsTypesData.GetApplicationTypeByIdOrName(AppTypeID, AppTypeName);
        }
        public static DataTable? GetAllApplicationTypes()
        {
            return DLMS.Data_access.Applications_Types.AppLicationsTypesData.GetAllApplicationTypes();
        }
        public static bool UpdateApplicationType(Entities.ClsApplicationType UpdatedObj)
        { 
            return DLMS.Data_access.Applications_Types.AppLicationsTypesData.UpdateApplicationType(UpdatedObj);
        }
        public static decimal  GetApplicationFees(int AppId)
        {
            if (AppId <= 0 )
                return 0m;

            return DLMS.Data_access.Applications_Types.AppLicationsTypesData.GetFeesOfApplication( AppId);
        }
        public static string? GetApplicationTypeByID(int AppID)
        {
            return DLMS.Data_access.Applications_Types.AppLicationsTypesData.GetApplicationTypeByID(AppID);
        }
    }
}
