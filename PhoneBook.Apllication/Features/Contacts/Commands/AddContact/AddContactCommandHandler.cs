using AutoMapper;
using MediatR;
using PhoneBook.Apllication.Interfaces;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Apllication.Features.Contacts.Commands.AddContact
{
    public class AddContactCommandHandler : IRequestHandler<AddContactCommand, ContactInfo>
    {
        private readonly IAsyncRepository _asyncRepository;
        //private readonly IMapper _mapper;

        public AddContactCommandHandler(IAsyncRepository asyncRepository)
        {
            _asyncRepository = asyncRepository;
           
        }
        public async Task<ContactInfo> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _asyncRepository.AddAsyncContact(request.contactInfo);
            return contact; 
          
        }
    }
}
