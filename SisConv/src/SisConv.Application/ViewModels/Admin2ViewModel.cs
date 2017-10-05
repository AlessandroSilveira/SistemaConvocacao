using System;
using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
    public class Admin2ViewModel
    {
        [Key]
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