using PhoneBook.Domain;

namespace PhoneBook.Apllication.Features.Contacts.Queries.GetAllContact
{
    public class GetAllContactsQueryOutput
    {
        public List<AllContacts> AllContacts { get; set; }
    }
    public class AllContacts
    {

        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int? HomeNumber { get; set; }
        public int? WorkNumber { get; set; }
        public string? Adress { get; set; }
        public string? Emaile { get; set; }
    }
}
