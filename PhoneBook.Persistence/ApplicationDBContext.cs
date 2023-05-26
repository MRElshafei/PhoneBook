using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain;
using PhoneBook.JWTAuthentication;
using PhoneBook.Persistence.AuthRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence
{
    public class ApplicationDBContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
     



    }
}
