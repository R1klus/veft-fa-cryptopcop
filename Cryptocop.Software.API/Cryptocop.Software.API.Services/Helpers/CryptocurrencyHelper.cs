using System.Collections.Generic;
using System.Net.Http;

namespace Cryptocop.Software.API.Services.Helpers
{
    public static class CryptocurrencyHelper
    {
        public static HttpClient Client { get; set; } = new HttpClient();
        public static List<string> AllowedCurrencies { get; set; } = new List<string>()
        {
            "bitcoin",
            "ethereum",
            "tether",
            "monero",
            "btc",
            "eth",
            "usdt",
            "xmr"
        };
    }
}