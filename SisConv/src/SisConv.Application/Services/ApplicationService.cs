using SisConv.Domain.Interfaces.Repositories;

namespace SisConv.Application.Services
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void BeginTransaction()
        {
            _unitOfWork.BeginTransaction();
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}