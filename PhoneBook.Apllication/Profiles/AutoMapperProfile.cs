using AutoMapper;
using PhoneBook.Apllication.Features.Contacts.Queries.GetAllContact;
using PhoneBook.Domain;

namespace PhoneBook.Apllication.Profiles
{
    public class AutoMapperProfile : Profile
    {


        public AutoMapperProfile()
        {
            CreateMap<ContactInfo, AllContacts>();
            CreateMap< ContactDTO,ContactInfo > ();


        }

    }
}
