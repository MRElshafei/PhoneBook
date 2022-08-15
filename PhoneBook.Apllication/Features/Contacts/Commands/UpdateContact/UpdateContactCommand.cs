using MediatR;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Commands.UpdateContact
{
    public record UpdateContactCommand(ContactInfo contactInfo) :IRequest<ContactInfo>;
   
}
