using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IServices
    {
        public List<Entities.Service> getAllServices();
        public bool addService(Entities.Service service);
        public bool deleteService(int Id);
        public List<Entities.Service> getAService(int id);
        public bool UpdateServiceNameAndDetails(int Id, string name, string details);

    }
}
