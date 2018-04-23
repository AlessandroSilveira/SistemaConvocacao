using System;

namespace SisConv.Domain.Entities
{
	public class Convocado
	{
		public Convocado()
		{
			ConvocadoId = Guid.NewGuid();
		}

		public Guid ConvocadoId { get; set; }
		public Guid ProcessoId { get; set; }
		public string Inscricao { get; set; }
		public string Nome { get; set; }
		public string Mae { get; set; }
		public string Pai { get; set; }
		public string Documento { get; set; }
		public string Cpf { get; set; }
		public string DataNascimento { get; set; }
		public string EstadoCivil { get; set; }
		public string Sexo { get; set; }
		public string FatorSanguineo { get; set; }
		public string Doador { get; set; }
		public string Endereco { get; set; }
		public string Complemento { get; set; }
		public string Numero { get; set; }
		public string Bairro { get; set; }
		public string Cep { get; set; }
		public string Cidade { get; set; }
		public string Uf { get; set; }
		public string Telefone { get; set; }
		public string Celular { get; set; }
		public string Recados { get; set; }
		public string Naturalidade { get; set; }
		public string Nacionalidade { get; set; }
		public string Email { get; set; }
		public string GrauInstrucao { get; set; }
		public string InstituicaoEnsino { get; set; }
		public string TelefoneIES { get; set; }
		public string Curso { get; set; }
		public string HorarioAulaIES { get; set; }
		public string PeriodoAtual { get; set; }
		public string ColacaoGrau { get; set; }
		public string Agencia { get; set; }
		public string NomeAgencia { get; set; }
		public string ContaCorrente { get; set; }
		public string Cargo { get; set; }
		public Guid CargoId { get; set; }
		public int Pontuacao { get; set; }
		public int Posicao { get; set; }
		public string Resultado { get; set; }

       
	}
}