using DLMS.Data_access;
using DLMS.Data_access.ConnectionSettings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DLMS.EntitiesNamespace.Entities;

namespace DLMS.Data_access.Release_Detain_License
{
    public class Release_Detain_LicenseData
    {
        private static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\Release_Detain_License\LogFile.txt";
        public static int DetainLicense(DLMS.EntitiesNamespace.Entities.ClsDetainedLicense DLicense)
        {

            if (DLicense == null)
            {
                return -1;
            }

            string Query = "INSERT INTO DetainedLicenses " +
                           "VALUES(@LicenseID, @DetainDate,@Fees, @CreatedByUserID, @IsReleased, @ReleaseDate,@ReleasedByUserID,@ReleaseApplicationID); " +
                           "SELECT SCOPE_IDENTITY()";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", DLicense.LicenseID);
            command.Parameters.AddWithValue("@Fees", DLicense.Fees);
            command.Parameters.AddWithValue("@CreatedByUserID", DLicense.CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", false);
            command.Parameters.AddWithValue("@DetainDate", DLicense.DetainDate);
            command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID",  DBNull.Value);
            command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result?.ToString(), out int res) ? res : -1;
                return ID;
            }
            catch (Exception EX)
            {
                SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }
        public static ClsDetainedLicense FindByID(int LicenseID)
        {
            string Query = "SELECT top 1 DetainID, LicenseID, FineFees, CreatedByUserID, IsReleased, " +
                           "DetainDate, ReleaseDate, ReleaseApplicationID, ReleasedByUserID " +
                           "FROM DetainedLicenses WHERE LicenseID = @LicenseID and IsReleased=0";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new ClsDetainedLicense(

                         Convert.ToInt32(reader["DetainID"]),
                         Convert.ToInt32(reader["LicenseID"]),
                         Convert.ToDecimal(reader["FineFees"]),
                         Convert.ToInt32(reader["CreatedByUserID"]),
                         Convert.ToBoolean(reader["IsReleased"]),
                         Convert.ToDateTime(reader["DetainDate"]),
                         reader["ReleaseDate"] == DBNull.Value ? null : Convert.ToDateTime(reader["ReleaseDate"]),
                         reader["ReleasedByUserID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReleaseApplicationID"]),
                         reader["ReleaseApplicationID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReleaseApplicationID"])
                         );
                }
            }
            catch (Exception EX)
            {
                SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
                connection.Close();
            }

            return null;
        }
        public static DataTable? GetCompletedInfoByDetainedID(int DetainID)
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = @$"select detainedlicenses.DetainID,
                                detainedlicenses.LicenseID,
                                detainedlicenses.DetainDate,
                                detainedlicenses.FineFees,
                                detainedlicenses.IsReleased,
                                detainedlicenses.ReleaseDate,
                                detainedlicenses.ReleaseApplicationID,
                                people.NationalNo,
                                people.FirstName+' '+people.SecondName+' '+people.ThirdName+' '+people.LastName As FullName
                                from detainedlicenses 
                                inner join Licenses on Licenses.LicenseID =  detainedlicenses.LicenseID
                                inner join Drivers on Drivers.DriverID = Licenses.DriverID
                                inner join People on Drivers.PersonID = People.PersonID
                                where detainid=@DetainID
                                ";         
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);
            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                DataTable DriverLicenses = new DataTable();
                if (Reader != null && Reader.HasRows)
                {
                    DriverLicenses.Load(Reader);
                    return DriverLicenses;
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
        public static bool ReleaseLicense(int LicenseID,DateTime ReleaseDate,int ReleasedBy,int ReleasedAppID)
        {

            string Query = "UPDATE DetainedLicenses " +
                           "set  IsReleased=1, ReleaseDate = @ReleaseDate,ReleasedByUserID= @ReleasedByUserID,ReleaseApplicationID =@ReleaseApplicationID " +
                           "where LicenseID = @LicenseID; ";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedBy);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleasedAppID);

            try
            {
                connection.Open();
                int Result = command.ExecuteNonQuery();
                return Result > 0;
            }
            catch (Exception EX)
            {
                SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public static DataTable? GetAllDetainedLicenses()
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = @$"select detainedlicenses.DetainID,
                             detainedlicenses.LicenseID,
                             detainedlicenses.DetainDate,
                             detainedlicenses.FineFees,
                             detainedlicenses.IsReleased,
                             detainedlicenses.ReleaseDate,
                             detainedlicenses.ReleaseApplicationID,
                             people.NationalNo,
                             people.FirstName+' '+people.SecondName+' '+people.ThirdName+' '+people.LastName as FullName
                             from detainedlicenses 
                             inner join Licenses on Licenses.LicenseID =  detainedlicenses.LicenseID
                             inner join Drivers on Drivers.DriverID = Licenses.DriverID
                             inner join People on Drivers.PersonID = People.PersonID
                             ";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                DataTable DriverLicenses = new DataTable();
                if (Reader != null && Reader.HasRows)
                {
                    DriverLicenses.Load(Reader);
                    return DriverLicenses;
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
