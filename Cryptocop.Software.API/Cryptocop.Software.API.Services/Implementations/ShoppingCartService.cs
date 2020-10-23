using Cryptocop.Software.API.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Helpers;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        public IEnumerable<ShoppingCartItemDto> GetCartItems(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemItem)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCartItem(string email, int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCartItemQuantity(string email, int id, float quantity)
        {
            throw new System.NotImplementedException();
        }

        public void ClearCart(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}
