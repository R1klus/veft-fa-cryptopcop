using System.Diagnostics.CodeAnalysis;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class ShoppingCartItemInputModel
    {
        public string ProductIdentifier { get; set; }
        [AllowNull] public float Quantity { get; set; } //TODO The range for this number is an include 0.01 to the float type maximum value
    }
}