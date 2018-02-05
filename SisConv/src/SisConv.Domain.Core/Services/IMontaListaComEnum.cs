using System.Collections.Generic;
using SisConv.Domain.Core.Enums;

namespace SisConv.Domain.Core.Services
{
    public interface IMontaListaComEnum
    {
        Dictionary<StatusComparecimento, string> MontarListaOpcoesComparecimento();
        Dictionary<StatusContratacao, string> MontarListaOpcoesContratacao();
    }
}