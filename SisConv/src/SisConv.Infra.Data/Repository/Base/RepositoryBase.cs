using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Infra.Data.Context;

namespace SisConv.Infra.Data.Repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected SisConvContext SisConvContext;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(SisConvContext sisConvContext)
        {
            SisConvContext = sisConvContext;
            DbSet = SisConvContext.Set<TEntity>();
        }

        public TEntity Add(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            return objreturn;
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity Update(TEntity obj)
        {
            // var entry = Context.Entry(obj);
            //DbSet.Attach(obj);
            // entry.State = EntityState;
            //return obj;
            SisConvContext.Set<TEntity>().AddOrUpdate(obj);

            return obj;
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(GetById(id));
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return SisConvContext.SaveChanges();
        }

        public void Dispose()
        {
            SisConvContext.Dispose();
            GC.SuppressFinalize(this);
        }

		public TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
		{
			return DbSet.Where(predicate).FirstOrDefault();
		}
	}
}