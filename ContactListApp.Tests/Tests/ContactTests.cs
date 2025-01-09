using ContactListApp.Models;
using ContactListApp.Utilities;
namespace ContactListApp.Tests.Tests
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
                Id = "testID",
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
                    "ID: testID\r\n" +
                    "Namn: testFN testLN\r\n" +
                    "E-post: test@test.com\r\n" +
                    "Telefon: 1234567890\r\n" +
                    "Address: testStreetAddress, 12345 testCity\r\n\r\n";

                Assert.Equal(expected, consoleOut.ToString()); 
            }
        }
    }
}
