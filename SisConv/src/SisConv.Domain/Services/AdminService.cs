using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public void Dispose()
        {
            _adminRepository.Dispose();
        }

        public Admin Add(Admin obj)
        {
            return _adminRepository.Add(obj);
        }

        public Admin GetById(Guid id)
        {
            return _adminRepository.GetById(id);
        }

        public IEnumerable<Admin> GetAll()
        {
            return _adminRepository.GetAll();
        }

        public Admin Update(Admin obj)
        {
            return _adminRepository.Update(obj);
        }

        public void Remove(Guid id)
        {
            _adminRepository.Remove(id);
        }

        public IEnumerable<Admin> Search(Expression<Func<Admin, bool>> predicate)
        {
            return _adminRepository.Search(predicate);
        }

        public Admin GetOne(Expression<Func<Admin, bool>> predicate)
        {
            return _adminRepository.GetOne(predicate);
        }
    }
}