using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DLMS.EntitiesNamespace;
using DLMS.Data_access.ConnectionSettings;

namespace DLMS.Data_access.Country
{
   
    public static class CountryData
    {
        private static DataTable Countries = new DataTable();
        public static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\DLMS\Data_access\Countries\Logs.txt";
        public static Entities.ClsCountry? FindCountry(short ID=-1 ,string CountryName="")
        {
            if (ID == -1 && string.IsNullOrEmpty(CountryName))
            {
                return null;
            }
            string Attribut = (ID == -1) ? "CountryName" : "CountryID";
            string Query = $"select * from Countries where {Attribut} = @Value";

            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value:SharedFunctions.GetValueForQuery(ID, CountryName));

            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                if (Reader.Read())
                { 
                    string CName = Reader["CountryName"] == DBNull.Value ? "" :(string)Reader["CountryName"];
                    return new Entities.ClsCountry(Convert.ToByte(Reader["CountryID"]),
                                         CName);
                                        
                }

                return null;
            }
            catch (Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
                Reader?.Close();
                connection.Close();
            }
            return null;





        }
        public static DataTable? GetAllCountries()
        {
            if(Countries.Rows.Count>0)
            {
                return Countries;
            }
            
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: "select * from Countries;", connection: connection);
            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                if (Reader != null && Reader.HasRows)
                {
                    Countries.Load(Reader);
                    return Countries;
                }
                return null;
            }
            catch (Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
                Reader?.Close();
                connection.Close();
            }
            return null;
        }


    }
}
