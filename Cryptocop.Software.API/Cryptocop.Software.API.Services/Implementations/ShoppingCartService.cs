﻿using Cryptocop.Software.API.Services.Interfaces;
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

        public ShoppingCartItemDto AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemItem)
        {
            var productIdentifier = shoppingCartItemItem.ProductIdentifier;
            if (!CryptocurrencyHelper.AllowedCurrencies.Contains(productIdentifier.ToLower()))
            {
                throw new InvalidProductIdentifierException();
            }

            var response = Client.GetAsync($"https://data.messari.io/api/v1/assets/" +
                                                 $"{productIdentifier}/metrics?fields=market_data/price_usd").Result;
 
            var data = response.DeserializeJsonToObject<CryptoCurrencyResponse>(true).Result;
            
            return _shoppingCartRepository.AddCartItem(email, shoppingCartItemItem, data.PriceInUsd);
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
