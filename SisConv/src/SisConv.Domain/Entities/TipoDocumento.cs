using System;

namespace SisConv.Domain.Entities
{
    public class TipoDocumento
    {
        public Guid TipoDocumentoId { get; set; }
        public string TipoDocumentos { get; private set; }
        public bool Ativo { get; set; }
    }
}