using System;
using System.Collections.Generic;

namespace SisConv.Domain.Entities
{
    public class Processo
    {
        public Processo()
        {
            ProcessoId = Guid.NewGuid();
        }

        public Guid ProcessoId { get; set; }
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
		public string TextoDeAceitacaoDaConvocacao { get; set; }
		public string TextoInicialTelaConvocado { get; set; }
	    public string TextoParaDesistentes { get; set; }
		public bool Ativo { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();
	    public virtual ICollection<Documentacao> Documentacoes { get; set; } = new List<Documentacao>();
	}
}