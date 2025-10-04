using DLMS.EntitiesNamespace;
using DLMS.Data_access;
using System.Data;
using DLMS.BusinessLier.Person;
using DLMS.Data_access.Users;


namespace DLMS.BusinessLier.User
{
    public static class UserLogic
    {
        public static Entities.ClsUser? FindUserByIdOrUser(int ID = -1, string Username = "")
        {
            Entities.ClsUser? user = UserData.GetUserByIdOrUsername(ID, Username);
            if(user!=null)
                  user.Person = DLMS.Data_access.Person.PersonData.FindPerson(user.PersonId);
            return user;
        }
        public static Entities.ClsUser? FindUserByPersonID(int ID)
        {
            Entities.ClsUser? user = UserData.GetUserByPersonId(ID);
            if (user != null)
                user.Person = DLMS.Data_access.Person.PersonData.FindPerson(user.PersonId);
            return user;
        }
        public static Entities.ClsUser? FindUserByUserAndPass(string Username, string password)
        {
            Entities.ClsUser? user = Data_access.Users.UserData.GetUserByUserandPass(Username, Username);
            if (user != null)
                user.Person = DLMS.Data_access.Person.PersonData.FindPerson(user.PersonId);
            return user;
        }

        public static string? GetUserNameByUserId(int UserId)
        {
            return DLMS.Data_access.Users.UserData.GetUserNameById(UserId);
        }

        public static int DeleteUser(int ID = -1, string Username = "")
        {
            return Data_access.Users.UserData.DeleteUser(ID, Username);
        }
        public static bool Exists(int ID = -1, string Username = "")
        {
            return Data_access.Users.UserData.Exists(ID, Username);
        }
        public static bool ExistsByPersonID(int PersonID)
        {
            return Data_access.Users.UserData.IsUserExistsByPersonId(PersonID);
        }
  
        public static DataTable? GetAllUsers()
        {
            return Data_access.Users.UserData.GetAllusers();
        }

        public static bool Save(Entities.ClsUser User, out int NewUserID)
        {
            NewUserID = -1;
            if (User == null)
                return false;
          
          
            string SaveErrors = "";
            return UserLogic.SaveInternally(User, ref SaveErrors, ref NewUserID);

        }
        private static bool SaveInternally(Entities.ClsUser User, ref string Errors, ref int ID)
        {
            switch (User.Mode)
            {
                case Entities.EnMode.AddNew:
                    ID = UserData.AddUser(User, ref Errors);
                    if (ID != -1)
                    {
                        User.Mode = Entities.EnMode.Update;
                        return true;
                    }
                    break;
                case Entities.EnMode.Update:
                    if (UserData.UpdateUser(User, ref Errors))
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }



    }
}
