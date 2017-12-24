using System;
using System.ComponentModel.DataAnnotations;

namespace SisConv.Application.ViewModels
{
    public class ConvocadoViewModel
    {
        public ConvocadoViewModel()
        {
            ConvocadoId = Guid.NewGuid();
        }

        [Key]
        public Guid ConvocadoId { get; set; }
        public Guid ProcessoId { get; set; }
        public string Inscricao { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(100)]
	    [Display(Name = "Nome")]
		public string Nome { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(100)]
	    [Display(Name = "Nome da Mãe")]
		public string Mae { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(10)]
	    [Display(Name = "Sexo")]
		public string Sexo { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(100)]
	    [Display(Name = "Data de Nascimento")]
		public string Nascimento { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(100)]
	    [Display(Name = "Documento de Identidade")]
		public string Documento { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(11)]
	    [Display(Name = "CPF")]
		public string Cpf { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(100)]
	    [Display(Name = "E-mail")]
		public string Email { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(11)]
	    [Display(Name = "Número de Telefone")]
		public string Telefone { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(11)]
	    [Display(Name = "Celular")]
		public string Celular { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(200)]
	    [Display(Name = "Endereço")]
		public string Endereco { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(10)]
	    [Display(Name = "Numewro")]
		public string Numero { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(100)]
	    [Display(Name = "Complemento")]
		public string Complemento { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(100)]
	    [Display(Name = "Bairro")]
		public string Bairro { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(100)]
	    [Display(Name = "Cidade")]
		public string Cidade { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(2)]
	    [Display(Name = "Estado")]
		public string Uf { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(10)]
	    [Display(Name = "CEP")]
		public string Cep { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(100)]
	    [Display(Name = "Cargo")]
		public string Cargo { get; set; }

	    [Required(AllowEmptyStrings = false)]
	    [Display(Name = "CargoId")]
		public Guid CargoId { get; set; }
	    
	    [Display(Name = "Pontuação")]
		public int Pontuacao { get; set; }
	   
	    [Display(Name = "Posição")]
		public int Posicao { get; set; }
	   
	    [Display(Name = "Resultado")]
		public string Resultado { get; set; }

		[Required(AllowEmptyStrings = false), MaxLength(100)]
		[Display(Name = "Naturalidade")]
		public string Naturalidade { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(100)]
	    [Display(Name = "Nome do Pai")]
		public string Pai { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(50)]
	    [Display(Name = "Orgão Emissor")]
		public string OrgaoEmissor { get; set; }

	    [Required(AllowEmptyStrings = false)]
	    [Display(Name = "Estado Civil")]
		public int EstadoCivil { get; set; }

		[Required(AllowEmptyStrings = false)]
		[Display(Name = "Filhos")]
		public int Filhos { get; set; }

	    [Required(AllowEmptyStrings = false)]
	    [Display(Name = "Deficiente")]
		public bool Deficiente { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(100)]
	    [Display(Name = "Deficiencia")]
		public string Deficiencia { get; set; }

	    [Required(AllowEmptyStrings = false), MaxLength(100)]
	    [Display(Name = "Condição Especial")]
		public string CondicaoEspecial { get; set; }

	    [Required(AllowEmptyStrings = false)]
	    [Display(Name = "Afrodescendente")]
		public bool Afro { get; set; }

        public string Desistente { get; set; }

        public DateTime DataEntregaDocumentos { get; set; }

    }
}