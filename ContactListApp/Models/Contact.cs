// Representerar en kontakt i kontaktlistan.
using ContactListApp.Models;

namespace ContactListApp.Models
{
    public class Contact
    {
        public required string Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }

        public void DisplayContact()
        {
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"Namn: {this.FirstName} {this.LastName}");
            Console.WriteLine($"E-post: {this.Email}");
            Console.WriteLine($"Telefon: {this.PhoneNumber}");
            Console.WriteLine($"Adress: {this.StreetAddress}, {this.PostalCode} {this.City}");
            Console.WriteLine();
        }
    }
}