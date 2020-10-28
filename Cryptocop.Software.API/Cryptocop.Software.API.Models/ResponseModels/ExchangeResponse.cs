using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Cryptocop.Software.API.Models.ResponseModels
{
    public class ExchangeResponse
    {
        
        public string Id { get; set; }
        [JsonProperty("exchange_name")]
        public string Name { get; set; }
        [JsonProperty("exchange_slug")]
        public string Slug { get; set; }
        [JsonProperty("base_asset_symbol")]
        public string AssetSymbol { get; set; }
        
        [JsonProperty("price_usd")]
        [AllowNull] public float? PriceInUsd { get; set; }
        
        [JsonProperty("last_trade_at")]
        [AllowNull] public DateTime? LastTrade { get; set; }
    }
}