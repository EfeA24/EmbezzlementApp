using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace embezzlement.ViewModels
{
    public class CreateViewModel
    {
        [Required]
        public string? UserName { get; set; }
        
        [Required]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords Does Not Match")]
        public string? ConfirmPassword { get; set;}
    }
}
