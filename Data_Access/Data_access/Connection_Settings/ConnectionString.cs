using System.Configuration;
using DLMS;
using Microsoft.IdentityModel.Protocols;

namespace DLMS.Data_access.ConnectionSettings
{
     class ConnectionString
    {
       // public static string GetConnectionString(bool x)
       // {
       //     return @"Server=.\MSSQLSERVER1;Database=DLMS; User=sa;Password=123456;TrustServerCertificate=True;";
       // }
        public static string GetConnectionString()
        {
            //i put the app.config in the UI layer because in the desktop applications the config file must
            // exist in the folder of the final exe file 
            // dont use this method in the web development
            try
            {
                string? Connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString ??"";
                return Connection;                                     
            }
            catch
            {
                return "";
            }
        }
    }
}
