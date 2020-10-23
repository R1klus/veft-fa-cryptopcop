namespace Cryptocop.Software.API.Services.Interfaces
{
    public interface IJwtTokenService
    {
        bool IsTokenBlacklisted(int tokenId);
    }
}