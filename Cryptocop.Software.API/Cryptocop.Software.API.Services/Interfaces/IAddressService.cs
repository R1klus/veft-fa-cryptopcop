using System.Collections.Generic;

namespace Cryptocop.Software.API.Services.Interfaces
{
    public interface IAddressService
    {
        void AddAddress(string email, AddressInputModel address);
        IEnumerable<AddressDto> GetAllAddresses(string email);
        void DeleteAddress(string email, int addressId);
    }
}