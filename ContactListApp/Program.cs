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
            const string filePath = "C:\\projects\\ContactList copy\\ContactListApp\\json\\contacts.json";
            Console.WriteLine($"Looking for file at: {filePath}");

            var repository = new ContactRepository(filePath);

            ContactService contactService = new ContactService(repository);
            MenuService menuService = new MenuService(contactService);
            menuService.MainMenu();
        }
    }
}