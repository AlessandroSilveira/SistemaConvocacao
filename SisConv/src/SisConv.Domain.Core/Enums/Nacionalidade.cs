using System.ComponentModel;

namespace SisConv.Domain.Core.Enums
{
	public enum Nacionalidade
	{
		[Description("Brasileiro(a)")]
		Brasileiro,
		[Description("Naturalizado(a)")]
		Naturalizado,
		[Description("Outros")]
		Outros
	
	}
}