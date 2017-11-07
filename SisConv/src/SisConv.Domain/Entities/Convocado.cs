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
        public Guid ConvocacaoId { get; set; }
        public string Inscricao { get; set; }
        public string Nome { get; set; }
        public string  Mae { get; set; }
        public bool Sexo { get; set; }
        public DateTime Nascimento { get; set; }
        public string Documento { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Cargo { get; set; }
        public Guid CargoId { get; set; }
        public int Pontuacao { get; set; }
        public int Posicao { get; set; }
        public string Resultado { get; set; }
    }
}