using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListApp.DTOs
{
    public class ContactDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public void DisplayContact()
        {
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"Namn: {this.Name}");
            Console.WriteLine($"E-post: {this.Email}");
            Console.WriteLine($"Telefon: {this.Phone}");
            Console.WriteLine($"Address: {this.Address}");
            Console.WriteLine();
        }
    }
}
