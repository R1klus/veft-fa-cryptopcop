using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cryptocop.Software.API.Services.Helpers;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class CryptoCurrencyService : ICryptoCurrencyService
    {
        public Task<IEnumerable<CryptoCurrencyDto>> GetAvailableCryptocurrencies()
        {
            throw new System.NotImplementedException();
        }
    }
}