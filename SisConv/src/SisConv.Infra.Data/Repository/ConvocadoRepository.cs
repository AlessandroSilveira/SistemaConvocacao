using System;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Infra.Data.Context;
using SisConv.Infra.Data.Repository.Base;

namespace SisConv.Infra.Data.Repository
{
    public class ConvocadoRepository : RepositoryBase<Convocado>, IConvocadoRepository
    {
        public ConvocadoRepository(SisConvContext sisConvContext) : base(sisConvContext)
        {
        }
    }
}