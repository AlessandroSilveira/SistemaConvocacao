using System;
using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
    public class CargoViewModel
    {
        [Key] public Guid CargoId { get; set; }

        public Guid ProcessoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Preencher o campo Nome")]
        [Display(Name = "Nome")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Preencher o campo Código do Cargo")]
        [Display(Name = "Código do Cargo")]
        [MaxLength(4)]
        public string CodigoCargo { get; set; }

        [Required] [Display(Name = "Ativo")] public bool Ativo { get; set; }
    }
}