using System.Linq;
using AutoMapper;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Exceptions;

namespace Cryptocop.Software.API.Repositories.Resolvers
{
    public class UnMaskCardNumberResolver : IValueResolver<Order, OrderDto, string>
    {
        
        public string Resolve(Order source, OrderDto destination, string destMember, ResolutionContext context)
        {
            var maskedCard = source.MaskedCreditCard;
            var paymentCard = source.User.PaymentCards
                .FirstOrDefault(p =>
                    p.CardNumber.Substring(p.CardNumber.Length - 4) == maskedCard.Substring(maskedCard.Length - 4));
            if (paymentCard != null) return paymentCard.CardNumber;
            throw new ResourceNotFoundException("Could not find a Registered payment method for Order");
        }
    }
}