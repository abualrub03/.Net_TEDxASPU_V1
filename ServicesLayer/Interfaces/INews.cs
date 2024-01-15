using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface INews
    {
        public List<Entities.News> getAllNews();
        public bool deleteNews(int Id);
        public bool newSubscribtion(Entities.News news);







    }
}
