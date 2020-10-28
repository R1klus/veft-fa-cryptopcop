using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.ResponseModels;
using Cryptocop.Software.API.Services.Helpers;
using Cryptocop.Software.API.Services.Interfaces;


namespace Cryptocop.Software.API.Services.Implementations
{
    public class CryptoCurrencyService : ICryptoCurrencyService
    {
        private readonly IMapper _mapper;
        private static readonly HttpClient Client = new HttpClient();

        public CryptoCurrencyService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<CryptoCurrencyDto>> GetAvailableCryptocurrencies()
        {
            var allowedCurrencies = new List<string>()
            {
                "bitcoin",
                "ethereum",
                "tether",
                "monero"
            };
            var response = await Client.GetAsync("https://data.messari.io/api/v2/assets?fields=" +
                                                 "id," +
                                                 "symbol," +
                                                 "name," +
                                                 "slug," +
                                                 "metrics/market_data/price_usd," +
                                                 "profile/general/overview/project_details");
            var data = await response.DeserializeJsonToList<CryptoCurrencyResponse>(true);
            var dataDto = data
                .Select(c => _mapper
                    .Map<CryptoCurrencyDto>(c))
                .Where(c => allowedCurrencies.Contains(c.Slug));
     
            
            return dataDto;
        }
    }
}