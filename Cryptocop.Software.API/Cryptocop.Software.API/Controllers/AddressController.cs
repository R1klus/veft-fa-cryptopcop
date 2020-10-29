using System;
using System.Linq;
using Cryptocop.Software.API.Exceptions;
using Cryptocop.Software.API.Helpers;
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
        [Route("", Name = "GetAllAddresses")]
        public IActionResult GetAllAddresses()
        {
            var email = ClaimsHelper.GetClaim(User, "name");
            return Ok(_addressService.GetAllAddresses(email));
        }

        [HttpPost]
        [Route("", Name = "AddAddress")]
        public IActionResult AddAddress([FromBody] AddressInputModel address)
        {
            if (!ModelState.IsValid)
            {
                ErrorHandler.GetModelErrors(ModelState);
            }
            var email = ClaimsHelper.GetClaim(User, "name");
            var newAddress = _addressService.AddAddress(email, address);
            return CreatedAtRoute("AddAddress", new { id = newAddress.Id}, null);
        }

        [HttpDelete]
        [Route("{addressId}", Name = "DeleteAddressById")]
        public IActionResult DeleteAddressById(int addressId)
        {
            var email = ClaimsHelper.GetClaim(User, "name");
            _addressService.DeleteAddress(email, addressId);
            return NoContent();
        }

        
    }
}