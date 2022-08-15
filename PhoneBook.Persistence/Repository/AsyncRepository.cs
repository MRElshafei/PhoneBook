using Microsoft.EntityFrameworkCore;
using PhoneBook.Apllication.Interfaces;
using PhoneBook.Domain;
using System.Security.Claims;

namespace PhoneBook.Persistence.Repository
{
    public class AsyncRepository : IAsyncRepository
    {
        protected readonly ApplicationDBContext _dbContext;

        public AsyncRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ContactInfo> AddAsyncContact(ContactInfo NewContact)
        {
            await _dbContext.ContactInfo.AddAsync(NewContact);
            await _dbContext.SaveChangesAsync();
            return  NewContact;         
        }

        public async Task<String> DeleteAsync(ContactInfo DeletedContact)
        {
             _dbContext.Set< ContactInfo>().Remove(DeletedContact);
             await _dbContext.SaveChangesAsync();
            return "Contact is Removed Successfully";
        }

        public async Task<List<ContactInfo>> GetAllContactsAsync(string Email)
        {
            return await _dbContext.ContactInfo.Where(x=>x.UserEmaile==Email).ToListAsync();
        }

        public async Task<ContactInfo> UpdateAsync(ContactInfo EditedContact)
        {
            //ContactInfo oldContact =await _dbContext.ContactInfo.FirstOrDefaultAsync(x => x.Id == EditedContact.Id);
            //oldContact.Emaile=EditedContact.Emaile;
            //oldContact.Adress=EditedContact.Adress;
            //oldContact.PhoneNumber=EditedContact.PhoneNumber;
            //oldContact.WorkNumber=EditedContact.WorkNumber;
            //oldContact.HomeNumber=EditedContact.HomeNumber;
            //oldContact.LastName=EditedContact.LastName;
            //oldContact.FirstName=EditedContact.FirstName;
            //await _dbContext.ContactInfo.AddAsync(oldContact);
            //await _dbContext.SaveChangesAsync();
            //return oldContact;
            // var user=_dbContext.ContactInfo.FirstOrDefaultAsync(x => x.PhoneNumber == EditedContact.PhoneNumber);
 
            _dbContext.Entry(EditedContact).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return EditedContact;
        }
    }
}
