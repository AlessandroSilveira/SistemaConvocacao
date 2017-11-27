using System;

namespace SisConv.Application.ViewModels
{
    public class ConvocacaoViewModel
    {

        public Guid ConvocacaoId { get; set; }
        public Guid ProcessoId { get; set; }
        public Guid PessoaId { get; set; }
        public DateTime DataEntregaDocumentos { get; set; }
        public TimeSpan HorarioEntregaDocumento { get; set; }
        public string EnderecoEntregaDocumento { get; set; }
        public bool EnviouEmail { get; set; }
        public bool Desistente { get; set; }
        public bool Ativo { get; set; }
    }
}