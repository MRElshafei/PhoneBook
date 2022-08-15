using MediatR;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Queries.GetAllContact
{
    public  record GetAllContactsQuery(string Email):IRequest<List<ContactInfo>>;
    
}
