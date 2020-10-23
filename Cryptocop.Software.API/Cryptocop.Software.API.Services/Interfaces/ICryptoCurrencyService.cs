using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cryptocop.Software.API.Services.Interfaces
{
    public interface ICryptoCurrencyService
    {
        Task<IEnumerable<CryptoCurrencyDto>> GetAvailableCryptocurrencies();
    }
}