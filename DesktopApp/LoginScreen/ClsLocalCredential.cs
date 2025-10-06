using DLMS.EntitiesNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesktopApp.LocalCredential
{
    class ClsLocalCredential
    {          private static readonly string RememberingFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\DesktopApp\LoginScreen\RememberingFile.json";
            public static Entities.ClsUser? GetUser(string username, string password, bool rememberme = false)
            {
                Entities.ClsUser? user = DLMS.BusinessLier.User.UserLogic.FindUserByUserAndPass(username, password);
                if (user != null)
                {
                    if (rememberme)
                    {
                        RememberTheUser(user);
                        DesktopApp.LogedInUser.ClslogedInUser.logedInUser = user;
                        DesktopApp.LogedInUser.ClslogedInUser.LogedInTime = DateTime.Now;
                    }
                    else
                    {
                        CleanJsonFile();
                    }
                }
                return user;
            }
            public static void RememberTheUser(Entities.ClsUser user)
            {
                if (user == null) { return; }

                string jsonformat = JsonSerializer.Serialize(user);

                if (jsonformat != null)
                {
                    if (!File.Exists(RememberingFilePath))
                    {
                        File.Create(RememberingFilePath).Close();
                    }
                    File.WriteAllText(RememberingFilePath, jsonformat + Environment.NewLine, encoding: Encoding.UTF8);
                }

            }
            public static Entities.ClsUser? GetTheStoredUser()
            {
                if (!File.Exists(RememberingFilePath))
                {
                    return null;
                }
                IEnumerable<string> Users = File.ReadLines(RememberingFilePath);
                foreach (string userLine in Users)
                {
                    Entities.ClsUser? user = JsonSerializer.Deserialize<Entities.ClsUser>(userLine);
                    if (user != null)
                    {
                        return user;
                    }
                    return null;
                }
                return null;
            }
            private static void CleanJsonFile()
            {
                if (File.Exists(RememberingFilePath))
                {
                    File.WriteAllText(RememberingFilePath, "");
                }
            }

        
    }
}
