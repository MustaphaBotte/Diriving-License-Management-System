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
            string Hash = GetStoredPasswordHash(Username);
            if(!VerifyPassword(password, Hash))
            {
                return null;
            }
            Entities.ClsUser? user = Data_access.Users.UserData.GetUserByIdOrUsername(username:Username);
            if (user != null)
            {
                user.Person = DLMS.Data_access.Person.PersonData.FindPerson(user.PersonId);
                user.PassWord = password;
            }
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

        public static bool Save(Entities.ClsUser User, out int NewUserID,ref string Errors)
        {
            NewUserID = -1;
            if (User == null)
                return false;
                  
            return UserLogic.SaveInternally(User, ref Errors, ref NewUserID);

        }
        public static bool VerifyPassword(string Pass, string Hash)
        {   try
            {
                return BCrypt.Net.BCrypt.Verify(Pass, Hash);
            }  
            catch
            {
                return false;
            }
        }
        private static bool HashPassword(ref string Password)
        {
            try
            {
                Password = BCrypt.Net.BCrypt.HashPassword(Password, 11);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static string GetStoredPasswordHash(string username)
        {
            string? Hash = DLMS.Data_access.Users.UserData.GetHash(username);
            return Hash == null ? "" : Hash;
        }
        private static bool SaveInternally(Entities.ClsUser User, ref string Errors, ref int ID)
        {
            string PasswordToHash = User.PassWord;
            string OldPass = User.PassWord;
            switch (User.Mode)
            {
                case Entities.EnMode.AddNew:
                    
                    if (!HashPassword(ref PasswordToHash))
                    {
                        Errors = "Hashing password failed try again";
                        return false; //stop the process
                    }
                    User.PassWord = PasswordToHash;
                    ID = UserData.AddUser(User, ref Errors);
                    if (ID != -1)
                    {
                        User.PassWord = OldPass;
                        User.Mode = Entities.EnMode.Update;
                        return true;
                    }
                    break;

                case Entities.EnMode.Update:
                    if(User.PassWord.Length<=20)
                    {
                        if (!HashPassword(ref PasswordToHash))
                        {
                            Errors = "Hashing password failed try again";
                            return false; //stop the process
                        }
                        User.PassWord = PasswordToHash;
                    }
                    if (UserData.UpdateUser(User, ref Errors))
                    {
                        User.PassWord = OldPass;
                        return true;
                    }
                    break;
            }
            return false;
        }



    }
}
