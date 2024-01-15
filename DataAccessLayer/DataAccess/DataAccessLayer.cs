using Core;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
namespace DataAccess
{
        public class DataAccessLayer : Disposable
        {
            public List<SqlParameter> Parameters { get; set; } = new List<SqlParameter>();
            private string connectionString { get; set; }
            public DataAccessLayer()
            {
                var Builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
                IConfiguration configuration = Builder.Build();
                connectionString = configuration.GetConnectionString("DBConnection");
            }
            public bool ExecuteNonQuery(string Command, CommandType CommandType = CommandType.StoredProcedure)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(Command, con);
                    cmd.CommandType = CommandType;
                    foreach (SqlParameter element in Parameters){
                        cmd.Parameters.Add(element);
                    }
                    con.Open();
                    var ErrorID = cmd.ExecuteNonQuery();
                    con.Close();
                    return ErrorID != 0;
                }
            }
            public List<T> ExecuteReader<T>(string Command, CommandType CommandType = CommandType.StoredProcedure)
            {
                var ListToBeReturned = new List<T>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(Command, con);
                    cmd.CommandType = CommandType;
                    foreach (SqlParameter element in Parameters)
                    {
                        cmd.Parameters.Add(element);
                    }
                    con.Open();
                    using SqlDataReader reader = cmd.ExecuteReader();
                    MapReaderToListObject(reader, ref ListToBeReturned);
                    con.Close();
                }
                return ListToBeReturned;
            }

            public void MapReaderToListObject<T>(SqlDataReader reader, ref List<T> ListToBeReturned)
            {
                while (reader.Read())
                {
                    var ObjectToAdd = (T)Activator.CreateInstance(typeof(T));

                    foreach (var item in ObjectToAdd.GetType().GetProperties())
                    {
                        if (!DBNull.Value.Equals(reader[item.Name]) && reader[item.Name] != null)
                        {
                            if (Nullable.GetUnderlyingType(item.PropertyType) != null)
                            {
                                item.SetValue(ObjectToAdd, Convert.ChangeType(reader[item.Name], Nullable.GetUnderlyingType(item.PropertyType)));
                            }
                            else
                            {
                                item.SetValue(ObjectToAdd, Convert.ChangeType(reader[item.Name], item.PropertyType));
                            }
                        }
                        else
                        {
                            item.SetValue(ObjectToAdd, null);
                        }
                    }
                    ListToBeReturned.Add(ObjectToAdd);
                }
            }
        
        }
}
