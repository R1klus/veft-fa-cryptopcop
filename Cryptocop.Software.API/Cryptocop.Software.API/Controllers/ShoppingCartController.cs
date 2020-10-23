using System;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
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