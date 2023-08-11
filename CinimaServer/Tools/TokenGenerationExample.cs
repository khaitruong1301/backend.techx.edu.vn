using System;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CinimaServer.Tools
{
    public class JwtTokenGenerator
    {
        private string _secretKey;
        private string _issuer;
        private string _audience;

        public JwtTokenGenerator(string secretKey, string issuer, string audience)
        {
            _secretKey = secretKey;
            _issuer = issuer;
            _audience = audience;
        }

        public string GenerateToken(string username, string email, string role, double expirationHours = 1)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _issuer,
                Audience = _audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddYears(10),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}