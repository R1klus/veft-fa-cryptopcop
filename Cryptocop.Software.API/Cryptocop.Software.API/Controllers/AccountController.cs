using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        [HttpPost]
        [Route("/register")]
        public IActionResult Register()
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        [Route("/signin")]
        public IActionResult SignIn()
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        [Route("/signout")]
        public IActionResult SignOut()
        {
            throw new System.NotImplementedException();
        }
    }
}