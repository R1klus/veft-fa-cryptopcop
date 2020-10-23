using System.Collections.Generic;

namespace Cryptocop.Software.API.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetOrders(string email);
        void CreateNewOrder(string email, OrderInputModel order);
    }
}