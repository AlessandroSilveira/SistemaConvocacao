using System;

namespace SisConv.Domain.Entities
{
    public class Pessoa
    {
        public Pessoa()
        {
            PessoaId = Guid.NewGuid();
        }

        public Guid PessoaId { get; set; }
        public string Nome { get; set; }
        public string Naturalidade { get; set; }
        public string Mae { get; set; }
        public string Pai { get; set; }
        public string Documento { get; set; }
        public string OrgaoEmissor { get; set; }
        public int Sexo { get; set; }
        public int EstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Filhos { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cargo { get; set; }
        public bool Deficiente { get; set; }
        public string Deficiencia { get; set; }
        public string CondicaoEspecial { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public bool Afro { get; set; }

    }
}
