using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Commun
{
    public class IdentityTokenClaimService : ITokenClaimsService
    {
        private readonly IConfiguration _configuration;

        public IdentityTokenClaimService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetTokenAsync(string userName, string app, List<string> roles)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] bytes = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]);
            string issuer = _configuration["JwtSettings:Issuer"];
            string audience = _configuration["JwtSettings:Audience"];
            List<Claim> list = new List<Claim>
        {
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", userName)
        };
            list.Add(new Claim("http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor", app));
            foreach (string role in roles)
            {
                list.Add(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", role));
            }

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Subject = new ClaimsIdentity(list.ToArray()),
                Expires = DateTime.UtcNow.AddDays(7.0),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytes), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256")
            };
            SecurityToken token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);
        }

    }
}
