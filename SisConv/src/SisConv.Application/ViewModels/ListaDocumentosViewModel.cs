using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConv.Application.ViewModels
{
    public class ListaDocumentosViewModel
    {
        public Guid ConvocacaoId { get;  set; }
        public string Nome { get;  set; }
        public string Curso { get;  set; }

        [Display(Name = "Arquivo")]
        public string Path { get;  set; }

        [Display(Name = "Tipo de Documento")]
        public string TipoDocumento { get;  set; }
        public DateTime DataPostagem { get;  set; }

        [Display(Name = "Inscrição")]
        public string Inscricao { get;  set; }
        public Guid DocumentoCandidatoId { get; set; }
    }
}
