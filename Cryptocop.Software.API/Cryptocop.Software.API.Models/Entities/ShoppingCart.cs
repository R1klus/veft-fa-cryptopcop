using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cryptocop.Software.API.Models.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        // Navigation Properties
        public int UserId { get; set; }
        public User User { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        
    }
}