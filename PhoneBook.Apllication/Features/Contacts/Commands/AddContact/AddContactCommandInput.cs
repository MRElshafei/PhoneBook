using MediatR;
using PhoneBook.Apllication.Features.Contacts.Queries.GetAllContact;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Commands.AddContact
{
    public class AddContactCommandInput :IRequest<AddContactCommandOutput>
    {
        public ContactDTO NewContact { get; set; }
        public String UserEmail { get; set; }
    }

}
