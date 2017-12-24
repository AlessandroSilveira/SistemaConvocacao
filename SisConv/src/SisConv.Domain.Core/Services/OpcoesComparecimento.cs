using System;
using System.ComponentModel;
using System.Reflection;

namespace SisConv.Domain.Core.Services
{
    public class OpcoesComparecimento : IOpcoesComparecimento
    {
        public  string EnumDescription(Enum e)
        {
            Type t = e.GetType();
            DescriptionAttribute[] att = { };

            if (Enum.IsDefined(t, e))
            {
                FieldInfo fieldInfo = t.GetField(e.ToString());
                att = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            return (att.Length > 0 ? att[0].Description ?? "Nulo" : e.ToString());
        }
    }
}
