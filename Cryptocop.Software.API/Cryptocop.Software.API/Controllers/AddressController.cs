using System;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }


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