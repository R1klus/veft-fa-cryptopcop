using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cryptocop.Software.API.Services.Interfaces
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingCartItemDto> GetCartItems(string email);
        Task AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemItem);
        void RemoveCartItem(string email, int id);
        void UpdateCartItemQuantity(string email, int id, float quantity);
        void ClearCart(string email);
    }
}