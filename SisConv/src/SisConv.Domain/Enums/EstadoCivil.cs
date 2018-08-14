using System.ComponentModel;

namespace SisConv.Domain.Enums
{
    public enum EstadoCivil
    {
        [Description("Casado(a)")] Casado = 1,

        [Description("Solteiro(a)")] Solteiro = 2,

        [Description("Divorciado(a)")] Divorciado = 3,

        [Description("Separado Judicialmente")]
        SeparadoJudicialmente = 4,

        [Description("Viúvo(a)")] Viuvo = 5,

        [Description("Concubinato")] Concubinato = 6,

        [Description("Outros")] Outros = 7,

        [Description("União Estável")] UniaoEstável = 8
    }
}