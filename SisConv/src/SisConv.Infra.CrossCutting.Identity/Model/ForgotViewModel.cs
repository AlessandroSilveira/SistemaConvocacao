﻿using System.ComponentModel.DataAnnotations;

namespace SisConv.Infra.CrossCutting.Identity.Model
{
    public class ForgotViewModel
    {
        [Required] [Display(Name = "Email")] public string Email { get; set; }
    }
}