using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
	public class DadosConvocadosViewModel
	{
		[Key]
		public int Id { get; set; }
		public string File { get; set; }
	}
}