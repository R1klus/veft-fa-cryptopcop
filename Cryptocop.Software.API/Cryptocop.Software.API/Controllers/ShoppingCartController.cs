using System;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost]
        public IActionResult AddItemToCart()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("id:int")]
        public IActionResult DeleteItemFromCart()
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [Route("id:int")]
        public IActionResult UpdateQuantity()
        {
            throw new NotImplementedException();
        }
    }
}