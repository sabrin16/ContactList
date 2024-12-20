// Representerar en kontakt i kontaktlistan.


namespace ContactListApp.Models
{
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Autogenererat ID.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
