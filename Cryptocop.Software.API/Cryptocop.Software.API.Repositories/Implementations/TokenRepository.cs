using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class TokenRepository : ITokenRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly string _secret;
        private readonly string _expDate;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenRepository(string secret, string expDate, string issuer, string audience, CryptocopDbContext dbContext=null)
        {
            _dbContext = dbContext;
            _secret = secret;
            _expDate = expDate;
            _issuer = issuer;
            _audience = audience;
        }


        public JwtToken CreateNewToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = GetSecurityTokenDescriptor(user);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = new JwtToken
            {
                Id = int.Parse(token.Id),
                Blacklisted = false
            };
            
            return jwtToken;
        }
        
        public bool IsTokenBlacklisted(int tokenId)
        {
            var token = _dbContext.JwtTokens.FirstOrDefault(t => t.Id == tokenId);
            return token == null || token.Blacklisted;
        }

        public void VoidToken(int tokenId)
        {
            throw new System.NotImplementedException();
        }
        
        private SecurityTokenDescriptor GetSecurityTokenDescriptor(UserDto user)
        {
            var key = Encoding.ASCII.GetBytes(_secret);
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("name", user.Email),
                    new Claim("fullName", user.FullName),
                    new Claim("TokenId", user.TokenId.ToString())
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