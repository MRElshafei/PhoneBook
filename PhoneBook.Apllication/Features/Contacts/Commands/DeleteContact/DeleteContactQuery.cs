using MediatR;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Commands.DeleteContact
{
    public record DeleteContactQuery(ContactInfo contactInfo):IRequest<String>;
   
}
