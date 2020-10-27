using System.ComponentModel.DataAnnotations;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class RegisterInputModel
    {
        [Required] public string Email { get; set; }
        [Required] public string FullName { get; set; }
        [Required] public string Password { get; set; }
        
        [Required] 
        [Compare(nameof(Password), ErrorMessage = "Passwords mismatch")]
        public string PasswordConfirmation { get; set; }
    }
}