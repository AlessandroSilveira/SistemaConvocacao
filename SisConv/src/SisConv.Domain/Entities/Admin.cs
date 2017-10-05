using System;

namespace SisConv.Domain.Entities
{
    public class Admin
    {
        public Admin()
        {
            AdminId = Guid.NewGuid();
        }

        public Guid AdminId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }
    }
}