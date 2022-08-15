using MediatR;
using PhoneBook.Apllication.Interfaces;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Queries.GetAllContact
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<ContactInfo>>
    {
        private readonly IAsyncRepository _asyncRepository;
        public GetAllContactsQueryHandler (IAsyncRepository asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }
        public async Task<List<ContactInfo>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _asyncRepository.GetAllContactsAsync(request.Email);
            return contacts;
        }
    }
}
