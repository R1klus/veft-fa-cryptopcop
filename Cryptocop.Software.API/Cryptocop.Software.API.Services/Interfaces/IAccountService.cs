namespace Cryptocop.Software.API.Services.Interfaces
{
    public interface IAccountService
    {
        UserDto CreateUser(RegisterInputModel inputModel);
        UserDto AuthenticateUser(LoginInputModel loginInputModel);
        void Logout(int tokenId);
    }
}