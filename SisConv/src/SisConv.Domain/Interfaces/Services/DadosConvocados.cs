using System;

namespace SisConv.Domain.Interfaces.Services
{
    public class DadosConvocados
    {
        public DadosConvocados()
        {
             Id = Guid.NewGuid();
        }
        public Guid Id;
        public string File;
    }
}