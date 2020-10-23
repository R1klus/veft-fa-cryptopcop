namespace Cryptocop.Software.API.Models.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string ProductionIdentifier { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float TotalPrice { get; set; }
        
    }
}