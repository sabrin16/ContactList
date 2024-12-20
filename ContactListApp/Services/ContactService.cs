// Hanterar logiken för att lägga till och lista kontakter.

using System.Collections.Generic;
using ContactListApp.Models;
using System.Linq;
using ContactListApp.Data;
using System;


namespace ContactListApp.Services
{
    public class ContactService
    {
        private readonly ContactRepository _repository;

        public ContactService(ContactRepository repository)
        {
            _repository = repository;
        }

        // Lägg till en kontakt och uppdatera filen
        public void AddContact(Contact contact)
        {
            // Ladda alla befintliga kontakter
            var contacts = _repository.LoadContacts().ToList();

            // Lägg till den nya kontakten
            contact.Id = Guid.NewGuid();  // Se till att kontakten får ett unikt Id
            contacts.Add(contact);

            // Spara uppdaterad lista tillbaka till filen.
            _repository.SaveContacts(contacts);
        }

        // Hämta alla kontakter
        public IEnumerable<Contact> GetAllContacts()
        {
            return _repository.LoadContacts();
        }
    }
}
