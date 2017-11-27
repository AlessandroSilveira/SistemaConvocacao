using System;

namespace SisConv.Domain.Entities
{
    public class Cargo
    {
        public Cargo()
        {
            CargoId = Guid.NewGuid();
        }

        public Guid CargoId { get; set; }
        public Guid ProcessoId { get; set; }
        public string Nome { get; set; }
        public string CodigoCargo { get; set; }
        public bool Ativo { get; set; }
        public virtual Processo Processo { get; set; }
    }
}