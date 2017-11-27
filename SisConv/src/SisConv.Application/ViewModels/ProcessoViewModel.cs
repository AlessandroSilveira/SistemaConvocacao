using System;
using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
    public class ProcessoViewModel
    {
        [Key]
        public Guid ProcessoId { get; set; }

        [Required]
        public Guid ClienteId { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }

        [Required]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
    }
}