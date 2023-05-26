using MediatR;
using PhoneBook.Apllication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactQueryHandler : IRequestHandler<DeleteContactQueryInput, DeleteContactQueryOutput>
    {
        private readonly IAsyncRepository _asyncRepository;
     
        public DeleteContactQueryHandler(IAsyncRepository asyncRepository)
        {
            _asyncRepository = asyncRepository;

        }
        public async Task<DeleteContactQueryOutput> Handle(DeleteContactQueryInput request, CancellationToken cancellationToken)
        {
            DeleteContactQueryOutput output = new DeleteContactQueryOutput();
            output.message  = await _asyncRepository.DeleteAsync(request.ContactId);
           return output;
        }
    }
}
