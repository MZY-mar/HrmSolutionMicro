using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Core.Contract.Repository;
using Authentication.Core.Model;
using JWTAuthenticationManager;
using JWTAuthenticationManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthenticationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly JWTTokenHandler jwtTokenHandler;
        private readonly IAuthenticationRepository _repository;

        public AccountController(
            ILogger<AccountController> logger,
            JWTTokenHandler jwtTokenHandler,
            IAuthenticationRepository repository
        )
        {
            _logger = logger;
            this.jwtTokenHandler = jwtTokenHandler;
            _repository = repository;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel modle)
        {
            var result = await _repository.SignUpAsync(modle);
            if (result.Succeeded)
                return Ok("your account is created.");
            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _repository.LoginAsync(model);
            if (result.Succeeded)
            {
                AuthenticationRequest request = new AuthenticationRequest()
                {
                    Username = model.Username,
                    Password = model.Password
                };

                var response = jwtTokenHandler.GenerateToken(request, "admin");
                if (response == null)
                    return Unauthorized();
                return Ok(response);
            }
            return Unauthorized();
        }
    }
}
