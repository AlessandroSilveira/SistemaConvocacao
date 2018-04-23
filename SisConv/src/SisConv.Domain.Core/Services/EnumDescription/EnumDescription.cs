using System;
using System.ComponentModel;

namespace SisConv.Domain.Core.Services
{
    public class EnumDescription: IEnumDescription
    {
        public string GetEnumDescription(Enum e)
        {
            var t = e.GetType();
            DescriptionAttribute[] att = { };

            if (!Enum.IsDefined(t, e)) return att.Length > 0 ? att[0].Description ?? "Nulo" : e.ToString();
            var fieldInfo = t.GetField(e.ToString());
            att = (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return att.Length > 0 ? att[0].Description ?? "Nulo" : e.ToString();
        }
    }
}