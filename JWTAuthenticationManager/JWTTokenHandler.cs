using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JWTAuthenticationManager.Model;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthenticationManager
{
    public class JWTTokenHandler
    {
        public const string JWT_Sectet_Key =
            "H+MbQeThWmZq4t7w9z$C&F)J@NcRfUjXn2r5u8x/A%D*G-KaPdSgVkYp3s6v9y$B";
        private const int JWT_Token_Validity_Min = 20;
        private readonly List<UserAccount> userAccounts;

        public JWTTokenHandler()
        {
            userAccounts = new List<UserAccount>()
            {
                new UserAccount()
                {
                    Username = "admin",
                    Password = "admin123",
                    Role = "admin"
                }
            };
        }

        public AuthenticationResponse GenerateToken(AuthenticationRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return null;
            }

            var result = userAccounts
                .Where(x => x.Username == request.Username && x.Password == request.Password)
                .FirstOrDefault();
            if (result == null)
                return null;
            // if it result is not null we need to generate the token
            var TokenExpireTime = DateTime.UtcNow.AddMinutes(JWT_Token_Validity_Min);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_Sectet_Key);
            var claminsIdentity = new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim(
                        Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Name,
                        request.Username
                    ),
                    new Claim(ClaimTypes.Role, result.Role),
                }
            );
            //passing security key
            var signCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
            );

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claminsIdentity,
                Expires = TokenExpireTime,
                SigningCredentials = signCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);
            return new AuthenticationResponse
            {
                Token = token,
                ExpiresInt = (int)TokenExpireTime.Subtract(DateTime.Now).TotalSeconds,
                Username = result.Username
            };
        }
    }
}
