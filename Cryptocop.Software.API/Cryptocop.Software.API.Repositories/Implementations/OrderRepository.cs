using System;
using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<OrderDto> GetOrders(string email)
        {
            throw new NotImplementedException();
        }

        public OrderDto CreateNewOrder(string email, OrderInputModel order)
        {
            throw new NotImplementedException();
        }
    }
}