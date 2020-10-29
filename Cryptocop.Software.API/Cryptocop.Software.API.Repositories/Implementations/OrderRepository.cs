using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Internal;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Exceptions;
using Cryptocop.Software.API.Repositories.Helpers;
using Cryptocop.Software.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<OrderDto> GetOrders(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null){throw new ResourceNotFoundException($"User with email {email} not found");}

            var orders = _dbContext.Orders
                .Where(o => o.User == user)
                .Select(o => _mapper
                    .Map<OrderDto>(o)).ToList();
            foreach (var order in orders)
            {
                order.OrderItems = _dbContext.OrderItems
                    .Where(oi => oi.OrderId == order.Id)
                    .Select(o => _mapper.Map<OrderItemDto>(o)).ToList();
            }
            return orders;
        }

        public OrderDto CreateNewOrder(string email, OrderInputModel order)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email)
                ??throw new ResourceNotFoundException($"User with email {email} not found");

            var address = _dbContext.Addresses.FirstOrDefault(a => a.Id == order.AddressId)
                ??throw new ResourceNotFoundException($"Address with Id {order.AddressId} not found");
            
            var paymentCard = _dbContext.PaymentCards.FirstOrDefault(p => p.Id == order.PaymentCardId)
                ??throw new ResourceNotFoundException($"Payment card with Id {order.PaymentCardId} not found");
            
            var cart = _dbContext.ShoppingCarts.FirstOrDefault(c => c.User.Email == email)
                ??throw new ResourceNotFoundException($"No cart for  with {email} was found");
            
            var cartItems = _dbContext.ShoppingCartItems.Where(ci => ci.ShoppingCartId == cart.Id).ToList();
            if(cartItems.Count == 0){throw new ResourceNotFoundException($"Cart is empty");}

            var newOrder = CreateOrder(user, address, paymentCard);
            PopulateItemsToOrder(newOrder, cartItems);
            var orderDto = _mapper.Map<OrderDto>(newOrder);
            orderDto.CreditCard = paymentCard.CardNumber;
            return orderDto;
        }

        private Order CreateOrder(User user, Address address, PaymentCard paymentCard)
        {
            var newOrder = new Order
            {
                User = user,
                FullName = user.FullName,
                Email = user.Email,
                Country = address.Country,
                City = address.City,
                StreetName = address.StreetName,
                HouseNumber = address.HouseNumber,
                ZipCode = address.ZipCode,
                CardHolderName = paymentCard.CardholderName,
                MaskedCreditCard = PaymentCardHelper.MaskPaymentCard(paymentCard.CardNumber),
                OrderDate = DateTime.Now
                
            };
            _dbContext.Add(newOrder);
            _dbContext.SaveChanges();
            return newOrder;
        }

        private void PopulateItemsToOrder(Order order, IEnumerable<ShoppingCartItem> cartItem)
        {
            var orderItems = cartItem
                .Select(ci => _mapper
                    .Map<OrderItem>(ci));
            foreach (var orderItem in orderItems)
            {
                order.TotalPrice += orderItem.TotalPrice;
                orderItem.OrderId = order.Id;
                _dbContext.Add(orderItem);
            }
            _dbContext.SaveChanges();
        }
    }
}