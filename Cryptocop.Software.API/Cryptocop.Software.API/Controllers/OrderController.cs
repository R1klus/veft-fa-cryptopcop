using System;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAllOrders()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewOrder()
        {
            throw new NotImplementedException();
        }
        
        
    }
}