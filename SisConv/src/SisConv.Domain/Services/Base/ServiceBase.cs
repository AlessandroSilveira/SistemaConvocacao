using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Interfaces.Base;
using SisConv.Domain.Interfaces.Repositories;

namespace SisConv.Domain.Services.Base
{
	public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
	{
		private readonly IRepositoryBase<TEntity> _repositoryBase;

		public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
		{
			_repositoryBase = repositoryBase;
		}

		public void Add(TEntity obj)
		{
			_repositoryBase.Add(obj);
		}

		public TEntity GetById(Guid id)
		{
			return _repositoryBase.GetById(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _repositoryBase.GetAll();
		}

		public void Update(TEntity obj)
		{
			_repositoryBase.Update(obj);
		}

		public void Remove(Guid obj)
		{
			_repositoryBase.Remove(obj);
		}

		void IServiceBase<TEntity>.Dispose()
		{
			_repositoryBase.Dispose();
		}

	    public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
	    {
	        return _repositoryBase.Search(predicate);
	    }
			

		void IDisposable.Dispose()
		{
			_repositoryBase.Dispose();
		}

		public TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
		{
			return _repositoryBase.GetOne(predicate);
		}
	}
}
