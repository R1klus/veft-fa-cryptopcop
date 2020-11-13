using System;
using Cryptocop.Software.API.Helpers;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService, IQueueService queue)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("", Name = "GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var email = ClaimsHelper.GetClaim(User, "name");
            return Ok(_orderService.GetOrders(email));
        }

        [HttpPost]
        [Route("", Name = "CreateNewOrder")]
        public IActionResult CreateNewOrder([FromBody] OrderInputModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                ErrorHandler.GetModelErrors(ModelState);
            }
            var email = ClaimsHelper.GetClaim(User, "name");
            var newOrder = _orderService.CreateNewOrder(email, orderModel);
            return CreatedAtRoute("CreateNewOrder", new { id = newOrder.Id }, null);
        }

    }
}