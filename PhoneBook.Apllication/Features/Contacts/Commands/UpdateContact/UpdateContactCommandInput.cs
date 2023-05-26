using MediatR;
using PhoneBook.Apllication.Features.Contacts.Commands.AddContact;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandInput : IRequest<UpdateContactCommandOutput>
    {
        public ContactInfo UpdatedContact { get; set; }
    }
}
