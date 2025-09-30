using DLMS.Data_access.ConnectionSettings;
using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMS.Data_access.InternationalDrivingLicense
{
    public class InternationDriLicenseData
    {
        private static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\InternationalDrivingLicense\LogsFile.txt";
        public static int IssueNewInternationDrivingLicense(Entities.ClsInternationalLicense internationalLicense)
        {
            string Query = $"Insert into internationalLicenses values (@ApplicationID,@DriverID," +
                $"@IssueUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID); SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@ApplicationID", internationalLicense.Application?.ApplicationId);
            command.Parameters.AddWithValue("@DriverID", internationalLicense.DriverID);
            command.Parameters.AddWithValue("@IssueUsingLocalLicenseID", internationalLicense.IssueUsingLocLicID);
            command.Parameters.AddWithValue("@IssueDate", internationalLicense.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", internationalLicense.ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", internationalLicense.IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", internationalLicense.CreatedByUserID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result?.ToString(), out int res) ? res : -1;
                return ID;
            }
            catch (SqlException SQ)
            {
                if (SQ.ErrorCode == 547)
                {
                    return -1; //Driver OR IssueUsingLocalDriID or Application no longer exists
                }
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, SQ);
            }
            catch (Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
                return 0;
            }
            finally
            {
                connection.Close();
            }
            return 0;

        }
        public static bool HasActiveInternationalLicense(int DriverID)
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "select case when exists (select top 1 1 from InternationalLicenses where " +
                           "  DriverID = @ID and IsActive =1) then 1 else 0 end as result";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@ID", DriverID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                int Result = int.TryParse(result.ToString(), out int Res) ? Res : 0;
                return (Result == 1);
            }
            catch (Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public static Entities.ClsInternationalLicense? GetLicenseByInterNatID(int InterNationalLicID)
        {
            
            string query = "select top 1 * from InternationalLicenses where InternationalLicenseID=@ID";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(query, connection);
         
            command.CommandText = query;
            command.Parameters.AddWithValue("@ID", InterNationalLicID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Entities.ClsInternationalLicense(
                           reader.GetInt32(reader.GetOrdinal("InterNationalLicenseID")),
                           Applications.ApplicationData.GetApplicationByID(Convert.ToInt32(reader.GetInt32(reader.GetOrdinal("ApplicationID")))),
                           reader.GetInt32(reader.GetOrdinal("DriverID")),
                           reader.GetInt32(reader.GetOrdinal("IssuedUsingLocalLicenseID")),
                           reader.GetDateTime(reader.GetOrdinal("IssueDate")),
                           reader.GetDateTime(reader.GetOrdinal("ExpirationDate")),
                           reader.GetBoolean(reader.GetOrdinal("IsActive")),
                           reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                           );
                }
                
                return null;
            }
            catch (Exception ex)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, ex);
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

    }
}
