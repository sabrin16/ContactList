using ContactListApp.Models;
using ContactListApp.Utilities;

namespace TestProject.Tests
{
    public class ContactTests
    {
        [Fact]
        public void ContactReturnsData()
        {
            var contact = new Contact
            {
                Id = GuidGenerator.newID(),
                FirstName = "testFN",
                LastName = "testLN",
                Email = "test@test.com",
                PhoneNumber = "1234567890",
                StreetAddress = "testStreetAddress",
                PostalCode = "12345",
                City = "testCity"
            };

            Assert.Equal(contact.Id, contact.Id);
            Assert.Equal("testFN", contact.FirstName);
            Assert.Equal("testLN", contact.LastName);
            Assert.Equal("test@test.com", contact.Email);
            Assert.Equal("1234567890", contact.PhoneNumber);
            Assert.Equal("testStreetAddress", contact.StreetAddress);
            Assert.Equal("12345", contact.PostalCode);
            Assert.Equal("testCity", contact.City);
        }

        [Fact]
        public void DisplayContactShouldPrintContactDetails()
        {
            var contact = new Contact
            {
                Id = GuidGenerator.newID(),
                FirstName = "testFN",
                LastName = "testLN",
                Email = "test@test.com",
                PhoneNumber = "1234567890",
                StreetAddress = "testStreetAddress",
                PostalCode = "12345",
                City = "testCity"
            };

            using (var consoleOut = new StringWriter())
            {
                Console.SetOut(consoleOut);
                contact.DisplayContact();

                string expected =
                    "ID: {contact.Id}\n" +
                    "Namn: testFN testLN\n" +
                    "E-post: test@test.com\n" +
                    "Telefon: 1234567890\n" +
                    "Address: testStreetAddress, 12345 testCity\n\n";

                Assert.Equal(expected, consoleOut.ToString()); 
            }
        }
    }
}
