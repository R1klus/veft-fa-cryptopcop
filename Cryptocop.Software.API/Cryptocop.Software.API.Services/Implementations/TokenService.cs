using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly string _secret;
        private readonly string _expDate;
        private readonly string _issuer;
        private readonly string _audience;


        public TokenService(string secret, string expDate, string issuer, string audience)
        {
            _secret = secret;
            _expDate = expDate;
            _issuer = issuer;
            _audience = audience;
        }

        public string GenerateJwtToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = GetSecurityTokenDescriptor(user);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
        private SecurityTokenDescriptor GetSecurityTokenDescriptor(UserDto user)
        {
            var key = Encoding.ASCII.GetBytes(_secret);
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("email", user.Email),
                    new Claim("fullName", user.FullName),
                    new Claim("tokenId", user.TokenId.ToString())
                }),
                Audience = _audience,
                Issuer = _issuer,
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
        }
    }
}
