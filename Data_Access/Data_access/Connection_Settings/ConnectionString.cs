using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLMS;

namespace DLMS.Data_access.ConnectionSettings
{
     class ConnectionString
    {
        public static string GetConnectionString()
        {
            return @"Server=.\MSSQLSERVER1;Database=DLMS; User=sa;Password=123456;TrustServerCertificate=True;";
        }
    }
}
