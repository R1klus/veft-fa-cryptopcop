using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Cryptocop.Software.API.Models.Entities
{
    public class Address
    {
        
        public int Id { get; set; }
        
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        
        // Navigation properties
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}