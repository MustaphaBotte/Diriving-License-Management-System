using DLMS.Data_access.ConnectionSettings;
using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;


namespace DLMS.Data_access.Applications
{
    public class ApplicationData
    {
        private static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\Applications\Logs.txt";
      
        public static bool Exists(int AppId)
        {
            if (AppId <= 0 )
            {
                return false;
            }
            string Attribut =  "ApplicationId";
            string Query = $"select case when exists (select 1 from Applications where Applications.{Attribut} = @Value) then 1 else 0 end as Result";

            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: AppId);

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
        public static int AddNewApplication(Entities.ClsApplication application, ref string message)
        {
            if (application == null)
            {
                message = "Error :This Object Is Null";
                return -1;
            }
           
            if (!SharedFunctions.CheckDataMatchWithTable(application, TableName: "Applications"))
            {
                message = $"Error :Please Respect The Required Attributs";
                return -1;
            }
           

            string Query = " insert into Applications values(@Applicantpersonid, @Applicaiondate, @Applicationdtypeid, " +
                "@applicationStatus, @LastStatusDate," +
                " @PaidFees, @CreatedByUserID); SELECT SCOPE_IDENTITY()";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);
            command.Parameters.AddWithValue("@Applicantpersonid", application.ApplicantPersonId);
            command.Parameters.AddWithValue("@Applicaiondate", application.ApplicantionDate);
            command.Parameters.AddWithValue("@Applicationdtypeid", application.ApplicationTypeId);
            command.Parameters.AddWithValue("@applicationStatus", application.ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", application.LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", application.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserId);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result.ToString(), out int res) ? res : -1;
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
        public static Entities.ClsApplication? GetApplicationByID(int AppID)
        {
            string Query = "select * from applications where applicationid = @ApplicationID";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);
            command.Parameters.AddWithValue("@ApplicationID", AppID);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows && Reader.Read())
                {
                    return new Entities.ClsApplication(
                                                     Convert.ToInt32(Reader["ApplicationID"]),
                                                     Convert.ToInt32(Reader["ApplicantPersonid"]),
                                                     Convert.ToDateTime(Reader["Applicationdate"]),
                                                     Convert.ToInt16(Reader["Applicationtypeid"]),
                                                     Convert.ToByte(Reader["ApplicationStatus"]),
                                                     Convert.ToDateTime(Reader["laststatusdate"]),
                                                     Convert.ToDecimal(Reader["PaidFees"]),
                                                     Convert.ToInt32(Reader["Createdbyuserid"])
                                                     );
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
            return null;
        }
        public static int  DeleteApplication (int applicationId)
        {
           

            string Query = " delete from applications where applicationid = @Value";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);
            command.Parameters.AddWithValue("@Value", applicationId);
           
            try
            {
                connection.Open();
                if(command.ExecuteNonQuery()>0)
                {
                    return 1;
                }
            }
            catch (SqlException EX)
            {
                if (EX.Number == 547) //Foreign Key Violation
                {
                    return -1;
                }
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
        public static bool SetApplicationStatus(int AppID, byte Status)
        {
            if (Status > 3 || Status <= 0)
                return false;
            string Query = "update applications set ApplicationStatus = @Status , LastStatusDate = @Date where ApplicationID =@ApplicationID";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@ApplicationID", AppID);
            command.Parameters.AddWithValue("@Date", DateTime.Now);
            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();              
                return RowsAffected>0;
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
        public static int  GetApplicationStatusByID(int AppID)
        {
            string Query = "select top 1 Applicationstatus from applications where applicationid = @ApplicationID";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);
            command.Parameters.AddWithValue("@ApplicationID", AppID);
            try
            {
                connection.Open();
                object Res = command.ExecuteScalar();
                int Status = int.TryParse(Res?.ToString(), out int Val) ? Val : 0;
                return Status;
            }
            catch (Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }



    }
}
