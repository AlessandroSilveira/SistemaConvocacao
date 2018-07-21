using System;
using System.Collections.Generic;

namespace SisConv.Domain.Services
{
	public interface IListaOpcoes
    {
        string EnumDescription(Enum e);  
	    Dictionary<TEnum, string> MontarListaOpcoes<TEnum>();
	}
}