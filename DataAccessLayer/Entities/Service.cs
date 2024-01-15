using System.ComponentModel.DataAnnotations;
namespace Entities
{
    public class Service
    {  
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?Details { get; set; }
    }
}