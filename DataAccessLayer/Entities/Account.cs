using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class Account
    {
        public int Id {  get; set; }
        public string honorific  { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
        public string userName { get; set; }
        public string role { get; set; }
        public int imageId { get; set; }
    }
}
