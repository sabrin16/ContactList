// Hanterar läsning och skrivning av kontakter till/från en Json fil.


using ContactListApp.Models;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using JsonFormatting = Newtonsoft.Json.Formatting;



namespace ContactListApp.Data
{
    public class ContactRepository
    {
        private readonly string _filePath;

        public ContactRepository(string filePath)
        {
            _filePath = filePath;
        }

        // Läs in kontakter från filen.
        public IEnumerable<Contact> LoadContacts()
        {
            if (!File.Exists(_filePath))
                return new List<Contact>();
 
            var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Contact>>(jsonData) ?? new List<Contact>();
        }

        public void SaveContacts(IEnumerable<Contact> contacts)
        { 
            var jsonData = JsonConvert.SerializeObject(contacts, JsonFormatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
