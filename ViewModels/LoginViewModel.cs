using System.ComponentModel.DataAnnotations;

namespace UserManagementApp.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; } // Add 'required' modifier

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty; // Default to empty string
        public bool RememberMe { get; set; }
    }
}
