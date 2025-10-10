using DLMS.Data_access.ConnectionSettings;
using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMS.Data_access.localDrivingLicenseApplication
{
    public class localDrivingLicenseApplicationData
    {
        private static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\LocDrivingLicenseApplication\Logs.txt";
        public static DataTable? GetAllLocalApplications()
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "select * from My_LocalDLAView order by applicationDate DESC";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                DataTable Applications = new DataTable();
                if (Reader != null && Reader.HasRows)
                {
                    Applications.Load(Reader);
                    return Applications;
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
        public static int AddNewLocalDrivLicenApp(int ApplicationID , int LicenseClassId,ref string message)
        {
            
            string Query = " insert into LocalDrivingLicenseApplications values(@ApplicationID, @LicenseClassID); SELECT SCOPE_IDENTITY()";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassId);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result.ToString(), out int res) ? res : -1;
                return ID;
            }
            catch (Exception Sq)
            {
                message = Sq.Message;
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, Sq);
                return 0; // Cannot Add, foreign key constraint violation or error
            }
            finally
            {
                connection.Close();
            }
         
        }
        public static int InsertLocDriApp_ByAppIDAndLicClass(int AppID,int ClassID)
        {

            string Query = " insert into LocalDrivingLicenseApplications values(@ApplicationID, @LicenseClassID); SELECT SCOPE_IDENTITY()";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);
            command.Parameters.AddWithValue("@ApplicationID", AppID);
            command.Parameters.AddWithValue("@LicenseClassID", ClassID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result.ToString(), out int res) ? res : -1;
                return ID;
            }
            catch (Exception Sq)
            {
                // in this case we have to delete the stored application
                DLMS.Data_access.Applications.ApplicationData.DeleteApplication(AppID);
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, Sq);
                return 0; // Cannot Add, foreign key constraint violation or error
            }
            finally
            {
                connection.Close();
            }
        }
      
        public static Entities.ClsLocDriApplication? GetLocDriLicAppInfo(int LocDriAppID)
        {
            if (LocDriAppID <= 0)
                return null;

            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "select LocalDrivingLicenseApplications.* ,Applications.* from LocalDrivingLicenseApplications " +
                " inner join applications on applications.ApplicationId= LocalDrivingLicenseApplications.applicationID" +
                " where LocalDrivingLicenseApplicationID = @ID";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@ID", LocDriAppID);
            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                if (Reader != null && Reader.HasRows && Reader.Read())
                {
                    return new Entities.ClsLocDriApplication(
                                                             Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]),
                                                             Convert.ToInt32(Reader["ApplicationID"]),
                                                             Convert.ToInt32(Reader["LicenseClassID"]),
                                                             Convert.ToInt32(Reader["ApplicantPersonID"]),
                                                             Convert.ToDateTime(Reader["ApplicationDate"]),
                                                             (DLMS.EntitiesNamespace.Entities.ClsApplication.enApplicationType)Convert.ToInt32(Reader["ApplicationTypeId"]),
                                                             (DLMS.EntitiesNamespace.Entities.ClsApplication.enApplicationStatus)Convert.ToInt32(Reader["ApplicationStatus"]),
                                                             Convert.ToDateTime(Reader["lastStatusDate"]),
                                                             Convert.ToDecimal(Reader["paidFees"]),
                                                             Convert.ToInt32(Reader["CreatedByUserId"])
                                                             );
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
        public static Entities.ClsLocDriApplication? GetLocDriLicAppInfoByApplicationID(int AppID)
        {
            if (AppID <= 0)
                return null;

            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "select LocalDrivingLicenseApplications.* ,Applications.* from LocalDrivingLicenseApplications " +
                " inner join applications on applications.ApplicationId= LocalDrivingLicenseApplications.applicationID" +
                " where LocalDrivingLicenseApplications.ApplicationID = @ID";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@ID", AppID);
            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                if (Reader != null && Reader.HasRows && Reader.Read())
                {
                    return new Entities.ClsLocDriApplication(
                                                             Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]),
                                                             Convert.ToInt32(Reader["ApplicationID"]),
                                                             Convert.ToInt32(Reader["LicenseClassID"]),
                                                             Convert.ToInt32(Reader["ApplicantPersonID"]),
                                                             Convert.ToDateTime(Reader["ApplicationDate"]),
                                                             (DLMS.EntitiesNamespace.Entities.ClsApplication.enApplicationType)Convert.ToInt32(Reader["ApplicationTypeId"]),
                                                             (DLMS.EntitiesNamespace.Entities.ClsApplication.enApplicationStatus)Convert.ToInt32(Reader["ApplicationStatus"]),
                                                             Convert.ToDateTime(Reader["lastStatusDate"]),
                                                             Convert.ToDecimal(Reader["paidFees"]),
                                                             Convert.ToInt32(Reader["CreatedByUserId"])
                                                             );
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

        public static bool Exists(int LocDriAppID)
        {
            if (LocDriAppID <= 0)
            {
                return false;
            }
            string Query = $"select case when exists (select 1 from My_LocalDLAView where My_LocalDLAView.LocDLA_ID = @Value) then 1 else 0 end as Result";

            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: LocDriAppID);

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

        public static int PassedTests(int LocDriAppID)
        {

            if (LocDriAppID <= 0)
                return -1;
            string Query = "select top 1 My_LocalDLAView.PassedTests from My_LocalDLAView where LOcDLA_ID = @ID";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@ID", LocDriAppID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result.ToString(), out int res) ? res : -1;
                return ID;
            }
            catch (Exception Ex)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, Ex);
                return -1;
            }
            finally
            {
                connection.Close();
            }



        }

        public static bool DeleteLocalApplication(int LocAppId)
        {

            if (LocAppId <= 0)
            {
                return false;
            }

            string Query = "delete from LocalDrivingLicenseApplications where LocDLA_Id = @Id";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@Id", LocAppId);

            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();

                return RowsAffected > 0;
            }
            catch (SqlException Sq)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, Sq);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public static int GetApplicationIdByLocDriId(int LocDriID)
        {
            if (LocDriID <= 0)
                return -1;
            string Query = " select applicationid from localdrivinglicenseapplications where " +
                "LocalDrivingLicenseApplicationID = @ID";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@ID", LocDriID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result.ToString(), out int res) ? res : -1;
                return ID;
            }
            catch (Exception Ex)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, Ex);
                return -1;
            }
            finally
            {
                connection.Close();
            }

        }
        public static int GetApplicantPersonIdByLocDriId(int LocDriID)
        {
            if (LocDriID <= 0)
                return -1;
            string Query = @$"select  ApplicantPersonID
                            from LocalDrivingLicenseApplications
                            inner join Applications on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                            where
                            LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @ID";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@ID", LocDriID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int PersonID = int.TryParse(Result.ToString(), out int res) ? res : -1;
                return PersonID;
            }
            catch (Exception Ex)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, Ex);
                return -1;
            }
            finally
            {
                connection.Close();
            }

        }
  
        public static bool IsLocalApplicationCanceled(int LocAppId)
        {
            string Query = @$"select case when exists
                            (
                            select top 1 Applications.ApplicationStatus from LocalDrivingLicenseApplications
                            inner join Applications on Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            where Applications.ApplicationStatus = 2
                            and LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocDLA_ID
                            )
                            then 1 else 0 end as result";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@LocDLA_ID", LocAppId);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result?.ToString(), out int res) ? res : -1;
                return ID == 1;
            }
            catch (Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool IsLocalApplicationCompleted(int LocAppId)
        {
            string Query = @$"select case when exists
                            (
                            select top 1 Applications.ApplicationStatus from LocalDrivingLicenseApplications
                            inner join Applications on Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            where Applications.ApplicationStatus = 3
                            and LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocDLA_ID
                            )
                            then 1 else 0 end as result";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@LocDLA_ID", LocAppId);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result?.ToString(), out int res) ? res : -1;
                return ID == 1;
            }
            catch (Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool HasNewOrCompletedLicenseType(int ApplicantPersonID, int LicenseClassID)
        {
            if (ApplicantPersonID <= 0 || LicenseClassID<=0)
            {
                return false;
            }
            string Query = @$"select case when Exists(select  top 1 1 from LocalDrivingLicenseApplications
                             inner join Applications on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                             where ApplicationStatus in (1,3)
                             and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID and
                             ApplicantPersonID= @ApplicantPersonID)
                             then 1 else 0 end as Result";

            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@LicenseClassID", value: LicenseClassID);
            command.Parameters.AddWithValue(parameterName: "@ApplicantPersonID", value: ApplicantPersonID);

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
        public static int  EditLocalDriLicApplicationClass(int Loc_DLA_ID, int NewLicenseClassID)
        {

            if (Loc_DLA_ID <= 0 || NewLicenseClassID<=0)
            {
                return 0;
            }
            string Query = " update  LocalDrivingLicenseApplications set LicenseClassID = @LicenseClassID where LocaldrivinglicenseApplicationID =@Loc_DLA_ID" +
                " ; SELECT SCOPE_IDENTITY()";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@Loc_DLA_ID", Loc_DLA_ID);
            command.Parameters.AddWithValue("@LicenseClassID", NewLicenseClassID);

            try
            {
                connection.Open();
                int Result = command.ExecuteNonQuery();               
                if(Result<=0)
                {
                    return 0;
                }
                return 1;
            }       
            catch(Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
                return 0; // Cannot Add,internal error
            }
            finally
            {
                connection.Close();
            }
        }


    }
}
