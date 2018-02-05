using System.ComponentModel;

namespace SisConv.Domain.Core.Enums
{
    public enum StatusContratacao
    {
        [Description("Em Convocação")]
        EmConvocacao,
        [Description("Contratado")]
        Contratado,
        [Description("Desistente")]
        Desistente
    }
}

