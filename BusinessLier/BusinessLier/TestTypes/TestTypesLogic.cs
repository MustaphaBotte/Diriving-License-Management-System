using DLMS;
using DLMS.EntitiesNamespace;
using System.Data;
namespace DLMS.BusinessLier.TestTypes
{
    public class TestTypesLogic
    {
        public static Entities.ClsTestType? GetTestTypeByIdOrtitle(int AppTypeID = -1, string AppTypeName = "")
        {
            return DLMS.Data_access.Test_Types.TestTypesData.GetTestTypeByIdOrTitle(AppTypeID, AppTypeName);
        }
        public static DataTable? GetAllTestTypes()
        {
            return DLMS.Data_access.Test_Types.TestTypesData.GetAllTestTypes();
        }
        public static bool UpdateTestType(Entities.ClsTestType UpdatedObj)
        {
            return DLMS.Data_access.Test_Types.TestTypesData.UpdateTestType(UpdatedObj);

        }

    }
}
