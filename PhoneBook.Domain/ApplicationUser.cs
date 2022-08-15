using Microsoft.AspNetCore.Identity;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.JWTAuthentication
{
    public class ApplicationUser:IdentityUser
    {
        [Required, MaxLength(50)]
        public string  FirstName { get; set; }
        [Required, MaxLength(50)]

        public string LastName { get; set; }
        
        public ICollection<Contact> ?Contacts { get; set; }
    }
}
