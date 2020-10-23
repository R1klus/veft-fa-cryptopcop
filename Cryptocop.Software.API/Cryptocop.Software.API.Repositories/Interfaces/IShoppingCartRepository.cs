using System.Collections.Generic;

namespace Cryptocop.Software.API.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        IEnumerable<ShoppingCartItemDto> GetCartItems(string email);
        void AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemItem, float priceInUsd);
        void RemoveCartItem(string email, int id);
        void UpdateCartItemQuantity(string email, int id, float quantity);
        void ClearCart(string email);
        void DeleteCart(string email);
    }
}