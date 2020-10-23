using System.Collections.Generic;

namespace Cryptocop.Software.API.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        void AddPaymentCard(string email, PaymentCardInputModel paymentCard);
        IEnumerable<PaymentCardDto> GetStoredPaymentCards(string email);
    }
}