using ContactListApp.Models;
using System.Text.Json;
using ContactListApp.Interfaces;
using ContactListApp.DTOs;
using ContactListApp.Mappers;


namespace ContactListApp.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _filePath;
        // We keep contact here. Our Storage
        private List<Contact> _contacts = new List<Contact>();
        

        public ContactRepository(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath), "Filvägen kan inte vara null.");
            loadContacts();
        }

        // Läs in kontakter från filen.
        public void loadContacts()
        {
            if (!File.Exists(_filePath))
            {
                _contacts = new List<Contact>();
                Console.WriteLine("You have 0 contacts saved now");
                Console.ReadKey();
            }
            else {
                try
                {
                    var jsonData = File.ReadAllText(_filePath);
                    _contacts = JsonSerializer.Deserialize<List<Contact>>(jsonData) ?? new List<Contact>();
                    Console.WriteLine("The length of contacts is " + _contacts.Count());
                    Console.ReadKey();
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Error in loading contacts!");
                }

            }
            
        }

        public void saveContacts()
        {
            
            var jsonData = JsonSerializer.Serialize(_contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
        }

        public void addContactToRepository(Contact contact)
        {
            _contacts.Add(contact);
            saveContacts();
        }
        public IEnumerable<ContactDTO> getAll()
        {
            List<ContactDTO> contactDTOS = new List<ContactDTO>();
            foreach (Contact contact in _contacts) {
                contactDTOS.Add(ContactMapper.toDTO(contact));
            }
            return contactDTOS;
        }
    }
}
