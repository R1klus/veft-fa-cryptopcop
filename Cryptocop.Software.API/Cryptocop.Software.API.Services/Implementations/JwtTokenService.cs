using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class JwtTokenService : IJwtTokenService
    {
        public bool IsTokenBlacklisted(int tokenId)
        {
            throw new System.NotImplementedException();
        }
    }
}