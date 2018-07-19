using System.ComponentModel;

namespace SisConv.Domain.Core.Enums
{
	public enum GrauInstrucao
    {
		[Description("Ensino Médio Completo")]
		EnsinoMedioCompleto,
		[Description("Ensino Superior Incompleto")]
	    EnsinoSuperiorIncompleto,
	    [Description("Ensino Superior Completo")]
	    EnsinoSuperiorCompleto,
	    [Description("Especializado")]
	    Especializado,
	    [Description("Mestrado")]
	    Mestrado,
	    [Description("Doutorado")]
	    Doutorado,
	    [Description("Pós-Doutorado")]
	    PosDoutorado
	}
}
