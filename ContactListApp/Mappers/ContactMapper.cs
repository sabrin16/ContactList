using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactListApp.DTOs;
using ContactListApp.Models;

namespace ContactListApp.Mappers
{
    public static class ContactMapper
    {
        public static ContactDTO toDTO(Contact contact)
        {
            return new ContactDTO
            {
                Id = contact.Id,
                Name = contact.FirstName + " " + contact.LastName,
                Email = contact.Email,
                Phone = contact.PhoneNumber,
                Address = contact.City + " " + contact.StreetAddress
            };
        }
    }
}
