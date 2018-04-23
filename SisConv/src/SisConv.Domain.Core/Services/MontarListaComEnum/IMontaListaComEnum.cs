using System;
using System.Collections;
using System.Collections.Generic;
using SisConv.Domain.Core.Enums;

namespace SisConv.Domain.Core.Services
{
    public interface IMontaListaComEnum
    {
  //      Dictionary<StatusComparecimento, string> MontarListaOpcoesComparecimento();

  //      Dictionary<StatusContratacao, string> MontarListaOpcoesContratacao();

		//Dictionary<Estados, string> MontarListaEstado();
		
		//Dictionary<EstadoCivil, string> MontarListaEstadoCivil();

	    Dictionary<TEnum, string> MontarListaOpoes<TEnum>();
    }
}