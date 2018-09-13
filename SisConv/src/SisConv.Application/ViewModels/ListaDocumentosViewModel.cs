using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConv.Application.ViewModels
{
    public class ListaDocumentosViewModel
    {
        public Guid ConvocacaoId { get; internal set; }
        public string Nome { get; internal set; }
        public string Curso { get; internal set; }
        public string Path { get; internal set; }
        public string TipoDocumento { get; internal set; }
        public DateTime DataPostagem { get; internal set; }
        public string Inscricao { get; internal set; }
        public Guid DocumentoCandidatoId { get; set; }
    }
}
