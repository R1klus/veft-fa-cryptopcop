using System.Collections.Generic;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IQueueService _queueService;

        public OrderService(IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository, IQueueService queueService)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _queueService = queueService;
        }

        public IEnumerable<OrderDto> GetOrders(string email)
        {
            return _orderRepository.GetOrders(email);
        }

        public OrderDto CreateNewOrder(string email, OrderInputModel order)
        {
            var newOrder = _orderRepository.CreateNewOrder(email, order);
            _shoppingCartRepository.DeleteCart(email);
            _queueService.PublishMessage("create-order", newOrder);
            return newOrder;
        }
    }
}