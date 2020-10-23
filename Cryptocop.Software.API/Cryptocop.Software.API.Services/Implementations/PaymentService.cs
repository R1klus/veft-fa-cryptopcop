using System.Collections.Generic;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
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