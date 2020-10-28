using Cryptocop.Software.API.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Models.ResponseModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Exceptions;
using Cryptocop.Software.API.Services.Helpers;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private static readonly HttpClient Client = new HttpClient();

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public IEnumerable<ShoppingCartItemDto> GetCartItems(string email)
        {
            return _shoppingCartRepository.GetCartItems(email);
        }

        public Task AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemItem)
        {
            var allowedCurrencies = new List<string>()
            {
                "bitcoin",
                "ethereum",
                "tether",
                "monero"
            };
            var productIdentifier = shoppingCartItemItem.ProductIdentifier;
            if (!allowedCurrencies.Contains(productIdentifier.ToLower()))
            {
                throw new InvalidProductIdentifierException();
            }

            var response = Client.GetAsync($"https://data.messari.io/api/v1/assets/" +
                                                 $"{productIdentifier}/metrics?fields=market_data/price_usd").Result;
 
            var data = response.DeserializeJsonToObject<CryptoCurrencyResponse>(true).Result;
            
            _shoppingCartRepository.AddCartItem(email, shoppingCartItemItem, data.PriceInUsd);
            return null;
        }

        public void RemoveCartItem(string email, int id)
        {
            _shoppingCartRepository.RemoveCartItem(email, id);
        }

        public void UpdateCartItemQuantity(string email, int id, float quantity)
        {
            _shoppingCartRepository.UpdateCartItemQuantity(email, id, quantity);
        }

        public void ClearCart(string email)
        {
            _shoppingCartRepository.ClearCart(email);
        }
    }
}
