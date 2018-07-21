using System.Collections.Generic;

namespace SisConv.Domain.Services
{
	public interface IMontaListaComEnum
    {
	    Dictionary<TEnum, string> MontarListaOpoes<TEnum>();
    }
}