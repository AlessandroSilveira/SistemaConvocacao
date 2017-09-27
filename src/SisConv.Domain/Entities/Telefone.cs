using System;

namespace SisConv.Domain.Entities
{
    public class Telefone
    {
        public Telefone()
        {
            TelefoneId = Guid.NewGuid();
        }

        public Guid TelefoneId { get; set; }
        public Pessoa PessoaId { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }

    }
}
