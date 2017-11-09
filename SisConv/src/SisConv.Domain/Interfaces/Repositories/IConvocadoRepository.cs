using SisConv.Domain.Entities;

namespace SisConv.Domain.Interfaces.Repositories
{
	public interface IConvocadoRepository : IRepositoryBase<Convocado>
	{
		void SalvarCandidatos(string file);
	}
}