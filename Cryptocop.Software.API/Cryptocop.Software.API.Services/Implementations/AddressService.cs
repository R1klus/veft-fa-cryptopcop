using System.Collections.Generic;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public AddressDto AddAddress(string email, AddressInputModel address)
        {
            return _addressRepository.AddAddress(email, address);
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            return _addressRepository.GetAllAddresses(email);
        }

        public void DeleteAddress(string email, int addressId)
        {
            _addressRepository.DeleteAddress(email, addressId);
        }
    }
}