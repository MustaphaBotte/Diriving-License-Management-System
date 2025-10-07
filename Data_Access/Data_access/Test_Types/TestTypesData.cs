using DLMS.Data_access;
using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
using System.Data;
using DLMS.Data_access.ConnectionSettings;


namespace DLMS.Data_access.Test_Types
{
    public class TestTypesData
    {
        private static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\Applications_Types\LogFile.txt";
        public static Entities.ClsTestType? GetTestTypeById(int TestTypeID)
        {
            if (TestTypeID <=0)
                return null;
 
            string query = $"select top 1 * from TestTypes where TestTypeID = @Value ";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: query, connection: connection);
            command.Parameters.AddWithValue("@Value", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Entities.ClsTestType((Entities.EnTestType)Convert.ToInt32(reader["TestTypeID"]),
                                                           (string)reader["TestTypeTitle"],
                                                           (string)reader["TestTypeDescription"],
                                                           Convert.ToDecimal(reader["TestTypefees"].ToString())
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
        public static DataTable? GetAllTestTypes()
        {


            string query = $"select * from testtypes";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
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
                    return null;
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
        public static bool UpdateTestType(Entities.ClsTestType UpdatedObj)
        {

            string message = "";
            Entities.ClsTestType? OldObj = GetTestTypeById((int)UpdatedObj.TestTypeID);
            Dictionary<string, object>? DiffColumns = SharedFunctions.GetDiff(UpdatedObj, OldObj, ref message);

            //true; we tell the user that we update with success // but actually there is no changes to commit
            if (DiffColumns == null)
                return true;

            string Query = $"update testtypes set ";
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
                Query += $"{ListDiffColumns[i].Key} = @Value{i} where testTypeId ={UpdatedObj.TestTypeID}";
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

    }
}
