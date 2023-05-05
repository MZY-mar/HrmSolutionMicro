using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthenticationManager
{
    public static class JwtTokenExtension
    {
        public static void AddCustomJwtTokenService(this IServiceCollection services)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(ob =>
                {
                    ob.Audience = "april";
                    ob.SaveToken = true;
                    ob.RequireHttpsMetadata = false;
                    ob.TokenValidationParameters =
                        new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.ASCII.GetBytes(JWTTokenHandler.JWT_Sectet_Key)
                            )
                        };
                });
        }
    }
}
