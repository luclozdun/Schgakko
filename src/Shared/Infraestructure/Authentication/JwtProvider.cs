using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Schgakko.src.Shared.Application.Abstractions;

namespace Schgakko.src.Shared.Infraestructure.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IConfiguration configuration;
        private readonly JwtOptions options;

        public JwtProvider(IConfiguration configuration)
        {
            this.configuration = configuration;

            options = configuration.GetSection("Jwt").Get<JwtOptions>();
        }

        public string Genereate(int id, string name, string email, string role)
        {
            Claim[] claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, name),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("Role",role)
            };

            SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)), SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(options.Issuer, options.Audience, claims, null, DateTime.UtcNow.AddHours(1), signingCredentials);
            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
    }
}