using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactListApp.Models;

namespace ContactListApp.Interfaces

{
    // Gränssnittet för att hantera kontakter.
    public interface IContactRepository
    {   
        // Method for saving contacts list
        void saveContacts();
        // Method for loading contacts from json file
        void loadContacts();
        // Method for adding a contact to the list of contacts
        void addContactToRepository(Contact contact);
    }
}
