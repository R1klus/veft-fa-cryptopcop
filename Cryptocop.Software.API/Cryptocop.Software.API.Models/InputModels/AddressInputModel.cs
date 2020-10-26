using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class AddressInputModel
    {
        [Required] public string StreetName { get; set; }
        [Required] public string HouseNumber { get; set; }
        [Required] public string ZipCode { get; set; }
        [Required] public string Country { get; set; }
        [Required] public string City { get; set; }
    }
}