using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public AccountController(ILogger<AccountController> logger, JWTTokenHandler jwtTokenHandler)
        {
            _logger = logger;
            this.jwtTokenHandler = jwtTokenHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthenticationRequest request)
        {
            var response = jwtTokenHandler.GenerateToken(request);
            if (response == null)
                return Unauthorized();
            return Ok(response);
        }
    }
}
