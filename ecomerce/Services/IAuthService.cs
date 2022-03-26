using ecomerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(Registermodel model);
        Task<AuthModel> GetLoginAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);

    }
}
