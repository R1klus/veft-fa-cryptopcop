using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class AccountService : IAccountService
    {
        public UserDto CreateUser(RegisterInputModel inputModel)
        {
            throw new System.NotImplementedException();
        }

        public UserDto AuthenticateUser(LoginInputModel loginInputModel)
        {
            throw new System.NotImplementedException();
        }

        public void Logout(int tokenId)
        {
            throw new System.NotImplementedException();
        }
    }
}