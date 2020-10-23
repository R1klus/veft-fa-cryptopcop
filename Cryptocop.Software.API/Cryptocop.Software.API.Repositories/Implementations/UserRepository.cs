using System;
using Cryptocop.Software.API.Repositories.Interfaces;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        public UserDto CreateUser(RegisterInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public UserDto AuthenticateUser(LoginInputModel loginInputModel)
        {
            throw new NotImplementedException();
        }
    }
}