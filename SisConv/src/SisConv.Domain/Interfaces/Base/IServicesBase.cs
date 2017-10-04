using System;
using System.Collections.Generic;

namespace SisConv.Domain.Interfaces.Badr
{
	public interface IServiceBase<TEntity> where TEntity : class
	{
		void Add(TEntity obj);
		TEntity GetById(Guid id);
		IEnumerable<TEntity> GetAll();
		void Update(TEntity obj);
		void Remove(Guid obj);
		void Dispose();
	}
}
