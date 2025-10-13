using DLMS;
using DLMS.EntitiesNamespace;
using System.Data;
namespace DLMS.BusinessLier.TestTypes
{
    public  sealed class TestTypesLogic
    {
        public static Entities.ClsTestType? GetTestTypeById(Entities.ClsTestType.EnTestType AppTypeID)
        {
            return DLMS.Data_access.Test_Types.TestTypesData.GetTestTypeById((int)AppTypeID);
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
