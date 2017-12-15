using System;
using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
    public class ConvocacaoViewModel
    {
		[Key]
        public Guid ConvocacaoId { get; set; }
        public Guid ProcessoId { get; set; }
        public Guid ConvocadoId { get; set; }
        public DateTime DataEntregaDocumentos { get; set; }
        public TimeSpan HorarioEntregaDocumento { get; set; }
        public string EnderecoEntregaDocumento { get; set; }
        public bool EnviouEmail { get; set; }
        public string Desistente { get; set; }
        public bool Ativo { get; set; }
		public string CandidatosSelecionados { get; set; }

	    public string TextoParaDesistentes { get; set; }
	}
}