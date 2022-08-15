using PhoneBook.Domain;

namespace PhoneBook.Apllication.Interfaces
{
    public interface IAsyncRepository
    {
        Task<List<ContactInfo>> GetAllContactsAsync(string Email);
        Task<ContactInfo> AddAsyncContact(ContactInfo NewContact);
        Task<ContactInfo> UpdateAsync(ContactInfo EditedContact);
        Task<string> DeleteAsync( ContactInfo DeleteContac);
    }

}
