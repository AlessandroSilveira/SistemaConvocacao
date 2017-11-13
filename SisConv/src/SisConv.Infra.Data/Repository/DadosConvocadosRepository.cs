using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Infra.Data.Context;
using SisConv.Infra.Data.Repository.Base;

namespace SisConv.Infra.Data.Repository
{
    public class DadosConvocadosRepository : RepositoryBase<Convocado>, IDadosConvocadosRepository
    {
        public DadosConvocadosRepository(SisConvContext sisConvContext) : base(sisConvContext)
        {
        }
    }
}