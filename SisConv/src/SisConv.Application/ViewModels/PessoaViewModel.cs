using System;
using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
    public class PessoaViewModel
    {
        public PessoaViewModel()
        {
            PessoaId = Guid.NewGuid();
        }

        [Key]
        public Guid PessoaId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nome Do Candidato")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Naturalidade")]
        public string Naturalidade { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Mãe")]
        public string Mae { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Pai")]
        public string Pai { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Orgão Emissor")]
        public string OrgaoEmissor { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Sexo")]
        public int Sexo { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Estado Civil")]
        public int EstadoCivil { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Filhos")]
        public int Filhos { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Cep")]
        public string Cep { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Uf")]
        public string Uf { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Deficiente")]
        public bool Deficiente { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Deficiência")]
        public string Deficiencia { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Condição Especial")]
        public string CondicaoEspecial { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Cpf")]
        public string Cpf { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Afro")]
        public bool Afro { get; set; }
    }
}