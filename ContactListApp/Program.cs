// Huvudprogram för att hantera menyn och användarinteraktion.

using System;
using System.Linq;
using ContactListApp.Data;
using ContactListApp.Models;
using ContactListApp.Services;

namespace ContactListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = "contacts.json";

            // Skapa en insats av ContactRepository
            var repository = new ContactRepository(filePath);

            // Skapa en instans av ContactService
            var contactService = new ContactService(repository);

            // Ladda kontakter från fil 
            var loadedContacts = repository.LoadContacts();
            foreach (var contact in loadedContacts)
            {
                contactService.AddContact(contact);
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till kontaktlistan!");
                Console.WriteLine("1. Lista alla kontakter");
                Console.WriteLine("2. Lägg till en kontakt");
                Console.WriteLine("3. Avsluta");
                Console.Write("Välj ett alternativ: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListContacts(contactService);
                        break;
                    case "2":
                        AddContact(contactService);
                        break;
                    case "3":
                        Console.WriteLine($"sparar kontakter till filen: {filePath}");
                        repository.SaveContacts(contactService.GetAllContacts());
                        Console.WriteLine("Programmet avslutas...");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }

        private static void ListContacts(ContactService contactService)
        {
            Console.WriteLine("\nAlla kontakter:");
            var contacts = contactService.GetAllContacts();

            if (!contacts.Any())
            {
                Console.WriteLine("Inga kontakter hittades.");
            }
            else
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"ID: {contact.Id}");
                    Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"E-post: {contact.Email}");
                    Console.WriteLine($"Telefon: {contact.PhoneNumber}");
                    Console.WriteLine($"Adress: {contact.StreetAddress}, {contact.PostalCode} {contact.City}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }

        private static void AddContact(ContactService contactService)
        {
            var contact = new Contact();

            
            contact.FirstName = GetValidInput("Förnamn");
            contact.LastName = GetValidInput("Efternamn");
            contact.Email = GetValidInput("E-postadress");
            contact.PhoneNumber = GetValidInput("Telefonnummer");
            contact.StreetAddress = GetValidInput("Gatuadress");
            contact.PostalCode = GetValidInput("Postnummer");
            contact.City = GetValidInput("Ort");

            contactService.AddContact(contact);

            Console.WriteLine("Kontakten har lagts till!");
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }

        private static string GetValidInput(string fieldName)
        {
            string input;
            do
            {
                Console.Write($"{fieldName}: ");
                input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine($"{fieldName} kan inte vara tomt. Försök igen.");
                }
            } while (string.IsNullOrEmpty(input));
            return input;
        }

    }
}