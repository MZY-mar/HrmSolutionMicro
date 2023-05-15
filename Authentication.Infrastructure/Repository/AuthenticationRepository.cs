using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Core.Contract.Repository;
using Authentication.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Infrastructure.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Microsoft.AspNetCore.Identity.SignInManager<ApplicationUser> signInManager;

        public AuthenticationRepository(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            return await userManager.CreateAsync(user, model.Password);
        }

        public async Task<SignInResult> LoginAsync(LoginModel model)
        {
            var result = await signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                false,
                false
            );
            return result;
        }
    }
}
