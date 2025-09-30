using DLMS.Data_access.ConnectionSettings;
using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMS.Data_access.Appointments
{
    public class TestAppointmentsData
    {
        private static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\TestAppointments\LogFile.txt";

        public static DataTable? GetAllAppointmentsBy_LDLAID_AndTestTypeID(int LocDLA_ID, int TestTypeID)
        {


            DataTable Appointments = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: "select * from testAppointments where localdrivingLicenseApplicationID = @LocID and TestTypeID = @TestID",
             connection: connection);
            command.Parameters.AddWithValue("@LocID", LocDLA_ID);
            command.Parameters.AddWithValue("@TestID", TestTypeID);

            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                if (Reader != null && Reader.HasRows)
                {
                    Appointments.Load(Reader);
                    return Appointments;
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

        public static int AddNewAppointment(Entities.ClsTestAppointment TestAppointment)
        {

            string Query = "insert into TestAppointments values(@TestTypeId, @LocalDrivinglicenseApplicationId, @AppointmentDate," +
                " @PaidFees, @CreatedByUserId,@IsLocked,@RetakeTestApplicationID) ; select SCOPE_IDENTITY(); ";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@TestTypeId", TestAppointment.TestTypeId);
            command.Parameters.AddWithValue("@LocalDrivinglicenseApplicationId", TestAppointment.LocDLA_ID);
            command.Parameters.AddWithValue("@AppointmentDate", TestAppointment.TestAppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", TestAppointment.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserId", TestAppointment.CreatedByUserId);
            command.Parameters.AddWithValue("@IsLocked", 0);
            command.Parameters.AddWithValue("@RetakeTestApplicationID", TestAppointment.RetakeApplicationID==null?DBNull.Value: TestAppointment.RetakeApplicationID);
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

        public static bool IsExists(int AppointmentID)
        {
            if (AppointmentID <= 0)
            {
                return false;
            }
            string Query = $"select case when exists " +
                $"(select 1 from TestAppointments where TestAppointmentID= @Value) then 1 else 0 end as Result";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: AppointmentID);

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
        public static Entities.ClsTestAppointment? GetAppointmentById(int AppointmentID)
        {
            string Query = " select top 1 * from testappointments where Testappointmentid = @ID";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@ID", AppointmentID);
  

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if(Reader.HasRows && Reader.Read())
                {
                    return new Entities.ClsTestAppointment(Convert.ToInt32(Reader["TestAppointmentID"]),
                                                           Convert.ToInt32(Reader["TestTypeID"]),
                                                           Convert.ToDateTime(Reader["appointmentDate"]),
                                                           Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]),
                                                           Convert.ToBoolean(Reader["IsLocked"]),
                                                           Convert.ToDecimal(Reader["paidFees"]),
                                                           Convert.ToInt32(Reader["CreatedByUserId"]),
                                                           (int?)(Reader["RetakeTestApplicationID"] == DBNull.Value ? null :Reader["RetakeTestApplicationID"])
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

        public static bool LockTestAppointment(int AppointmentID)
        {

            string Query = "update TestAppointments set ISlocked = 1 where "+
               "TestAppointmentID = @TestAppId";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@TestAppId", AppointmentID);
           
            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                return RowsAffected>0;
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
        public static bool IsAppointmentLocked(int AppointmentID)
        {
            string Query = "select case when exists (" +
                "select top 1 1 from TestAppointments where TestAppointmentID=@TestAppId and IsLocked = 1)"
                + " then 1 else 0 end as result"; 
             
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@TestAppId", AppointmentID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result?.ToString(), out int res) ? res : -1;
                return ID ==1;
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
        public static bool EditTestAppointmentDateByAppointmentID(int AppointmentID, DateTime NewDate)
        {
            string Query = "update testAppointments set AppointmentDate = @NewDateTime where TestAppointmentID = @ID ";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

     
            command.Parameters.AddWithValue("@NewDateTime", NewDate);
            command.Parameters.AddWithValue("@ID", AppointmentID);
            try
            {
                connection.Open();
                return command.ExecuteNonQuery()>0;           
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



    }
}
