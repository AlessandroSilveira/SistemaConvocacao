﻿using System;
using System.Collections;
using System.Collections.Generic;
using SisConv.Domain.Core.Enums;

namespace SisConv.Domain.Core.Services
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

	    //      public Dictionary<StatusComparecimento, string> MontarListaOpcoesComparecimento()
  //      {
  //          return _montaListaComEnum.MontarListaOpcoesComparecimento();
  //      }

  //      public Dictionary<StatusContratacao, string> MontarListaOpcoesContratacao()
  //      {
  //          return _montaListaComEnum.MontarListaOpcoesContratacao();
  //      }	

		//public Dictionary<Estados, string> MontarListaEstado()
		//{
		//	return _montaListaComEnum.MontarListaEstado();
		//}

		//public Dictionary<int, string> MontarListaEstadoCivil()
		//{
		//	return _montaListaComEnum.MontarListaEstadoCivil();
		//}
	}
}