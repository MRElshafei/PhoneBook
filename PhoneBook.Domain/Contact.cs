using PhoneBook.JWTAuthentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain
{
    public class Contact
    {
        public Guid ContactId { get; set; }

        public string FirstName { get; set; }    
        public string? LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int? HomeNumber { get; set; }
        public int? WorkNumber { get; set; }
        public string? Adress { get; set; }
        public string? Emaile { get; set; }

    
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
