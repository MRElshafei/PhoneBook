using PhoneBook.Domain;

namespace PhoneBook.Apllication.Interfaces
{
    public interface IAsyncRepository
    {
        Task<List<ContactInfo>> GetAllContactsAsync(string Email);
        Task<string> AddAsyncContact(ContactInfo NewContact);
        Task<string> UpdateAsync(ContactInfo EditedContact);
        Task<string> DeleteAsync( Guid ContactId);
    }

}
