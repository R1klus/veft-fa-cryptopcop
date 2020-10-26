using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client.Exceptions;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly ITokenRepository _tokenRepository;

        public JwtTokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public bool IsTokenBlacklisted(int tokenId)
        {
            return _tokenRepository.IsTokenBlacklisted(tokenId);
        }
    }
}