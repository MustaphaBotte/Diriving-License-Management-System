using DLMS.Data_access.ConnectionSettings;
using Microsoft.Data.SqlClient;
using DLMS.EntitiesNamespace;
using System.Data;
using System.ComponentModel;


namespace DLMS.Data_access.Driver
{
    public class DriverData
    {
        private static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\Drivers\LogFile.txt";

        public static DataTable? GetAllDrivers()
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "select * from My_Drivers_View";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                DataTable Drivers = new DataTable();
                if (Reader != null && Reader.HasRows)
                {
                    Drivers.Load(Reader);
                    return Drivers;
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
        public static bool AlreadyDriver(int PersonID)
        {

            if (PersonID <= 0)
            {
                return false;
            }     
            string Query = $"select case when exists " +
                $"(select 1 from Drivers where PersonID = @Value) then 1 else 0 end as Result";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: PersonID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (int.TryParse(Result.ToString(), out int res))
                {
                    return (res == 1);
                }
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


        public static int GetDriverID(int PersonID)
        {

            if (PersonID <= 0)
            {
                return -1;
            }
            string Query = $"select top 1 DriverID from Drivers where PersonID = @Value";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: PersonID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result?.ToString(), out int res) ? res : -1;
                return ID;
            }
            
            catch (Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }
        public static int AddNewDriver(Entities.ClsDriver Driver)
        {
            if(Driver==null)
            {
                return 0;
            }

            string Query = "insert into Drivers values(@PersonID, @CreatedByUserID, @CreationDate)" +
                " select SCOPE_IDENTITY(); ";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@PersonID", Driver.PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", Driver.CreatedBy);
            command.Parameters.AddWithValue("@CreationDate", Driver.CreationDate);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result?.ToString(), out int res) ? res : -1;
                return ID;
            }
            catch (SqlException SQ)
            {
                if(SQ.ErrorCode== 547)
                {
                    return -1; //Person OR LicenseClass no longer exists
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
        public static bool IsDriverHasLicense(int DriverID,int LicenseClassID)
        {

            if (DriverID <= 0 || LicenseClassID <= 0)
            {
                return false;
            }
            string Query = $"select case when exists " +
                $"(select 1 from Licenses where DriverID = @DriverID and IsActive=1 and LicenseClass=@LicenseClass) then 1 else 0 end as Result";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@DriverID", value: DriverID);
            command.Parameters.AddWithValue(parameterName: "@LicenseClass", value: LicenseClassID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (int.TryParse(Result.ToString(), out int res))
                {
                    return (res == 1);
                }
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
        public static DLMS.EntitiesNamespace.Entities.ClsDriver? GetDriverById(int DriverID)
        {
            if (DriverID <= 0)
            {
                return null;
            }
            string Query = $"select top 1 * from Drivers where DriverID = @Value";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: DriverID);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if(Reader.Read() && Reader.HasRows)
                {
                    return new DLMS.EntitiesNamespace.Entities.ClsDriver(Reader.GetInt32(Reader.GetOrdinal("DriverID")),
                                                                         Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                                                                         Reader.GetInt32(Reader.GetOrdinal("CreatedByUserID")),                            
                                                                         Reader.GetDateTime(Reader.GetOrdinal("CreatedDate")) );}}

            catch (Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
                connection.Close();
            }
            return null;
        }      
        public static DataTable? GetAllDriverLicenses(int DriverID)
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = @$"select Licenses.LicenseID,
                              Licenses.ApplicationID,
                              LicenseClasses.ClassName,
                              Licenses.IssueDate,
                              Licenses.ExpirationDate,
                              Licenses.IsActive
                              from Licenses
                              inner join LicenseClasses on LicenseClasses.LicenseClassID = Licenses.LicenseClass
                              where Licenses.DriverID=@ID";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@ID", DriverID);
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
        public static DataTable? GetAllInternationalDriverLicenses(int DriverID)
        {

            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = @$"select InternationalLicenses.InternationalLicenseID,
                              InternationalLicenses.ApplicationID,
                              InternationalLicenses.IssuedUsingLocalLicenseID,
                              InternationalLicenses.IssueDate,
                              InternationalLicenses.ExpirationDate,
                              InternationalLicenses.IsActive
                              from InternationalLicenses	  
                              where InternationalLicenses.DriverID =@ID";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@ID", DriverID);
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
