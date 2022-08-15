using PhoneBook.Persistence.AuthRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.JWTAuthentication.AuthInterfaces
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        //Login Function
        Task<AuthModel> GetTokenAsync(LoginModel model);
        //Task<string> AddRoleAsync(AddRoleModel model);
    }
}
