using System;
using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            UsuarioId = Guid.NewGuid();
        }

        [Key] public Guid UsuarioId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Perfil")]
        public string Perfil { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
    }
}