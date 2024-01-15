using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IContact
    {
        public List<Entities.Contact> getAllContacts();
        public bool deleteContact(int Id);
        public bool newContactRequest(Entities.Contact contact);




    }
}
