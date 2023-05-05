using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthenticationManager.Model
{
    public class AuthenticationResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }

        public int ExpiresInt { get; set; }
    }
}
