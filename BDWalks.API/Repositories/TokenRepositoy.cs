using BDWalks.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BDWalks.API.Repositories
{
    public class TokenRepositoy : ITokenRepository
    {
        private readonly IConfiguration configuration;

        public TokenRepositoy(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateJWTToken(IdentityUser user, List<string> roles)
        {
            // creating claims
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // getting key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]));

            // creating credentials using the key and a security algorithm
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // creating the token using claims, credentials and others
            var token = new JwtSecurityToken(
                configuration["jwt:issuer"],
                configuration["jwt:audience"],
                claims,
                expires: DateTime.Now.AddMinutes(25),
                signingCredentials: credentials);

            // returning the token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
