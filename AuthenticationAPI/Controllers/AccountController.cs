using Authentication.Core.Contract.Repository;
using Authentication.Core.Model;
using JWTAuthenticationManager;
using JWTAuthenticationManager.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JWTTokenHandler jwtTokenHandler;
        private readonly IAuthenticationRepository _repository;

        public AccountController(
            JWTTokenHandler jwtTokenHandler,
            IAuthenticationRepository repository
        )
        {
            this.jwtTokenHandler = jwtTokenHandler;
            this._repository = repository;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> SignIn(LoginModel model)
        {
            var result = await _repository.LoginAsync(model);
            if (result.Succeeded)
            {
                JWTAuthenticationManager.Model.AuthenticationRequest request =
                    new AuthenticationRequest()
                    {
                        Username = model.Username,
                        Password = model.Password
                    };
                var response = jwtTokenHandler.GenerateToken(request, "admin");
                if (response == null)
                {
                    return Unauthorized();
                }
                return Ok(response);
            }
            return Unauthorized();
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result = await _repository.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok("Your account has been created");
            }
            return BadRequest();
        }
    }
}
