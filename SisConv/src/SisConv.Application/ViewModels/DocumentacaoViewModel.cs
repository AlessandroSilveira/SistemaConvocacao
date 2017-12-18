using System;
using System.ComponentModel.DataAnnotations;
using SisConv.Domain.Entities;

namespace SisConv.Application.ViewModels
{
	public class DocumentacaoViewModel
	{
		[Key]
		[Display(Name = "Id")]
		public Guid DocumentoId { get; set; }

		[Required]
		[Display(Name = "ProcessoId")]
		public Guid ProcessoId { get; set; }

		[Required(AllowEmptyStrings = false), MaxLength(100)]
		[Display(Name = "Descrição do documento")]
		public string Descricao { get; set; }

		
		[Display(Name = "Data de Criação")]
		public DateTime DataCriacao { get; set; }

		[Required(AllowEmptyStrings = false), MaxLength(100)]
		[Display(Name = "Path")]
		public string Path { get; set; }

		[Required(AllowEmptyStrings = false)]
		[Display(Name = "Ativo")]
		public bool Ativo { get; set; }
	}
}