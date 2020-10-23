using System;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        
        [HttpGet]
        [Route("")]
        public IActionResult GetAllAddresses()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewAddress()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("id:int")]
        public IActionResult DeleteAddressById()
        {
            throw new NotImplementedException();
        }
    }
}