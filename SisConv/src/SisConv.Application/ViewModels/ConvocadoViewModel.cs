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

        [Key] public Guid ConvocadoId { get; set; }

        public Guid ProcessoId { get; set; }
        public string Inscricao { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Nome:*")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Nome da Mãe:*")]
        public string Mae { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(10)]
        [Display(Name = "Sexo:*")]
        public string Sexo { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Documento de Identidade:*")]
        public string Documento { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(11)]
        [Display(Name = "CPF:*")]
        public string Cpf { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "E-mail:*")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(15)]
        [Display(Name = "Número de Telefone:*")]
        public string Telefone { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(15)]
        [Display(Name = "Celular:*")]
        public string Celular { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(200)]
        [Display(Name = "Endereço:*")]
        public string Endereco { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(10)]
        [Display(Name = "Número:*")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")] public string Complemento { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Bairro:*")]
        public string Bairro { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Cidade:*")]
        public string Cidade { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(2)]
        [Display(Name = "Estado:*")]
        public string Uf { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(10)]
        [Display(Name = "CEP:*")]
        public string Cep { get; set; }

        [Display(Name = "Cargo:*")] public string Cargo { get; set; }

        [Display(Name = "CargoId:*")] public Guid CargoId { get; set; }

        [Display(Name = "Pontuação")] public int Pontuacao { get; set; }

        [Display(Name = "Posição")] public int Posicao { get; set; }

        [Display(Name = "Resultado")] public string Resultado { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Naturalidade:*")]
        public string Naturalidade { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        //[RegularExpression("[A-Z0-9]\\s[A-Z0-9]", ErrorMessage = "O Nome do Pai deve conter um Sobrenome")]
        [Display(Name = "Nome do Pai:*")]
        public string Pai { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        [Display(Name = "Orgão Emissor:*")]
        public string OrgaoEmissor { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Estado Civil:*")]
        public int EstadoCivil { get; set; }

        public string EntrouNoSistema { get; set; }

        public string Desistente { get; set; }
        public DateTime DataEntregaDocumentos { get; set; }
        public Guid ConvocacaoId { get; set; }
        public string StatusConvocacao { get; set; }
        public string StatusContratacao { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(11)]
        [Display(Name = "Data de Nascimento:*")]
        public string DataNascimento { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(3)]
        [Display(Name = "Fator Sanguíneo:*")]
        public string FatorSanguineo { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(1)]
        [Display(Name = "Doador:*")]
        public string Doador { get; set; }

        [MaxLength(15)]
        [Display(Name = "Telefone Recados:*")]
        public string Recados { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Nacionalidade:*")]
        public string Nacionalidade { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Grau de Instrução:*")]
        public string GrauInstrucao { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Instituição de Ensino:*")]
        public string InstituicaoEnsino { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(15)]
        [Display(Name = "Telefone do IES:*")]
        public string TelefoneIES { get; set; }

        public string Curso { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Horário de Aula no IES:*")]
        public string HorarioAulaIes { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(11)]
        [Display(Name = "Período / Ano Atual:*")]
        public string PeriodoAtual { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(11)]
        [Display(Name = "Provável Mês/Ano da Colação de Grau:*")]
        public string ColacaoGrau { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Agência:*")]
        public string Agencia { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Nome da Agência:*")]
        public string NomeAgencia { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Display(Name = "Conta Corrente:*")]
        public string ContaCorrente { get; set; }
       
    }
}