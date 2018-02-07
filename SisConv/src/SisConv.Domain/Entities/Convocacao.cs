using System;

namespace SisConv.Domain.Entities
{
    public class Convocacao
    {
        public Convocacao()
        {
            ConvocacaoId = Guid.NewGuid();
        }

        public Guid ConvocacaoId  { get; set; }
        public Guid ProcessoId { get; set; }
        public Guid ConvocadoId { get; set; }
        public DateTime DataEntregaDocumentos { get; set; }
        public string HorarioEntregaDocumento { get; set; }
        public string  EnderecoEntregaDocumento { get; set; }
        public bool EnviouEmail { get; set; }
        public string Desistente { get; set; }
        public bool Ativo { get; set; }
        public string StatusConvocacao { get; set; }
		public string StatusContratacao { get; set; } 
    }
}