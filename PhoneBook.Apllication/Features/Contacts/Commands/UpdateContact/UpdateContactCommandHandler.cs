using MediatR;
using PhoneBook.Apllication.Interfaces;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandHandler: IRequestHandler< UpdateContactCommand, ContactInfo>
    {
        private readonly IAsyncRepository _asyncRepository;
        public UpdateContactCommandHandler(IAsyncRepository asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<ContactInfo> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contacts = await _asyncRepository.UpdateAsync(request.contactInfo);
            return contacts;
        }
    }
}
