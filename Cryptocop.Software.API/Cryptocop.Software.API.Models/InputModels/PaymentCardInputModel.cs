using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class PaymentCardInputModel
    {
        [Required][MinLength(3)] public string CardholderName { get; set; }
        [Required][CreditCard] public string CardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        
    }
}