using System;
using System.Collections.Generic;

namespace SisConv.Domain.Services
{
	public class ListasOpcoes : IListaOpcoes
    {
        private readonly IEnumDescription _enumDescription;
        private readonly IMontaListaComEnum _montaListaComEnum;

        public ListasOpcoes(IEnumDescription enumDescription, IMontaListaComEnum montaListaComEnum)
        {
            _enumDescription = enumDescription;
            _montaListaComEnum = montaListaComEnum;
        }

        public string EnumDescription(Enum e)
        {
            return _enumDescription.GetEnumDescription(e);
        }

	    public Dictionary<TEnum, string> MontarListaOpcoes<TEnum>()
	    {
		    return _montaListaComEnum.MontarListaOpoes<TEnum>();
	    }	   
	}
}