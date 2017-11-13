using System;
using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
	public class DadosConvocadosViewModel
	{
		[Key]
		public Guid Id { get; set; }
		public string File { get; set; }
	}
}