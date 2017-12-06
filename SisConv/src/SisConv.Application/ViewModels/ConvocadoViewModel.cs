﻿using System;
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
        public string Nome { get; set; }
        public string Mae { get; set; }
        public string Sexo { get; set; }
        public string Nascimento { get; set; }
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

		public string Password { get; set; }
    }
}