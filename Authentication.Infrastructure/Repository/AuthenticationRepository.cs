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
        private readonly SignInManager<ApplicationUser> signInManager;

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
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var exceptionText = result.Errors.Aggregate(
                    "User Creation Failed - Identity Exception. Errors were: \n\r\n\r",
                    (current, error) => current + (" - " + error + "\n\r")
                );
                throw new Exception(exceptionText);
            }

            return result;
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
