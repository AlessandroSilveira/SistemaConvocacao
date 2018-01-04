using System;
using System.Collections.Generic;
using System.ComponentModel;
using SisConv.Domain.Core.Enums;

namespace SisConv.Domain.Core.Services
{
    public class OpcoesComparecimento : IOpcoesComparecimento
    {
        public string EnumDescription(Enum e)
        {
            var t = e.GetType();
            DescriptionAttribute[] att = { };

            if (!Enum.IsDefined(t, e)) return att.Length > 0 ? att[0].Description ?? "Nulo" : e.ToString();
            var fieldInfo = t.GetField(e.ToString());
            att = (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return att.Length > 0 ? att[0].Description ?? "Nulo" : e.ToString();
        }

        public Dictionary<StatusComparecimento, string> MontarListaOpcoesComparecimento()
        {
            var opcoesComp = new Dictionary<StatusComparecimento, string>();
           
            foreach (StatusComparecimento val in Enum.GetValues(typeof(StatusComparecimento)))
                opcoesComp.Add(val, EnumDescription(val));
            return opcoesComp;
        }
    }
}