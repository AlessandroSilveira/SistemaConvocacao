using System;
using System.Collections.Generic;
using SisConv.Domain.Core.Enums;

namespace SisConv.Domain.Core.Services
{
    public class MontaListaComEnum : IMontaListaComEnum
    {
        private readonly IEnumDescription _enumDescription;

        public MontaListaComEnum(IEnumDescription enumDescription)
        {
            _enumDescription = enumDescription;
        }

        public Dictionary<StatusComparecimento, string> MontarListaOpcoesComparecimento()
        {
            var opcoesComp = new Dictionary<StatusComparecimento, string>();
           
            foreach (StatusComparecimento val in Enum.GetValues(typeof(StatusComparecimento)))
                opcoesComp.Add(val, _enumDescription.GetEnumDescription(val));
            return opcoesComp;
        }

        public Dictionary<StatusContratacao, string> MontarListaOpcoesContratacao()
        {
            var opcoesContratacao = new Dictionary<StatusContratacao, string>();

            foreach (StatusContratacao val in Enum.GetValues(typeof(StatusContratacao)))
                opcoesContratacao.Add(val, _enumDescription.GetEnumDescription(val));
            return opcoesContratacao;
        }
    }
}