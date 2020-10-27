using System;
using System.Linq;
using System.Security.Cryptography;
using Cryptocop.Software.API.Helpers;
using Cryptocop.Software.API.Models.InputModels;
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
        [Route("", Name = "GetPayments")]
        public IActionResult GetPayments()
        {
            var email = ClaimsHelper.GetClaim(User, "email");
            var paymentCards = _paymentService.GetStoredPaymentCards(email);
            return Ok(paymentCards);
        }

        [HttpPost]
        [Route("", Name = "AddPaymentMethod")]
        public IActionResult AddPaymentMethod([FromBody] PaymentCardInputModel paymentCard)
        {
            if (!ModelState.IsValid)
            {
                ErrorHandler.GetModelErrors(ModelState);
            }
            var email = ClaimsHelper.GetClaim(User, "email");
            _paymentService.AddPaymentCard(email, paymentCard);
            return CreatedAtRoute("AddPaymentMethod", null);
        }
    }
}