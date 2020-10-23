using System.Net.Http;
using System.Threading.Tasks;
using Cryptocop.Software.API.Models;
using Cryptocop.Software.API.Services.Helpers;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ExchangeService : IExchangeService
    {
        public Task<Envelope<ExchangeDto>> GetExchanges(int pageNumber = 1)
        {
            throw new System.NotImplementedException();
        }
    }
}