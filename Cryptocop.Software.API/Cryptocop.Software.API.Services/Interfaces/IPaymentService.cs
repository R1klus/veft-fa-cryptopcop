using System.Collections.Generic;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Services.Interfaces
{
    public interface IPaymentService
    {
        PaymentCardDto AddPaymentCard(string email, PaymentCardInputModel paymentCard);
        IEnumerable<PaymentCardDto> GetStoredPaymentCards(string email);
    }
}