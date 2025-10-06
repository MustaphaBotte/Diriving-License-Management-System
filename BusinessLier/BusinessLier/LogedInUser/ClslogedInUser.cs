using DLMS.EntitiesNamespace;
namespace DLMS.BusinessLier
{
    public sealed class ClslogedInUser
    {
        public static DateTime LogedInTime = new DateTime();
        public static Entities.ClsUser logedInUser { set; get; } = new Entities.ClsUser();

        private ClslogedInUser()
        { //no objects
        }
    }
}
