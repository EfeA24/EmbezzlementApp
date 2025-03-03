﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace embezzlement.ViewModels
{
    public class EditViewModel
    {
        public string Id { get; set; }
       
        public string? UserName { get; set; } = string.Empty;

        public string? FullName { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords Does Not Match")]
        public string? ConfirmPassword { get; set;}

        public IList<string>? SelectedRoles { get; set; }
    }
}
