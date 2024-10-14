using System.ComponentModel.DataAnnotations;

namespace LibraryBookApp.ViewModels
{
    public class RegisterViewModel
    {
        // Default values to fix nullability warning
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty; 

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty; 

        [Required]
        public string FirstName { get; set; } = string.Empty; 

        [Required]
        public string LastName { get; set; } = string.Empty; 

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty; 
    }
}
