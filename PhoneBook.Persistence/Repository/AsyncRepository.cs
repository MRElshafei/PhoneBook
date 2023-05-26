using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Apllication.Interfaces;
using PhoneBook.Domain;

namespace PhoneBook.Persistence.Repository
{
    public class AsyncRepository : IAsyncRepository
    {
        protected readonly ApplicationDBContext _dbContext;

        public AsyncRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> AddAsyncContact(ContactInfo newContact)
        {
            // Check if contact already exists
            var existingContact = await _dbContext.ContactInfo
                .FirstOrDefaultAsync(c => c.FirstName == newContact.FirstName &&
                                           c.LastName == newContact.LastName &&
                                           c.PhoneNumber == newContact.PhoneNumber &&
                                           c.UserEmaile == newContact.UserEmaile);

            if (existingContact != null)
            {
                return "Contact already exists!";
            }

            await _dbContext.ContactInfo.AddAsync(newContact);
            await _dbContext.SaveChangesAsync();

            return "Contact created successfully";
        }


        public async Task<String> DeleteAsync(Guid ContactId)
        {
           var contactInfo= _dbContext.ContactInfo.FirstOrDefault(c => c.Id == ContactId);
            if (contactInfo == null)
            {
                return  null;
            }
            _dbContext.Remove(contactInfo);
            //_dbContext.Set<ContactInfo>().Remove(DeletedContact);
            await _dbContext.SaveChangesAsync();
            return "Contact is Removed Successfully";
        }

        public async Task<List<ContactInfo>> GetAllContactsAsync(string Email)
        {
            return await _dbContext.ContactInfo.Where(x => x.UserEmaile == Email).ToListAsync();
        }

        public async Task<string> UpdateAsync(ContactInfo editedContact)
        {
            // Check if the Contact exists
            var existingContact = await _dbContext.ContactInfo.FindAsync(editedContact.Id);
            if (existingContact == null)
            {
                return "The Contact does not exist";
            }

            // Update the properties of the existing contact
            if (!string.IsNullOrWhiteSpace(editedContact.FirstName))
            {
                existingContact.FirstName = editedContact.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(editedContact.LastName))
            {
                existingContact.LastName = editedContact.LastName;
            }

            if (editedContact.PhoneNumber != 0)
            {
                existingContact.PhoneNumber = editedContact.PhoneNumber;
            }

            if (editedContact.HomeNumber.HasValue)
            {
                existingContact.HomeNumber = editedContact.HomeNumber;
            }

            if (editedContact.WorkNumber.HasValue)
            {
                existingContact.WorkNumber = editedContact.WorkNumber;
            }

            if (!string.IsNullOrWhiteSpace(editedContact.Adress))
            {
                existingContact.Adress = editedContact.Adress;
            }

            if (!string.IsNullOrWhiteSpace(editedContact.Emaile))
            {
                existingContact.Emaile = editedContact.Emaile;
            }
            _dbContext.Update(existingContact);

            // Save the changes to the database
            await _dbContext.SaveChangesAsync();

            return "Contact updated successfully";
        }

    }
}
