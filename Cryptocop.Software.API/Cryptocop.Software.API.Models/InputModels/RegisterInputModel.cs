using System.ComponentModel.DataAnnotations;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class RegisterInputModel
    {
        [Required][EmailAddress] public string Email { get; set; }
        [Required][MinLength(3)] public string FullName { get; set; }
        [Required][MinLength(8)] public string Password { get; set; }
        
        [Required] 
        [MinLength(8)]
        [Compare(nameof(Password), ErrorMessage = "Passwords mismatch")]
        public string PasswordConfirmation { get; set; }
    }
}