using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Exceptions;
using Cryptocop.Software.API.Repositories.Helpers;
using Cryptocop.Software.API.Repositories.Interfaces;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;
        public PaymentRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public PaymentCardDto AddPaymentCard(string email, PaymentCardInputModel paymentCard)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null){ throw new ResourceNotFoundException($"User with email {email} not found");}

            var cardEntity = _dbContext.PaymentCards.FirstOrDefault(p => p.CardholderName == user.FullName
                                                                         && p.CardNumber == paymentCard.CardNumber);
            if(cardEntity != null) { throw new ResourceAlreadyExistsException($"Payment Card already registered to {email}");}

            var paymentEntity = _mapper.Map<PaymentCard>(paymentCard);
            paymentEntity.UserId = user.Id;
            _dbContext.PaymentCards.Add(paymentEntity);
            _dbContext.SaveChanges();
            return _mapper.Map<PaymentCardDto>(paymentEntity);

        }

        public IEnumerable<PaymentCardDto> GetStoredPaymentCards(string email)
        {
            if(_dbContext.Users.FirstOrDefault(u => u.Email == email) == null){ throw new ResourceNotFoundException($"User with email {email} not found");}

            return _dbContext.PaymentCards
                .Where(p => p.User.Email == email)
                .Select(p => _mapper.Map<PaymentCardDto>(p));
        }
    }
}