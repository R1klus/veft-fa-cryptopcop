using System.Collections.Generic;

namespace Cryptocop.Software.API.Services.Interfaces
{
    public interface IPaymentService
    {
        void AddPaymentCard(string email, PaymentCardInputModel paymentCard);
        IEnumerable<PaymentCardDto> GetStoredPaymentCards(string email);
    }
}