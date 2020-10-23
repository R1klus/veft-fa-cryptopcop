using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class AddressService : IAddressService
    {
        public void AddAddress(string email, AddressInputModel address)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAddress(string email, int addressId)
        {
            throw new System.NotImplementedException();
        }
    }
}