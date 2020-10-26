using System;
using System.Linq;
using Cryptocop.Software.API.Models.InputModels;
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
            var email = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            return Ok(_addressService.GetAllAddresses(email));
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddAddress([FromBody] AddressInputModel address)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            _addressService.AddAddress(email, address);

            return Ok();
        }

        [HttpDelete]
        [Route("{addressId}")]
        public IActionResult DeleteAddressById(int addressId)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            _addressService.DeleteAddress(email, addressId);
            return NoContent();
        }
    }
}