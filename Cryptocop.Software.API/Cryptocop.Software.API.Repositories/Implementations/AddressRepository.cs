using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public AddressRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void AddAddress(string email, AddressInputModel address)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null){throw new Exception("User not found");}

            var addressEntity = _mapper.Map<Address>(address);
            addressEntity.UserId = user.Id;

            _dbContext.Addresses.Add(addressEntity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            return _dbContext.Addresses
                .Where(a => a.User.Email == email)
                .Select(a => _mapper.Map<AddressDto>(a));
        }

        public void DeleteAddress(string email, int addressId)
        {
            if(_dbContext.Users.FirstOrDefault(u => u.Email == email) == null){ throw new Exception("User not found");}
            if(_dbContext.Addresses.FirstOrDefault(a => a.Id == addressId) == null){ throw new Exception("Address not found");}
            _dbContext.Addresses.Remove(_dbContext.Addresses.FirstOrDefault(a => a.Id == addressId && a.User.Email == email)!);
            _dbContext.SaveChanges();
        }
    }
}