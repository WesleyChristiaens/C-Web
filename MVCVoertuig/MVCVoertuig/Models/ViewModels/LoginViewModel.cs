﻿using Microsoft.Build.Framework;


namespace MVCVoertuig.Models.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        public string? Email { get; set; }

        [Required]        
        public string? Password { get; set; }
    }
}
