using MediatR;
using PhoneBook.Apllication.Features.Contacts.Commands.UpdateContact;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactQueryInput : IRequest<DeleteContactQueryOutput>
    {
        public Guid ContactId { get; set; }
    }
}
