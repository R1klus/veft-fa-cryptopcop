using System;

namespace Cryptocop.Software.API.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string CardHolderName { get; set; }
        public string MaskedCreditCard { get; set; } //TODO MASK CREDIT CARD
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
    }
}