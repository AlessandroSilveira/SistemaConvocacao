﻿using System.ComponentModel.DataAnnotations;

namespace SisConv.Infra.CrossCutting.Identity.Model
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
