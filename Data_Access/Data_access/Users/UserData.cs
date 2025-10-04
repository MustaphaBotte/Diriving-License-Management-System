using DLMS.EntitiesNamespace;
using Microsoft.Data.SqlClient;
using System.Data;
using DLMS.Data_access.ConnectionSettings;

namespace DLMS.Data_access.Users
{
    public static class UserData
    {
        public static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\Users\Logs.txt";

        public static Entities.ClsUser? GetUserByIdOrUsername(int ID =-1 ,string username="")
        {
            if (ID <=0 && string.IsNullOrEmpty(username))
            {
                return null;
            }
            string Attribut = (ID == -1) ? "UserName" : "UserId";
            string Query = $"select * from users where {Attribut} = @Value";
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand( Query, connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: SharedFunctions.GetValueForQuery(ID, username));

            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    return new Entities.ClsUser(Convert.ToInt32(Reader["UserId"]),
                                         Convert.ToInt32(Reader["PersonId"]),
                                         (string)Reader["UserName"],
                                         (string)Reader["PassWord"],
                                         (bool)Reader["IsActive"]
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
        public static Entities.ClsUser? GetUserByUserandPass(string username, string pass)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass))
            {
                return null;
            }
            string Query = "select top 1  * from users where username = @username and password = @password";
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", pass);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    Entities.ClsUser User = new Entities.ClsUser((int)Reader["UserId"],
                                                 (int)Reader["PersonId"],
                                                 (string)Reader["UserName"],
                                                 (string)Reader["PassWord"],
                                                 (bool)Reader["isActive"]);       
                    return User;
                }
                return null;

            }
            catch (Exception ex)
            {
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, ex);
            }
            return null;
        }
        public static Entities.ClsUser? GetUserByPersonId(int PersonID)
        {
            if (PersonID <= 0)
            {
                return null;
            }
            string Attribut = "PersonId";
            string Query = $"select * from users where {Attribut} = @Value";
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: PersonID);

            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    return new Entities.ClsUser(Convert.ToInt32(Reader["UserId"]),
                                         Convert.ToInt32(Reader["PersonId"]),
                                         (string)Reader["UserName"],
                                         (string)Reader["PassWord"],
                                         (bool)Reader["IsActive"]
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

        public static bool Exists(int ID = -1, string username = "")
        {
            if (ID<=0 && string.IsNullOrEmpty(username))
            {
                return false;
            }
            string Attribut = (ID != -1) ? "UserId" : "username";
            string Query = $"select case when exists " +
                $"(select 1 from users where users.{Attribut} = @Value) then 1 else 0 end as Result";

            SqlConnection connection = new SqlConnection( ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: SharedFunctions.GetValueForQuery(ID, username));

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

        public static bool IsUserExistsByPersonId(int PersonID)
        {
            if (PersonID<=0)
            {
                return false;
            }
            string Attribut ="personid";
            string Query = $"select case when exists " +
                $"(select 1 from users where users.{Attribut} = @Value) then 1 else 0 end as Result";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value:PersonID);

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
        public static bool UpdateUser(Entities.ClsUser NewObj, ref string message)
        {
            Entities.ClsUser? OldObj = GetUserByIdOrUsername(NewObj.UserId);
            Dictionary<string, object>? DiffColumns = SharedFunctions.GetDiff(NewObj, OldObj, ref message);

            //true so tell the user that we update nothing
            if (DiffColumns == null)
                return true;

            string Query = $"update users set ";
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
                Query += $"{ListDiffColumns[i].Key} = @Value{i} where PersonID ={NewObj.PersonId}";
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

        public static int AddUser(Entities.ClsUser NewObj, ref string message)
        {
            if (NewObj == null)
            {
                message = "Error :This Object Is Null";
                return -1;
            }
            if (Exists(NewObj.UserId, NewObj.UserName))
            {
                message = $"Error :This User With username = {NewObj.UserName} Already Exists";
                return -1;
            }
            if (!SharedFunctions.CheckDataMatchWithTable(NewObj, TableName: "Users"))
            {
                message = $"Error :Please Respect The Required Attributs";
                return -1;
            }
            

            string Query = " insert into Users values(@PersonId, @Username, @password, @IsActive)" +
               " SELECT SCOPE_IDENTITY()";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@PersonId", NewObj.PersonId);
            command.Parameters.AddWithValue("@Username", NewObj.UserName);
            command.Parameters.AddWithValue("@password", NewObj.PassWord);
            command.Parameters.AddWithValue("@IsActive", NewObj.IsActive);
           
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                int ID = int.TryParse(Result.ToString(), out int res) ? res : -1;
                return ID;
            }
            catch (Exception EX)
            {
                message = EX.Message;
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }

        public static int DeleteUser(int ID = -1, string Username = "")
        {
            if (ID <=0 && string.IsNullOrEmpty(Username))
            {
                return 0;
            }
            string Attribut = (ID == -1) ? "username" : "userid";
            string Query = $"delete from users where {Attribut} = @Value";
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: SharedFunctions.GetValueForQuery(ID, Username));
            try
            {
                connection.Open();
               
                if (command.ExecuteNonQuery() > 0)
                {
                    
                    return 1;
                }
            }
           
            catch (SqlException Sq)
            {
                if (Sq.Number == 547) 
                {
                    return -1; // Cannot delete, foreign key constraint violation
                }
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, Sq);
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

        public static DataTable? GetAllusers()
        {
            DataTable Users = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: "select " +
                "u.userid,u.personid,u.username,p.firstname,p.lastname,u.isactive" +
                " from users u inner join people p on u.personid = p.personid", connection: connection);
            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                if (Reader != null && Reader.HasRows)
                {
                    Users.Load(Reader);
                    return Users;
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

        public static string? GetUserNameById(int UserId)
        {
            if (UserId <=0)
            {
                return null;
            }
            string Query = "select username from users where userid = @Value";
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"Value", UserId);
            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                string? UName = command.ExecuteScalar().ToString();              
                return UName;
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
