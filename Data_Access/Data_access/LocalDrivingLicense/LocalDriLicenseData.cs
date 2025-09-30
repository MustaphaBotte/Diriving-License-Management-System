using DLMS.Data_access.ConnectionSettings;
using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
using System.ComponentModel;

namespace DLMS.Data_access.LocalDrivingLicense
{
    public class LocalDriLicenseData
    {
        private static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\IssueLocalDrivingLicenseData\LogFile.txt";
        public static int AddNewLocalDrivinLicense(Entities.ClsLicense license)
        {
            string Query = "INSERT INTO Licenses " +
                " VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @Paidfees, @IsActive, @IssueReason, @CreatedByUserID); " +
                "SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
            command.Parameters.AddWithValue("@DriverID", license.DriverID);
            command.Parameters.AddWithValue("@LicenseClass", license.LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
            command.Parameters.AddWithValue("@Notes", (object)license.Notes ?? DBNull.Value);
            command.Parameters.AddWithValue("@Paidfees", license.PaidFees);
            command.Parameters.AddWithValue("@IsActive", license.IsActive);
            command.Parameters.AddWithValue("@IssueReason", license.IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);
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
                    return -1; //Driver OR LicenseClassId or Application no longer exists
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
        public static DLMS.EntitiesNamespace.Entities.ClsLicense? GetLicenseByLicIDOrLoc_DLA_ID(int licenseID=-1,int Loc_DLA_ID=-1)
        {
            if (licenseID == -1 && Loc_DLA_ID == -1)
                return null;
            string Attribut = licenseID != -1 ? "LicenseID" : "LocalDrivingLicenseApplicationID";
            int Value = Attribut == "LicenseID" ? licenseID : Loc_DLA_ID;
    
            string query = "";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(query, connection);
            if (Attribut== "LocalDrivingLicenseApplicationID")
            {
                     query = @$"select top 1 licenses.* from licenses
                             inner join Applications on licenses.ApplicationID = Applications.ApplicationID
                             inner join LocalDrivingLicenseApplications on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                             WHERE {Attribut} = @Value";
            }
            if (Attribut == "LicenseID")
            {
                query = @$"select top 1 * from licenses                           
                             WHERE {Attribut} = @Value";
            }
            command.CommandText = query;
            command.Parameters.AddWithValue("@Value", Value);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new DLMS.EntitiesNamespace.Entities.ClsLicense(
                           reader.GetInt32(reader.GetOrdinal("LicenseID")),
                           reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                           reader.GetInt32(reader.GetOrdinal("DriverID")),
                           reader.GetInt32(reader.GetOrdinal("LicenseClass")),
                           reader.GetDateTime(reader.GetOrdinal("IssueDate")),
                           reader.GetDateTime(reader.GetOrdinal("ExpirationDate")),
                           reader.IsDBNull(reader.GetOrdinal("Notes"))?"": reader.GetString(reader.GetOrdinal("Notes")),
                           reader.GetDecimal(reader.GetOrdinal("PaidFees")),
                           reader.GetBoolean(reader.GetOrdinal("IsActive")),
                           reader.GetByte(reader.GetOrdinal("IssueReason")),
                           reader.GetInt32(reader.GetOrdinal("CreatedByUserID")));
                };
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
        public static bool ISDetained(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "select case when exists (select top 1 1 from DetainedLicenses where licenseID = @ID and Isreleased=0) then 1 else 0 end as result";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@ID", LicenseID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                int Result = int.TryParse(result.ToString(), out int Res) ? Res : 0;
                return( Result == 1);
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
        public static bool ISActive(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "select case when exists (select top 1 1 from Licenses where licenseID = @ID and IsActive =1) then 1 else 0 end as result";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@ID", LicenseID);
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
        public static bool DiActivateLicense(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "update Licenses set IsActive = 0 where LicenseId =@ID";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@ID", LicenseID);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                return (result >0);
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
        public static bool ActivatetLicense(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "update Licenses set IsActive = 1 where LicenseId =@ID";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@ID", LicenseID);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                return (result > 0);
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



    }
}
