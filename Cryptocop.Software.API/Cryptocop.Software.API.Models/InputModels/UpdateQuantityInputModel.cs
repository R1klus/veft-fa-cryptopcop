using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class UpdateQuantityInputModel
    {
        [AllowNull][Range(0.01, float.MaxValue)] public float Quantity { get; set; }
    }
}