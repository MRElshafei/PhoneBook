using AutoMapper;
using MediatR;
using PhoneBook.Apllication.Interfaces;
using PhoneBook.Domain;

namespace PhoneBook.Apllication.Features.Contacts.Commands.AddContact
{
    public class AddContactCommandHandler : IRequestHandler<AddContactCommandInput, AddContactCommandOutput>
    {
        private readonly IAsyncRepository _asyncRepository;
        private readonly IMapper _mapper;

        public AddContactCommandHandler(IAsyncRepository asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;

        }


        public async Task<AddContactCommandOutput> Handle(AddContactCommandInput request, CancellationToken cancellationToken)
        {


            ContactInfo contact = new ContactInfo();
            AddContactCommandOutput output = new AddContactCommandOutput();

            contact.PhoneNumber = request.NewContact.PhoneNumber;
            contact.HomeNumber = request.NewContact.HomeNumber;
            contact.WorkNumber = request.NewContact.WorkNumber;
            contact.FirstName = request.NewContact.FirstName;
            contact.LastName = request.NewContact.LastName;
            contact.Adress = request.NewContact.Adress;
            contact.Emaile = request.NewContact.Emaile;
            contact.UserEmaile = request.UserEmail;

            output.message = await _asyncRepository.AddAsyncContact(contact);
            return output;
        }
    }
}
