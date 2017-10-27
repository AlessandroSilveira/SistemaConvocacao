using System;

namespace SisConv.Domain.Entities
{
    public class Convocacao
    {
        public Convocacao()
        {
            ConvocacaoId = Guid.NewGuid();
        }

        public Guid ConvocacaoId { get; set; }
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}