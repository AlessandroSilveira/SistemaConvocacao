using System;
using System.ComponentModel;

namespace SisConv.Mvc.Models
{
    public static class EnumExtensions
    {
        public static string DisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[]) field
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0) return attributes[0].Description;
            return value.ToString();
        }
    }
}