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
        public static Entities.ClsTestType? GetTestTypeByIdOrTitle(int TestTypeID = -1, string TestTypeTitle = "")
        {
            if (TestTypeID <=0 && TestTypeTitle == "")
                return null;
            string Attribut = TestTypeID == -1 ? "TestTypeTitle" : "TestTypeID";
            object Value = SharedFunctions.GetValueForQuery(TestTypeID, TestTypeTitle);
            string query = $"select top 1 * from TestTypes where {Attribut} = @Value ";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: query, connection: connection);
            command.Parameters.AddWithValue("@Value", Value);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Entities.ClsTestType(Convert.ToInt32(reader["TestTypeID"]),
                                                           (string)reader["TestTypeTitle"],
                                                           (string)reader["TestTypeDescription"],
                                                           Convert.ToSingle(reader["TestTypefees"].ToString())
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
            Entities.ClsTestType? OldObj = GetTestTypeByIdOrTitle(UpdatedObj.TestTypeId);
            Dictionary<string, object>? DiffColumns = SharedFunctions.GetDiff(UpdatedObj, OldObj, ref message);

            //true so tell the user that we update nothing
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
                Query += $"{ListDiffColumns[i].Key} = @Value{i} where testTypeId ={UpdatedObj.TestTypeId}";
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
