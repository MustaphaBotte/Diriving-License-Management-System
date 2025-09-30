using DLMS.Data_access.ConnectionSettings;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;


namespace DLMS.Data_access.LicenceClasses
{
    public class LicenceClass
    {
        private static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\LicenceClasses\LogsFile.txt";

        public static DataTable? GetAllLicenseClasses()
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "select * from licenseclasses";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                DataTable Licenses = new DataTable();
                if (Reader != null && Reader.HasRows)
                {
                    Licenses.Load(Reader);
                    return Licenses;
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
        public static List<short> GetlisenceStatusOfAperson(int personID , int LicenseClassId)
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query ="select  App.ApplicationStatus "+
                          "from LocalDrivingLicenseApplications Loc "+
                          "inner join Applications App on App.ApplicationID = Loc.ApplicationID "+
                          " where App.ApplicantPersonID = @PrsnID and Loc.LicenseClassID = @LicClassID";

            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@PrsnID", personID);
            command.Parameters.AddWithValue("@LicClassID", LicenseClassId);


            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                List<short> ApplicationStatus = new List<short>();
                if (Reader.HasRows)
                {
                    while(Reader.Read())
                    {
                        ApplicationStatus.Add(Convert.ToInt16(Reader["ApplicationStatus"]));
                    }
                }
                return ApplicationStatus;
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
            return new List<short>();

        }
        public static decimal GetlisenceFees(int LicenseClassId)
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "select top 1 ClassFees from LicenseClasses where LicenseClassID= @ID";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@ID", LicenseClassId);
            try
            {
               connection.Open();
               return decimal.TryParse(command.ExecuteScalar().ToString(), out decimal Val)?Val: -1;
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
        public static int GetlisenceValidityLength(int LicenseClassId)
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "select top 1 DefaultValidityLength from LicenseClasses where LicenseClassID= @ID";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@ID", LicenseClassId);
            try
            {
                connection.Open();
                return int.TryParse(command.ExecuteScalar().ToString(), out int Val) ? Val : -1;
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
        public static short GetMinAllowedAge(int LicenseClassId)
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = "select  LicenseClasses.MinimumAllowedage from LicenseClasses where licenseClassId= @LicClassID";

            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@LicClassID", LicenseClassId);


            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                int MinAge= int.TryParse(command.ExecuteScalar()?.ToString(),out int VAl)?VAl:-1;
                return (short)MinAge;
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
            return -1;
        }
        public static EntitiesNamespace.Entities.ClsLicenseClass? GetLicenseClassByID(int LicenseClassId=-1,string ClassName="")
        {
            if(LicenseClassId<=0 && ClassName=="")
            {
                return null;
            }
            string attribut = LicenseClassId <= 0 ? "classname" : "licenseclassid";
            object value =  LicenseClassId <= 0 ? ClassName : LicenseClassId;

            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = $"select top 1 * from licenseclasses where {attribut} =@Value";

            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue("@Value", value);


            SqlDataReader? reader = null;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                List<short> ApplicationStatus = new List<short>();
                if (reader.HasRows && reader.Read())
                {
                      return new EntitiesNamespace.Entities.ClsLicenseClass(
                                                                           Convert.ToInt32(reader["LicenseClassID"]),
                                                                           Convert.ToString(reader["ClassName"])??"Unknown",
                                                                           Convert.ToString(reader["ClassDescription"]) ?? "Unknown",
                                                                           Convert.ToByte(reader["MinimumAllowedAge"]),
                                                                           Convert.ToByte(reader["DefaultValidityLength"]),
                                                                           Convert.ToDecimal(reader["ClassFees"])
                                                                          );          
                }
            }
            catch (Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
               reader?.Close();
                connection.Close();

            }
            return null;







        }

       

    }
}
