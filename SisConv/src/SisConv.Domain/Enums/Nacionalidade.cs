using System.ComponentModel;

namespace SisConv.Domain.Enums
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