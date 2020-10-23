using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class TokenService : ITokenService
    {
        public string GenerateJwtToken(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
