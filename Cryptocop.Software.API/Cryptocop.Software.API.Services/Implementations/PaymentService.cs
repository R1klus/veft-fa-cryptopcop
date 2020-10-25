using System.Collections.Generic;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void AddPaymentCard(string email, PaymentCardInputModel paymentCard)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PaymentCardDto> GetStoredPaymentCards(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}