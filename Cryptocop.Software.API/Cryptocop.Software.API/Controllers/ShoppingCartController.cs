using System;
using Cryptocop.Software.API.Helpers;
using Cryptocop.Software.API.Models.InputModels;
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

        [HttpGet]
        [Route("", Name = "GetAllCartItems")]
        public IActionResult GetAllCartItems()
        {
            var email = ClaimsHelper.GetClaim(User, "name");
            return Ok(_shoppingCartService.GetCartItems(email));
        }

        [HttpPost]
        [Route("", Name = "AddItemToCart")]
        public IActionResult AddItemToCart([FromBody] ShoppingCartItemInputModel cartItem)
        {
            if (!ModelState.IsValid)
            {
                ErrorHandler.GetModelErrors(ModelState);
            }

            var email = ClaimsHelper.GetClaim(User, "name");
            _shoppingCartService.AddCartItem(email, cartItem);
            return CreatedAtRoute("AddItemToCart", null);
        }
        
        [HttpPatch]
        [Route("{itemId}", Name = "UpdateQuantity")]
        public IActionResult UpdateQuantity([FromBody] ShoppingCartItemInputModel cartItem, int itemId)
        {
            var email = ClaimsHelper.GetClaim(User, "name");
            _shoppingCartService.UpdateCartItemQuantity(email, itemId, cartItem.Quantity);
            return Ok();
        }

        [HttpDelete]
        [Route("", Name = "ClearCart")]
        public IActionResult ClearCart()
        {
            var email = ClaimsHelper.GetClaim(User, "name");
            _shoppingCartService.ClearCart(email);
            return NoContent();
        }
        
        [HttpDelete]
        [Route("{itemId}", Name = "DeleteItemFromCart")]
        public IActionResult DeleteItemFromCart(int itemId)
        {
            var email = ClaimsHelper.GetClaim(User, "name");
            _shoppingCartService.RemoveCartItem(email, itemId);
            return NoContent();
        }
    }
}