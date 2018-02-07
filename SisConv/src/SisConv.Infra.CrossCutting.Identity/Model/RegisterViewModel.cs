using System.ComponentModel.DataAnnotations;

namespace SisConv.Infra.CrossCutting.Identity.Model
{
    public class RegisterViewModel
    {

        //[Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não conferem")]
        public string ConfirmPassword { get; set; }

	   // [Required]
	    [Display(Name = "Qual o seu Nome?")]
	    [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
		public string Nome { get; set; }

	    //[Required]
	    [Display(Name = "Qual o nome da Empresa?")]
	    [MaxLength(50, ErrorMessage = "O Empresa deve ter no máximo 50 caracteres.")]
		public string Empresa { get; set; }

	   // [Required]
	    [Display(Name = "Qual o CNPJ da Empresa?")]
	    [MaxLength(15, ErrorMessage = "O CNPJ deve ter no máximo 15 caracteres.")]
		public string Cnpj { get; set; }

	    //[Required]
	    [Display(Name = "Qual o seu Telefone?")]
	    [MaxLength(11, ErrorMessage = "O Telefone deve ter no máximo 11 caracteres.")]
		public string Telefone { get; set; }

	    //[Required]
	    [Display(Name = "Qual a Imagem da Empresa?")]
	    [MaxLength(100, ErrorMessage = "O Imagem deve ter no máximo 100 caracteres.")]
		public string Imagem { get; set; }

	    //[Required]
	    [Display(Name = "Ativo.")]
		public bool Ativo { get; set; }
    }
}