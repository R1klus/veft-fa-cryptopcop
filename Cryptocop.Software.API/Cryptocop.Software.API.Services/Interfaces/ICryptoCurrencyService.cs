using System.Collections.Generic;
using System.Threading.Tasks;
using Cryptocop.Software.API.Models.DTOs;

namespace Cryptocop.Software.API.Services.Interfaces
{
    public interface ICryptoCurrencyService
    {
        Task<IEnumerable<CryptoCurrencyDto>> GetAvailableCryptocurrencies();
    }
}