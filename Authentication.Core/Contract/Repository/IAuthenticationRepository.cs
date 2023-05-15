using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.Contract.Repository
{
    public interface IAuthenticationRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<SignInResult> LoginAsync(LoginModel model);
    }
}
