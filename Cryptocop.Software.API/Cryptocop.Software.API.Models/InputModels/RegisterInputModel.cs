using System.ComponentModel.DataAnnotations;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class RegisterInputModel
    {
        [Required] public string Email { get; set; }
        [Required] public string FullName { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string PasswordConfirmation { get; set; }
    }
}