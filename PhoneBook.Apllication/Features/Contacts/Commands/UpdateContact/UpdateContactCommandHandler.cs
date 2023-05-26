using MediatR;
using PhoneBook.Apllication.Features.Contacts.Commands.AddContact;
using PhoneBook.Apllication.Interfaces;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandHandler: IRequestHandler< UpdateContactCommandInput, UpdateContactCommandOutput>
    {
        private readonly IAsyncRepository _asyncRepository;
        public UpdateContactCommandHandler(IAsyncRepository asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<UpdateContactCommandOutput> Handle(UpdateContactCommandInput request, CancellationToken cancellationToken)
        {
            UpdateContactCommandOutput output = new UpdateContactCommandOutput();
           
            output.message = await _asyncRepository.UpdateAsync(request.UpdatedContact);
            return output;

        }
    }
}
