using MediatR;
using PhoneBook.Apllication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactQueryHandler : IRequestHandler<DeleteContactQuery, String>
    {
        private readonly IAsyncRepository _asyncRepository;
     
        public DeleteContactQueryHandler(IAsyncRepository asyncRepository)
        {
            _asyncRepository = asyncRepository;

        }
        public async Task<String> Handle(DeleteContactQuery request, CancellationToken cancellationToken)
        {

           var massage= await _asyncRepository.DeleteAsync(request.contactInfo);
           return massage;
        }
    }
}
