using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using DLMS.Data_access.ConnectionSettings;


namespace DLMS.Data_access
{
    internal static class SharedFunctions
    {
        private static Dictionary<string, string> CachedTableSchema = null;
        private static string TableName = "";

        private static string LogPath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\SharedFunctions\Log.txt";
        public static void WriteError(string LogFilePath, Exception EX)
        {
            if(!File.Exists(LogFilePath))
            {
                return;
            }

            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine("Date Time  :" + DateTime.Now.ToString());
                writer.WriteLine("Error      :" + EX.Message);
                writer.WriteLine("StackTrace :" + EX.StackTrace);
                writer.WriteLine("\n\n====================================================================================================================");
            }

        }
        public static Dictionary<string, string>? GetTableSchema(string TableName)
        {
            // make sure that we return the same table schema when cashing
            if (CachedTableSchema != null && TableName == SharedFunctions.TableName)
            {
                return CachedTableSchema;
            }


            string Query = "select COLUMN_NAME, IS_NULLABLE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName";
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(@"TableName", TableName);

            Dictionary<string, string>? Schema = new Dictionary<string, string>();
            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                   Schema[(string)Reader[0]] = (string)Reader[1];
                }
                CachedTableSchema = Schema;
                SharedFunctions.TableName = TableName;
                if(Schema.Count>0)
                    return Schema;
                return null;


            }
            catch (Exception EX)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogPath,EX);
            }
            finally
            {
                connection.Close();
            }
            return null;
        }
        public static bool CheckObjectIsNull(object Obj)
        {
            if (Obj == null)
                return true;
            if (Obj.ToString() == "")
                return true;
            return false;
        }
        public static bool CheckDataMatchWithTable(object NewObj,string TableName)
        {
            if (NewObj == null)
                return false;
            Dictionary<string, string>? TableSchema = Data_access.SharedFunctions.GetTableSchema(TableName);

            if (TableSchema == null)
            { 
                return false;
            }


            PropertyInfo[] objectProperties = NewObj.GetType().GetProperties();

            for (byte i = 1; i < TableSchema.Count; i++)
            {
                if (SharedFunctions.CheckObjectIsNull(objectProperties[i].GetValue(NewObj)) && TableSchema[objectProperties[i].Name] == "NO")
                {
                    return false;
                }
            }

            return true;
        }
        public static Dictionary<string, object>? GetDiff(object NewObj, object OldObj, ref string message)
        {
            message = "";
            if (OldObj == null || NewObj == null)
            {
                return null;
            }
            //get the table schema (column name and nullable status)
            Dictionary<string, string>? TableSchema = Data_access.SharedFunctions.GetTableSchema(TableName: "people");

            if (TableSchema == null)
            {
                message = "Error: Unable to retrieve table schema.";
                return null;
            }

           


            // get the properties of each object
            PropertyInfo[] objectProperties = OldObj.GetType().GetProperties();

            Dictionary<string, object> Diff = new Dictionary<string, object>();

            for (byte i = 1; i < OldObj.GetType().GetProperties().Length; i++)
            {
                object? OldobjectValue = objectProperties[i].GetValue(OldObj);
                object? NewobjectValue = objectProperties[i].GetValue(NewObj);
                string PropName = objectProperties[i].Name;


                if (!Equals(OldobjectValue, NewobjectValue))
                {
                    //check if the updates column does not contain null for a column in db that not allow null
                    if (SharedFunctions.CheckObjectIsNull(NewobjectValue) && TableSchema[PropName] == "NO")
                    {
                        message = $"The Attribut :{PropName} Cannot Be Null";
                        return null;
                    }
                    Diff[PropName] = SharedFunctions.CheckObjectIsNull(NewobjectValue) ? DBNull.Value : NewobjectValue;
                }
            }
            if (Diff.Count == 0)
            {
                return null;
            }

            return Diff;
        }        
        public static object GetValueForQuery(int ID = -1, string Name = "")
        {
            if (ID == -1 && Name !="")
            {
                return Name;
            }
            else if(ID != -1)
            {
                return ID;
            }
            return new object();
        }

       // public static string GenerateAauid()



    }
}
