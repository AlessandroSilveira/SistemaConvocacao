using System;

namespace SisConv.Application.ViewModels
{
	public class PrimeiroAcessoViewModel
	{
	    public Guid PrimeiroAcessoId { get; set; }
	    public string Email { get; set; }
		public Guid ConvocadoId { get; set; }
		public DateTime Data { get; set; }
    }
}