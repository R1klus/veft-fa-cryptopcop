using System;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

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