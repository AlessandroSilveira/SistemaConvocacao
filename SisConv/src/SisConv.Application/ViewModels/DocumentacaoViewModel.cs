using System;
using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
    public class DocumentacaoViewModel
    {
        public DocumentacaoViewModel()
        {
            DocumentoId = Guid.NewGuid();
        }

        [Key] [Display(Name = "Id")] public Guid DocumentoId { get; set; }

        [Required]
        [Display(Name = "ProcessoId")]
        public Guid ProcessoId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Descrição do documento")]
        public string Descricao { get; set; }

        [Display(Name = "Data de Criação")] public DateTime DataCriacao { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Arquivo")]
        public string Path { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
    }
}