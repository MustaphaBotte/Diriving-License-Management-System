using DLMS.Data_access;
using DLMS.EntitiesNamespace;
using DLMS.Data_access.ConnectionSettings;
using Microsoft.Data.SqlClient;
using System.Data;


namespace DLMS.Data_access.Applications_Types
{
    public class AppLicationsTypesData
    {
        private static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\Applications_Types\LogFile.txt";
        public static Entities.ClsApplicationType? GetApplicationTypeByIdOrName(int AppTypeID=-1 , string AppTypeName="")
        {
            if (AppTypeID == -1 && AppTypeName == "")
                return null;
            string Attribut = AppTypeID == -1 ? "applicationTypeTitle" : "applicationTypeid";
            object Value = SharedFunctions.GetValueForQuery(AppTypeID, AppTypeName);
            string query = $"select top 1 * from applicationtypes where {Attribut} = @Value ";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText:query, connection: connection);
            command.Parameters.AddWithValue("@Value", Value);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    return new Entities.ClsApplicationType(Convert.ToInt32(reader["applicationtypeid"]),
                                                           (string)reader["applicationTypeTitle"],
                                                           Convert.ToSingle(reader["applicationfees"].ToString())
                                                           );
                }
            }
            catch(Exception EX)
            {
                SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
                connection.Close();
            }
            return null;
        }
        public static DataTable? GetAllApplicationTypes()
        {
           
            
            string query = $"select * from applicationtypes";
            SqlConnection connection = new SqlConnection( ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: query, connection: connection);
            try
            {
                DataTable Table = new DataTable();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Table.Load(reader);
                    if (Table.Rows.Count > 0)
                    {
                        return Table;
                    }
                }
                return null;
                
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
        public static bool UpdateApplicationType(Entities.ClsApplicationType UpdatedObj)
        {

            string message = "";
            Entities.ClsApplicationType? OldObj = GetApplicationTypeByIdOrName(UpdatedObj.ApplicationTypeId);
            Dictionary<string, object>? DiffColumns = SharedFunctions.GetDiff(UpdatedObj, OldObj, ref message);

            //true so tell the user that we update nothing
            if (DiffColumns == null)
                return true;

            string Query = $"update applicationtypes set ";
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);

            List<KeyValuePair<string, object>> ListDiffColumns = DiffColumns.ToList();
            for (int i = 0; i < ListDiffColumns.Count; i++)
            {
                if (i != ListDiffColumns.Count - 1)
                {
                    Query += $"{ListDiffColumns[i].Key} = @Value{i} ,";
                    command.Parameters.AddWithValue(parameterName: $@"Value{i}", value: ListDiffColumns[i].Value);

                    continue;
                }
                Query += $"{ListDiffColumns[i].Key} = @Value{i} where ApplicationTypeId ={UpdatedObj.ApplicationTypeId}";
                command.Parameters.AddWithValue(parameterName: $@"Value{i}", value: ListDiffColumns[i].Value);

            }
            command.CommandText = Query;
            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                return (RowsAffected > 0);
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
        public static decimal GetFeesOfApplication(int AppTypeID = -1)
        {
            if (AppTypeID <=0 )
                return 0m;

          
            string query = $"select top 1 Applicationfees from applicationtypes where applicationtypeid = @Value ";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: query, connection: connection);
            command.Parameters.AddWithValue("@Value", AppTypeID);
            try
            {
                connection.Open();
                object Price = command.ExecuteScalar();
                decimal Fees = decimal.TryParse(Price.ToString(), out decimal Res)? Res: 0m;
                return Fees;
            }
            catch (Exception EX)
            {
                SharedFunctions.WriteError(LogFilePath, EX);
                return 0m;
            }
            finally
            {
                connection.Close();
            }
           // return 0m;

        }

        public static string? GetApplicationTypeByID(int AppID)
        {
            string Query = "select ApplicationTypeTitle from applications inner join " +
                "applicationtypes on applicationtypes.applicationTypeid = applications.applicationtypeid" +
                "  where applications.applicationid = @ApplicationID";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);
            command.Parameters.AddWithValue("@ApplicationID", AppID);
            try
            {
                connection.Open();
                string? ApptypeName = Convert.ToString(command.ExecuteScalar());
                return ApptypeName;

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
    }
}
