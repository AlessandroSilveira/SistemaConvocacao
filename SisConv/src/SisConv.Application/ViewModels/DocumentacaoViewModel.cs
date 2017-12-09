﻿using System;
using SisConv.Domain.Entities;

namespace SisConv.Application.ViewModels
{
	public class DocumentacaoViewModel
	{
		
		public Guid DocumentoId { get; set; }
		public Guid ProcessoId { get; set; }
		public string Descricao { get; set; }
		public DateTime DataCriacao { get; set; }
		public string Path { get; set; }
		public bool Ativo { get; set; }

		public virtual Processo Processo { get; set; }
	}
}