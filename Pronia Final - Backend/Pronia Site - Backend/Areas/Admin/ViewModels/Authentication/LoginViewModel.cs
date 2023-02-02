﻿using System.ComponentModel.DataAnnotations;

namespace Pronia_Site___Backend.Areas.Admin.ViewModels.Authentication
{
    public class LoginViewModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
