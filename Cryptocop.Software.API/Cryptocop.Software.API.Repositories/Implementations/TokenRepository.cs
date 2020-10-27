using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Exceptions;
using Cryptocop.Software.API.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class TokenRepository : ITokenRepository
    {
        private readonly CryptocopDbContext _dbContext;

        public TokenRepository(CryptocopDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public JwtToken CreateNewToken()
        {
            var token = new JwtToken();
            _dbContext.JwtTokens.Add(token);
            _dbContext.SaveChanges();
            return token;
        }
        
        public bool IsTokenBlacklisted(int tokenId)
        {
            var token = _dbContext.JwtTokens.FirstOrDefault(t => t.Id == tokenId);
            if (token == null){ throw new ResourceNotFoundException($"Token with ID {tokenId} not found");}
            return token.Blacklisted;
        }

        public void VoidToken(int tokenId)
        {
            var token = _dbContext.JwtTokens.FirstOrDefault(t => t.Id == tokenId);
            if (token == null){ throw new ResourceNotFoundException($"Token with ID {tokenId} not found");}

            token.Blacklisted = true;
            _dbContext.SaveChanges();
        }
        
    }
}