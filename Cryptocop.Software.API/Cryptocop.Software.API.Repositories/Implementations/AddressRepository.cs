using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
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