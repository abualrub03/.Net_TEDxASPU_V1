using Interfaces;
using Microsoft.Data.SqlClient;

namespace RacoonProvider
{
    public class Services : Core.Disposable ,IServices
    {
        public List<Entities.Service> getAllServices()
        {
            using var DAL = new DataAccess.DataAccessLayer();
            return DAL.ExecuteReader<Entities.Service>("spSelectAllTblService");

        }
        public bool addService(Entities.Service service)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Name", Value =  service.Name },
                new SqlParameter{ ParameterName = "@Details", Value =  service.Details },
            };
            return DAL.ExecuteNonQuery("spInsertToTblService");
        }
        public bool deleteService(int Id)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Id", Value =  Id }
            };
            return DAL.ExecuteNonQuery("spDelFromTblService");
        }
        public List<Entities.Service> getAService(int id)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Id", Value =  id }
            };
            return DAL.ExecuteReader<Entities.Service>("spSelectFromTblService");

        }
        public bool UpdateServiceNameAndDetails(int Id, string name, string details)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@id", Value =  Id },
                new SqlParameter{ ParameterName = "@name", Value =  name },
                new SqlParameter{ ParameterName = "@details", Value =  details },

            };
            return DAL.ExecuteNonQuery("spUpdateServiceNamePassword");
        }


    }
}