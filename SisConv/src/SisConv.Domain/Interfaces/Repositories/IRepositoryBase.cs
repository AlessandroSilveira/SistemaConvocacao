using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace SisConv.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
            TEntity Add(TEntity obj);
            TEntity GetById(Guid id);
            IEnumerable<TEntity> GetAll();
            TEntity Update(TEntity obj);
            void Remove(Guid id);
            IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
            int SaveChanges();
            void Dispose();
			TEntity GetOne(Expression<Func<TEntity, bool>> predicate);
	}
}