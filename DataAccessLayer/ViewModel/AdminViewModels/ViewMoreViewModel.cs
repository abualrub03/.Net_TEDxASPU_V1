using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.AdminViewModels
{
    public class ViewMoreViewModel
    {
        public int Count {  get; set; }
        public int countPages { get; set; }
        public static int end = 10;
        public int start { get; set; }  
        public int NumberOfItemsSearchedFor { get; set; }
        public int press { get; set; }
        public List<Entities.Contact> Contacts { get; set; }
        public List<Entities.Service> Services { get; set; }
        public string Filter { get; set; }    
        public string Searchstr { get; set; }
    }
}
