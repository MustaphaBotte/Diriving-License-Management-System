using Microsoft.Data.SqlClient;
using DLMS.EntitiesNamespace;
using System.Data;
using DLMS.Data_access.ConnectionSettings;

namespace DLMS.Data_access.Person
{         
    public static class PersonData
    {
        public static readonly string LogFilePath = @"D:\C# Projects\Course 19\DLMS\DLMS\Data_Access\Data_access\Person\Logs.txt";
        public static Entities.ClsPerson? FindPerson(int ID = -1, string NationalNo = "")
        {
            if (ID <=0 && string.IsNullOrEmpty(NationalNo))
            {
                return null;
            }
            string Attribut = (ID == -1) ? "NationalNo" : "PersonId";
            string Query = $"select * from people where {Attribut} = @Value";

            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: SharedFunctions.GetValueForQuery(ID, NationalNo));

            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    return new Entities.ClsPerson(Convert.ToInt32(Reader["PersonID"]),
                                         (string)Reader["NationalNo"],
                                         (string)Reader["FirstName"],
                                         (string)Reader["SecondName"],
                                         Reader["ThirdName"]?.ToString(),
                                         Reader["LastName"].ToString(),
                                         Convert.ToDateTime(Reader["DateOfBirth"]),
                                         Convert.ToByte(Reader["Gender"]),
                                         (string)Reader["Address"],
                                         (string)Reader["Phone"],
                                         Reader["Email"].ToString(),
                                         Convert.ToInt16(Reader["NationalityCountryID"]),
                                         DLMS.Data_access.Country.CountryData.FindCountry(Convert.ToInt16(Reader["NationalityCountryID"])),
                                         Reader["ImagePath"]?.ToString());
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
        public static int DeletePerson(int ID = -1, string NationalNo = "")
        {
            if (ID <=0 && string.IsNullOrEmpty(NationalNo))
            {
                return 0;
            }
            string Attribut = (ID == -1) ? "NationalNo" : "PersonId";
            string Query = $"delete from people where {Attribut} = @Value";
            SqlConnection connection = new SqlConnection(connectionString:ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: SharedFunctions.GetValueForQuery(ID, NationalNo));
            try
            {
               
                connection.Open();
                if (command.ExecuteNonQuery() > 0)
                    return 1;
            }
            catch (SqlException EX)
            {
                if(EX.Number == 547) //Foreign Key Violation
                {
                    return -1;
                }
                                
                DLMS.Data_access.SharedFunctions.WriteError(LogFilePath, EX);
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
        public static bool Exists(int ID = -1, string NationalNo = "")
        {
            if (ID <=0 && string.IsNullOrEmpty(NationalNo))
            {
                return false;
            }
            string Attribut = (ID == -1) ? "NationalNo" : "PersonId";
            string Query = $"select case when exists (select 1 from People where People.{Attribut} = @Value) then 1 else 0 end as Result";

            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            command.Parameters.AddWithValue(parameterName: "@Value", value: SharedFunctions.GetValueForQuery(ID, NationalNo));

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
        public static bool UpdatePerson(Entities.ClsPerson NewObj, ref string message)
        {
            Entities.ClsPerson? OldObj = FindPerson(NewObj.PersonId);
            Dictionary<string, object>? DiffColumns = SharedFunctions.GetDiff(NewObj, OldObj, ref message);

            //true so tell the user that we update nothing
            if (DiffColumns == null)
                return true;

            string Query = $"update people set ";
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
        public static int AddPerson(Entities.ClsPerson person, ref string message)
        {
            if (person == null)
            {
                message = "Error :This Object Is Null";
                return -1;
            }
            if (Exists(NationalNo: person.NationalNo))
            {
                message = $"Error :This Person With National NUmber = {person.NationalNo} Already Exists";
                return -1;
            }
            if (!SharedFunctions.CheckDataMatchWithTable(person, TableName: "People"))
            {
                message = $"Error :Please Respect The Required Attributs";
                return -1;
            }
            if (person.DateOfBirth < new DateTime(1850, 1, 1))
            {
                message = $"Error :Please Give a Valid Birth Date (Date Must be greater than 1850-1-1)";
                return -1;
            }

            string Query = " insert into People values(@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName," +
                " @DateOfBirth, @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);SELECT SCOPE_IDENTITY()";

            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            SqlCommand command = new SqlCommand(connection: connection, cmdText: Query);

            command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
            command.Parameters.AddWithValue("@FirstName", person.FirstName);
            command.Parameters.AddWithValue("@SecondName", person.SecondName);
            command.Parameters.AddWithValue("@ThirdName", person.ThirdName);
            command.Parameters.AddWithValue("@LastName", person.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Phone", person.Phone);
            command.Parameters.AddWithValue("@Email", person.Email);
            command.Parameters.AddWithValue("@NationalityCountryID", person.NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", person.ImagePath);
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
        public static DataTable? GetAllPeople()
        {
            DataTable People = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString.GetConnectionString());
            string Query = @"select 
                              People.PersonID, People.NationalNo,
                              People.FirstName,People.SecondName, 
                              People.ThirdName,People.LastName, 
                              case when People.Gender=0 then 'Male' else 'Female' end as Gender,
                              People.DateOfBirth,                             
                              People.Address,
                              people.phone,
                              People.Email,
                              People.NationalityCountryID,
                              Countries.CountryName,
                              People.ImagePath
                              from people inner join countries on nationalitycountryid = 
                              countries.countryid";
            SqlCommand command = new SqlCommand(cmdText: Query, connection: connection);
            SqlDataReader? Reader = null;
            try
            {
                connection.Open();
                Reader = command.ExecuteReader();
                if (Reader != null && Reader.HasRows)
                {
                    People.Load(Reader);
                    return People;
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

    }
}
