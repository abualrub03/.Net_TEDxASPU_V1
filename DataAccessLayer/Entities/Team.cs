using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Entities
{
    public class Team
    {
        public Team() { }    

        public Team(int id, string email,string role,string name,string details ,string encryptedId ,string phoneNumber) {
            Id = id;
            Email = email;
            Name = name;
            Details = details;
            EncryptedId = encryptedId;
            PhoneNumber = phoneNumber;
            Role = role;
        }
        //////////////////////////////////////////////////////////////////////
        public byte[] ImageData { get; set; }
        public string ImageName { get; set; }
        public string ImageContentType { get; set; }

        //////////////////////////////////////////////////////////////////////
        public string? Name { get; set; }
        public string Details { get; set; }
        public int Id { get; set; }
        [NotMapped]
        public string ?EncryptedId { get; set; }
        public string ?Password { get; set; }
        public string? encryptedPassword { get; set; }
        public string ?Email { get; set; }
        public string ?PhoneNumber { get; set; }
        public string ?IdSalt { get; set; }
        public string ?PasswordSalt { get; set; }

        public string ?Role { get; set; }
    }
}