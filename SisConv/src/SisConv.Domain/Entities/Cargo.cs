﻿using System;

namespace SisConv.Domain.Entities
{
    public class Cargo
    {
        public Cargo()
        {
            CargoId = Guid.NewGuid();
        }

        public Guid CargoId { get; set; }
        public Guid ConvocacaoId { get; set; }
        public string Nome { get; set; }
        public string CodigoCargo { get; set; }
        public bool Ativo { get; set; }
        public virtual Convocacao Convocacao { get; set; }
    }
}