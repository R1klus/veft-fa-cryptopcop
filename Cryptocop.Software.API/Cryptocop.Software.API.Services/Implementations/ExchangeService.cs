using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Cryptocop.Software.API.Models;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.ResponseModels;
using Cryptocop.Software.API.Services.Helpers;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Query;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ExchangeService : IExchangeService
    {
        
        private readonly IMapper _mapper;

        private const string Uri =
            "https://data.messari.io/api/v1/markets?fields=" +
            "id," +
            "exchange_name," +
            "exchange_slug," +
            "base_asset_symbol," +
            "price_usd," +
            "last_trade_at";
            
        public ExchangeService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Envelope<ExchangeDto>> GetExchanges(int pageNumber = 1)
        {
            var response = await CryptocurrencyHelper.Client.GetAsync(Uri+$"&page={pageNumber}");
            var exchangeDtos =  response
                .DeserializeJsonToList<ExchangeResponse>()
                .Result
                .Select(e => _mapper.Map<ExchangeDto>(e));
            var envelope = new Envelope<ExchangeDto>()
            {
                PageNumber = pageNumber,
                Items = exchangeDtos
            };
            return envelope;
        }
    }
}