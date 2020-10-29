using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class ShoppingCartItemInputModel
    {
        public string ProductIdentifier { get; set; }
        [AllowNull][Range(0.01, float.MaxValue)] public float Quantity { get; set; } //TODO The range for this number is an include 0.01 to the float type maximum value
    }
}