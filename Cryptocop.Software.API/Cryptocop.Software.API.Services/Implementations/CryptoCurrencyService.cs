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
        
        private const string Uri = "https://data.messari.io/api/v2/assets?fields="
                                   + "id," + "symbol," + "name," + "slug," + 
                                   "metrics/market_data/price_usd," + 
                                   "profile/general/overview/project_details";

        public CryptoCurrencyService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<CryptoCurrencyDto>> GetAvailableCryptocurrencies()
        {
            var response = await CryptocurrencyHelper.Client.GetAsync(Uri);
            var data = await response.DeserializeJsonToList<CryptoCurrencyResponse>(true);
            var dataDto = data
                .Select(c => _mapper
                    .Map<CryptoCurrencyDto>(c))
                .Where(c => CryptocurrencyHelper.AllowedCurrencies.Contains(c.Slug));

            return dataDto;
        }
    }
}