using System;       

namespace SisConv.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
        }
      
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}