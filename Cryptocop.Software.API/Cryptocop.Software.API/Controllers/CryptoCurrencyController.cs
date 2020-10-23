using System;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [ApiController]
    [Route("api/cryptocurrencies")]
    public class CryptoCurrencyController : ControllerBase
    {
        
        [HttpGet]
        [Route("")]
        public IActionResult GetAllCrupytoCurrencies()
        {
            throw new NotImplementedException();
        }
    }
}
