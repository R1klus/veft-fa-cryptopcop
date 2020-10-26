using System;
using System.Diagnostics.CodeAnalysis;

namespace Cryptocop.Software.API.Models.DTOs
{
    public class ExchangeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string AssetSymbol { get; set; }
        
        [AllowNull] public float? PriceInUsd { get; set; }
        
        [AllowNull] public DateTime? LastTrade { get; set; }
        
    }
}