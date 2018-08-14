using System;

namespace SisConv.Domain.Interfaces.Services
{
    public class DadosConvocados
    {
        public string File;
        public Guid Id;

        public DadosConvocados()
        {
            Id = Guid.NewGuid();
        }
    }
}