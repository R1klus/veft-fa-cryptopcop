using System.ComponentModel.DataAnnotations;

namespace Cryptocop.Software.API.Models.Entities
{
    public class User
    {
        [Required] public int Id { get; set; }
        [Required] public string FullName { get; set; }
        [Required] public string Email { get; set; }
        
        [Required] 
        [DataType(DataType.Password)]
        public string HashedPassword { get; set; }
    }
}