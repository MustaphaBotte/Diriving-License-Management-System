using DLMS.EntitiesNamespace;
namespace DesktopApp.LogedInUser
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
