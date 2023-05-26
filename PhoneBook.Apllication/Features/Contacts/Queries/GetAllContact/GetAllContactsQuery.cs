using MediatR;

namespace PhoneBook.Apllication.Features.Contacts.Queries.GetAllContact
{
    public class GetAllContactsQuery : IRequest<GetAllContactsQueryOutput>
    {
        public string Email { get; set; }

    }
}





