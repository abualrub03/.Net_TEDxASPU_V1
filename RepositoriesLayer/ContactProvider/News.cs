using Interfaces;
using Microsoft.Data.SqlClient;

namespace RacoonProvider
{
    public class News :  Core.Disposable , INews
    {
        public List<Entities.News> getAllNews()
        {
            using var DAL = new DataAccess.DataAccessLayer();
            return DAL.ExecuteReader<Entities.News>("spSelectAllTblNews");

        }
        public bool deleteNews(int Id)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Id", Value =  Id }
            };
            return DAL.ExecuteNonQuery("spDelFromTblNews");
        }
        
        public bool newSubscribtion(Entities.News news)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Email", Value =  news.email } ,
            };
            return DAL.ExecuteNonQuery("spInsertToTblNews");
        }
    }
}