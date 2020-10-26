using System.ComponentModel;
using Newtonsoft.Json;

namespace Cryptocop.Software.API.Models.DTOs
{
    public class CryptoCurrencyDto
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public float PriceInUsd { get; set; }
        public string ProjectDetails { get; set; }
    }
}