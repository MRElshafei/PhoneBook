using MediatR;

namespace PhoneBook.Apllication.Features.Contacts.Queries.GetAllContact
{
    public class GetAllContactsQueryInput : IRequest<GetAllContactsQueryOutput>
    {
        public string Email { get; set; }

    }
}





