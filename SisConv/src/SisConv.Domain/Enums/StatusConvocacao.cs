using System.ComponentModel;

namespace SisConv.Domain.Enums
{
    public enum StatusConvocacao
    {
        [Description("Compareceu na entrega da documentação")]
        CompareceuEntregaDocumentacao,

        [Description("Não compareceu na entrega da documentação")]
        NaoCompareceuEntregaDocumentacao,

        [Description("Aguardando Término do Estágio")]
        AguardandoTerminoEstagio,

        [Description("Em Convocação")]
        EmConvocacao,

        [Description("Contratado")]
        Contratado,

        [Description("Desistente")]
        Desistente
    }
}