using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SisConv.Domain.Core.Enums
{
    public enum FatorSanguineo
    {
	    [Description("O-")]
		O_Negativo,
	    [Description("O+")]
		O_Positivo,
	    [Description("A-")]
		A_Negativo,
	    [Description("A+")]
		A_Positivo,
	    [Description("B-")]
		B_Negativo,
	    [Description("B+")]
		B_Positivo,
	    [Description("AB-")]
		AB_Negativo,
	    [Description("AB+")]
		AB_Positivo,
    }
}
