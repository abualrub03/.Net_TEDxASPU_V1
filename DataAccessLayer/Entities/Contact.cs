using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Contact
    {
        //test
        public int Id { get; set; }
        public string ?Name { get; set; }


        public int PhoneNumber { get; set; }
        public string ?Service  { get; set; }
        public string? Email { get; set; }
        public string ?message { get; set; }



    }
}