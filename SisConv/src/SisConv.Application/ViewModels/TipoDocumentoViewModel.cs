using System;
using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
    public class TipoDocumentoViewModel
    {
        [Key]
        public Guid TipoDocumentoId { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Tipo de Documento:*")]
        public string TipoDocumentos { get; private set; }
        
        [Required(AllowEmptyStrings = false)]
       
        [Display(Name = "Ativo:*")]
        public bool Ativo { get; set; }
    }
}