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
        public bool Ativo { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();
    }
}