using System.Collections.Generic;

namespace Cryptocop.Software.API.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        void AddAddress(string email, AddressInputModel address);
        IEnumerable<AddressDto> GetAllAddresses(string email);
        void DeleteAddress(string email, int addressId);
    }
}