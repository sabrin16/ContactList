// Enhetstester för ContactService.


using ContactListApp.Models;
using ContactListApp.Services;
using Xunit;
using System.Linq;
using ContactListApp.Data;
using Moq;
using System.Collections.Generic;

namespace ContactListApp.Tests
{
    public class ContactServiceTests
    {
        [Fact]
        public void AddContact_shouldAddContactToList()
        {
            // Arange
            var mockRepository = new Mock<ContactRepository>("contacts.json"); // Mocka repository.
            var service = new ContactService(mockRepository.Object); // Skapa ContactService med mockad repository
            var contact = new Contact { FirstName = "Test", LastName = "User" };

            // Mocka LoadContacts för att returnera en tom lista från början.
            mockRepository.Setup(repo => repo.LoadContacts()).Returns(new List<Contact>());

            // Mocka SaveContacts för att inte spara data till filen i testet.
            mockRepository.Setup(repo => repo.SaveContacts(It.IsAny<IEnumerable<Contact>>())).Verifiable();

            // Act
            service.AddContact(contact);

            // Assert
            var contacts = service.GetAllContacts().ToList();  // Hämta alla kontakter.
            Assert.Single(contacts); // Kontrollera att det finns exakt en kontakt i listan.
            Assert.Equal("Test", contacts.First().FirstName); // Kontrollera att förnamnet är korrekt.

            // Verifiera att SaveContacts anropades.
            mockRepository.Verify(repo => repo.SaveContacts(It.IsAny<IEnumerable<Contact>>()), Times.Once);
        }

        [Fact]
        public void GetAllContacts_ShouldReturnEmptyList_WhenNoContactsAdded()
        {
            // Arange
            var mockRepository = new Mock<ContactRepository>("contacts.json");
            var service = new ContactService(mockRepository.Object);

            // Mocka LoadContacts för att returnera en tom lista.
            mockRepository.Setup(repo => repo.LoadContacts()).Returns(new List<Contact>());

            // Act
            var contacts = service.GetAllContacts();

            //Assert 
            Assert.Empty(contacts); // Kontrollera att listan är tom.
        }

    }
}
