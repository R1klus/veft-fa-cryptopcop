using System.ComponentModel.DataAnnotations.Schema;

namespace Cryptocop.Software.API.Models.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        [ForeignKey("User")] public int UserId { get; set; }
        public User User { get; set; }
    }
}