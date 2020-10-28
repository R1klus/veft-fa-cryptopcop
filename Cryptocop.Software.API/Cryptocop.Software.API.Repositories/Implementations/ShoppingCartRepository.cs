using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Exceptions;
using Cryptocop.Software.API.Repositories.Interfaces;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;

        public ShoppingCartRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<ShoppingCartItemDto> GetCartItems(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null){throw new ResourceNotFoundException($"User with email {email} not found");}
            
            var cart = _dbContext.ShoppingCarts.FirstOrDefault(s => s.User.Email == email) ?? CreateCart(user.Id);
            if (_dbContext.ShoppingCartItems.FirstOrDefault() == null)
            {
                return new List<ShoppingCartItemDto>();
            }
            return _dbContext.ShoppingCartItems
                .Where(sci => sci.ShoppingCartId == cart.Id)
                .Select(sci => _mapper.Map<ShoppingCartItemDto>(sci));
        }

        public void AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemItem, float priceInUsd)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            Console.WriteLine(user);
            if(user == null){throw new ResourceNotFoundException($"User with email {email} not found");}

            var cart = _dbContext.ShoppingCarts.FirstOrDefault(s => s.User.Email == email) ?? CreateCart(user.Id);
            
            var cartItem = _mapper.Map<ShoppingCartItem>(shoppingCartItemItem);

            cartItem.ShoppingCartId = cart.Id;
            cartItem.UnitPrice = priceInUsd;
            _dbContext.Add(cartItem);
            _dbContext.SaveChanges();
        }

        public void RemoveCartItem(string email, int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null){throw new ResourceNotFoundException($"User with email {email} not found");}
            
            var cart = _dbContext.ShoppingCarts.FirstOrDefault(c => c.User.Email == email);
            if(cart == null){throw new ResourceNotFoundException($"No cart for  with {email} was found");}
            
            var cartItem = _dbContext.ShoppingCartItems.FirstOrDefault(ci => ci.Id == id && ci.ShoppingCartId == cart.Id);
            if(cartItem == null){throw new ResourceNotFoundException($"No item with id {id} found in cart");}

            _dbContext.Remove(cartItem);
            
            _dbContext.SaveChanges();
        }

        public void UpdateCartItemQuantity(string email, int id, float quantity)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null){throw new ResourceNotFoundException($"User with email {email} not found");}

            var cart = _dbContext.ShoppingCarts.FirstOrDefault(c => c.User.Email == email);
            if(cart == null){throw new ResourceNotFoundException($"No cart for  with {email} was found");}

            var cartItem = _dbContext.ShoppingCartItems.FirstOrDefault(ci => ci.Id == id && ci.ShoppingCartId == cart.Id);
            if(cartItem == null){throw new ResourceNotFoundException($"No item with id {id} found in cart");}
            
            cartItem.Quantity = quantity;

            _dbContext.SaveChanges();
        }

        public void ClearCart(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null){throw new ResourceNotFoundException($"User with email {email} not found");}

            var cart = _dbContext.ShoppingCarts.FirstOrDefault(c => c.User.Email == email);
            if(cart == null){throw new ResourceNotFoundException($"No cart for  with {email} was found");}

            foreach (var cartItem in _dbContext.ShoppingCartItems.Where(ci => ci.ShoppingCartId == cart.Id))
            {
                _dbContext.Remove(cartItem);
            }

            _dbContext.SaveChanges();
        }

        public void DeleteCart(string email)
        {
            ClearCart(email);
            var cart = _dbContext.ShoppingCarts.FirstOrDefault(s =>
                s.UserId == _dbContext.Users.FirstOrDefault(u => u.Email == email).Id)!;
            _dbContext.ShoppingCarts.Remove(cart!);
            _dbContext.SaveChanges();
        }

        private ShoppingCart CreateCart(int id)
        {
            var cart = new ShoppingCart {UserId = id};
            _dbContext.Add(cart);
            _dbContext.SaveChanges();
            return cart;
        }
    }
}