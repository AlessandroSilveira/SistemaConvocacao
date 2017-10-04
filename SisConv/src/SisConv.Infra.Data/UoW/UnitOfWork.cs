using System;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Infra.Data.Context;

namespace SisConv.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SisConvContext _sisConvContext;
        private bool _disposed;


        public UnitOfWork(SisConvContext sisConvContext)
        {
            _sisConvContext = sisConvContext;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _sisConvContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _sisConvContext.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}