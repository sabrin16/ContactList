// Hanterar logiken för att lägga till och lista kontakter.

using System.Collections.Generic;
using ContactListApp.Models;
using ContactListApp.Utilities;
using System.Linq;
using ContactListApp.Data;
using System;
using ContactListApp.DTOs;
using ContactListApp.Mappers;


namespace ContactListApp.Services
{
    public class ContactService
    {
        ContactRepository contactRepository;

        public ContactService(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public void AddContact()
        {
            var contact = new Contact
            {
                Id = GuidGenerator.newID(),
                FirstName = GetValidInput("Förnamn"),
                LastName = GetValidInput("Efternamn"),
                Email = GetValidInput("E-postadress"),
                PhoneNumber = GetValidInput("Telefonnummer"),
                StreetAddress = GetValidInput("Gatuadress"),
                PostalCode = GetValidInput("Postnummer"),
                City = GetValidInput("Ort"),
            };
            contactRepository.addContactToRepository(contact);
            Console.WriteLine("Kontakten har lagts till!");
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }

        public void saveContacts()
        {
            contactRepository.saveContacts();
        }

        private static string GetValidInput(string fieldName)
        {
            string input;
            do
            {
                Console.Write($"{fieldName}: ");
                input = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine($"{fieldName} kan inte vara tomt. Försök igen.");
                }
            } while (string.IsNullOrEmpty(input));
            return input;
        }

        public void listContacts()
        {
            List<ContactDTO> contactDTOS = (List<ContactDTO>)contactRepository.getAll();
            if (!contactDTOS.Any())
            {
                Console.Clear();
                Console.WriteLine("You have no contacts");
                Console.ReadKey();
            }
            else {
                foreach (ContactDTO contactDTO in contactDTOS)
                {
                    contactDTO.DisplayContact();
                }
            }
            
        }
    }
}
