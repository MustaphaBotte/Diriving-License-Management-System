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
        private static readonly string LogFilePath = @"..\..\..\..\Data_Access\Data_access\Release_Detain_License\LogFile.txt";
        public static int DetainLicense(ClsDetainedLicense DLicense)
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
        public static ClsDetainedLicense? FindByLicenseID(int LicenseID)
        {
            string Query = "SELECT top 1 DetainID, LicenseID, FineFees, CreatedByUserID, IsReleased, " +
                           "DetainDate, ReleaseDate, ReleaseApplicationID, ReleasedByUserID " +
                           "FROM DetainedLicenses WHERE LicenseID = @LicenseID order by DetainDate Desc";
            //in this function we get it using order by DetainDate Desc cause the license my be detained multiple times so we get last one

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
        public static ClsDetainedLicense? FindByDetainID(int DetainID)
        {
            string Query = "SELECT top 1 DetainID, LicenseID, FineFees, CreatedByUserID, IsReleased, " +
                           "DetainDate, ReleaseDate, ReleaseApplicationID, ReleasedByUserID " +
                           "FROM DetainedLicenses WHERE DetainID = @DetainID ";

            //in this function we get it using DetainID

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

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
                         reader["ReleasedByUserID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReleasedByUserID"]),
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
        public static DataTable? GetAllDetainedLicenses()
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = @$"select * from Detained_License_View order by DetainDate desc";
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
    }
}
