namespace SisConv.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}