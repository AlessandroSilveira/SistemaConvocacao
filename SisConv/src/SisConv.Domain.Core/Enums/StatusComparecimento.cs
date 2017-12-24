using System.ComponentModel;

namespace SisConv.Domain.Core.Enums
{
    public enum StatusComparecimento
    {
        [Description("Compareceu na entrega da documentação")]
        CompareceuEntregaDocumentacao,
        [Description("Não compareceu na entrega da documentação")]
        NaoCompareceuEntregaDocumentacao,
        [Description("Desistente")]
        Desistente,
        [Description("Aguardando Término do Estágio")]
        AguardandoTerminoEstagio
    }
}

