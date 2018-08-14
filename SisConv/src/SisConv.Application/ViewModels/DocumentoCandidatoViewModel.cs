﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
    public class DocumentoCandidatoViewModel
    {
        [Key]
        public Guid DocumentoCandidatoId { get; set; }
        
        [Required]
        public Guid ProcessoId { get; set; }
        
        [Required]
        public Guid ConvocadoId { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Documento:*")]
        public string Documento { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public DateTime DataInclusao { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Path { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Ativo { get; set; }
    }
}