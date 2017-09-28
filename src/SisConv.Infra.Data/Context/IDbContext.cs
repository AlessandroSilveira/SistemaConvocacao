using Microsoft.EntityFrameworkCore;

namespace SisConv.Infra.Data.Context
{
	public interface IDbContext
	{
		DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
		int SaveChanges();
	}
}