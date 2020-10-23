using System;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/exchanges")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAllExchanges()
        {
            throw new NotImplementedException();
        }
    }
}