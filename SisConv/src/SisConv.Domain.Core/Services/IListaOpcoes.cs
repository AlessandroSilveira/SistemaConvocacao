using System;
using System.Collections;
using System.Collections.Generic;
using SisConv.Domain.Core.Enums;

namespace SisConv.Domain.Core.Services
{
    public interface IListaOpcoes
    {
        string EnumDescription(Enum e);
  //      Dictionary<StatusComparecimento, string> MontarListaOpcoesComparecimento();
  //      Dictionary<StatusContratacao, string> MontarListaOpcoesContratacao();
		//Dictionary<Estados, string> MontarListaEstado();
		//Dictionary<int, string> MontarListaEstadoCivil();
	    Dictionary<TEnum, string> MontarListaOpcoes<TEnum>();
	}
}