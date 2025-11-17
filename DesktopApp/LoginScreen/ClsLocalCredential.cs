using DLMS.EntitiesNamespace;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesktopApp.LocalCredential
{
    class ClsLocalCredential
    {         
        
            private static readonly string RememberingFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\DesktopApp\LoginScreen\RememberingFile.json";
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

            //if you dont like the json you can save the user credentiel in the windows registry
            #region Registry
            public static Entities.ClsUser? GetTheStoredUserFromRegistry()
        {
            string? username = "";
            string? password = "";
            string Path = Registry.CurrentUser + @"\SOFTWARE\DLMS";
            try
            {
                username = Registry.GetValue(Path, "username", "").ToString();
                password = Registry.GetValue(Path, "password", "").ToString();
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    return DLMS.BusinessLier.User.UserLogic.FindUserByUserAndPass(username, password);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
            private static void CleanRegistry()
        {
            try
            {
                using (RegistryKey basekey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey? subkey = basekey.OpenSubKey(@"SOFTWARE\DLMS", true))
                    {
                        if (subkey != null)
                        {
                            subkey.DeleteValue("username");
                            subkey.DeleteValue("password");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
            private static void RememberTheUserToRegistry(Entities.ClsUser user)
        {
            string Path = Registry.CurrentUser + @"\SOFTWARE\DLMS";
            try
            {
                if (user.UserName != "" && user.PassWord != "")
                    Registry.SetValue(Path, "username", user.UserName);
                Registry.SetValue(Path, "password", user.PassWord);
            }
            catch (Exception ex)
            {

            }
        }

            #endregion

    }
}
