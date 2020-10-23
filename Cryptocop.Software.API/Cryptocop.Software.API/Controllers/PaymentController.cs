using System;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetPayments()
        {
            throw new NotImplementedException(); 
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddPaymentMethod()
        {
            throw new NotImplementedException();
        }
    }
}