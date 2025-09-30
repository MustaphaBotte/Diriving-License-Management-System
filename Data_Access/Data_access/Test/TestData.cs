using DLMS.Data_access.ConnectionSettings;
using DLMS.Data_access;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DLMS.EntitiesNamespace;

namespace DLMS.Data_access.Test
{
    public class TestData
    {
      private static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\Test\Logs.txt";
      
        public static bool HasOpenAppointmentByLocDriLicAppID(int DriLicAppID, int TestTypeID)
        {
            string Query = $"select case when exists (select top 1  1 from TestAppointments where testTypeID =@Value and testappointments.LocalDrivingLicenseApplicationID = @Value2 and Islocked=0)" +
                $" then 1 else 0 end as Result";

            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", TestTypeID);
            command.Parameters.AddWithValue(parameterName: "@Value2", DriLicAppID);

           
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
       
        public static Entities.ClsTest? GetTestByAppointmentID(int TestAppointmentid)
        {

            string Query = " select top 1 * from tests where Testappointmentid = @ID";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@ID", TestAppointmentid);


            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows && Reader.Read())
                {
                    return new Entities.ClsTest(Convert.ToInt32(Reader["TestID"]),
                                                           Convert.ToInt32(Reader["TestAppointmentid"]),
                                                           Convert.ToBoolean(Reader["TestResult"]),
                                                           Reader["Notes"].ToString(),
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
                connection.Close();
            }
            return null;







        }
        public static bool IsFailedBeforeInTest(int DriLicAppID, int TestTypeID )
        {
           
         
            string Query = $@"select case when exists(
                                                     select Tests.TestResult
                                                     from TestAppointments
                                                     inner join Tests on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                                     where
                                                     TestAppointments.LocalDrivingLicenseApplicationID = @LocDLA_ID
                                                     and TestAppointments.TestTypeID = @TestTypeID
                                                     and Tests.TestResult = 0
                                                     ) 
                                                     then 1
                                                     else 0
                                                     end as Result";
            // if query returned 1 that means he failed before
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@LocDLA_ID", DriLicAppID);
            command.Parameters.AddWithValue(parameterName: "@TestTypeID", TestTypeID);

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
        public static bool IsSucceededBeforeInTest(int DriLicAppID, int TestTypeID)
        {
            string Query = $@"select case when exists(
                                                     select Tests.TestResult
                                                     from TestAppointments
                                                     inner join Tests on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                                     where
                                                     TestAppointments.LocalDrivingLicenseApplicationID = @LocDLA_ID
                                                     and TestAppointments.TestTypeID = @TestTypeID 
                                                     and Tests.TestResult = 1
                                                     ) 
                                                     then 1
                                                     else 0
                                                     end as Result";
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@LocDLA_ID", DriLicAppID);
            command.Parameters.AddWithValue(parameterName: "@TestTypeID", TestTypeID);
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

        public static decimal GetTestFees(int TestTypeID)
        {
           
            string Query = $"select  TestTypes.TestTypeFees from TestTypes where TestTypes.TestTypeID = @TestTypeID";
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (decimal.TryParse(Result.ToString(), out decimal res))
                {
                    return res;
                }
                return 0m;
            }
            catch (Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
                connection.Close();
            }
            return 0m;
        }

        public static int HowManyTimeFailed(int DriLicAppID,int TestTypeID)
        {
            string Query = $@"select Count(R1.TestResult) from 
                                                          (select Tests.TestResult 
                                                          from TestAppointments
                                                          inner join Tests on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                                          where
                                                          TestAppointments.LocalDrivingLicenseApplicationID=@LocDLA_ID
                                                          and TestAppointments.TestTypeID=@TestTypeID
                                                          )R1";
            // if query returned 1 that means he succeded before
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@LocDLA_ID", DriLicAppID);
            command.Parameters.AddWithValue(parameterName: "@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (int.TryParse(Result.ToString(), out int res))
                {
                    return res;
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
            return -1;
        }

        public static int AddNewTest(Entities.ClsTest Test)
        {
            string Query = "insert into Tests values(@TestAppointmentId, @TestResult, @Notes," +
            " @CreatedByUserId) ; select SCOPE_IDENTITY(); ";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@TestAppointmentId", Test.TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", Test.TestResult);
            command.Parameters.AddWithValue("@Notes", Test.Notes==""?DBNull.Value:Test.Notes);
            command.Parameters.AddWithValue("@CreatedByUserId", Test.CreatedByUserID);

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
                return -1;
            }
            finally
            {
                connection.Close();
            }

        }

       
    }
}
