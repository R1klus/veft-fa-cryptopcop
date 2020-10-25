using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register()
        {
            throw new System.NotImplementedException();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn()
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        [Route("signout")]
        public IActionResult SignOut()
        {
            throw new System.NotImplementedException();
        }
    }
}