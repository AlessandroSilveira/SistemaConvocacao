﻿using System;
using System.Collections.Generic;
using SisConv.Domain.Core.Enums;

namespace SisConv.Domain.Core.Services
{
    public interface IListaOpcoes
    {
        string EnumDescription(Enum e);
        Dictionary<StatusComparecimento, string> MontarListaOpcoesComparecimento();
        Dictionary<StatusContratacao, string> MontarListaOpcoesContratacao();
    }
}