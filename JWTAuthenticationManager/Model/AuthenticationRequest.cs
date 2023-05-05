using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthenticationManager.Model
{
    public class AuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
