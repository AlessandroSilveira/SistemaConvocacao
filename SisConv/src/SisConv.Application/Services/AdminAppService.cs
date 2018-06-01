using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Application.Services
{
    public class AdminAppService : ApplicationService , IAdminAppService
    {
        private readonly IAdminService _adminService;
	   

        public AdminAppService(IUnitOfWork unitOfWork, IAdminService adminService) : base(unitOfWork)
        {
	        _adminService = adminService;
	        
        }

        public void Dispose()
        {
            _adminService.Dispose();
        }

        public Admin2ViewModel Add(Admin2ViewModel obj)
        {
            var admin = Mapper.Map<Admin2ViewModel, Admin>(obj);
            BeginTransaction();
            _adminService.Add(admin);
            Commit();
            return obj;
        }

        public Admin2ViewModel GetById(Guid id)
        {
            return Mapper.Map<Admin, Admin2ViewModel>(_adminService.GetById(id));
        }

        public IEnumerable<Admin2ViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Admin>, IEnumerable<Admin2ViewModel>>(_adminService.GetAll());
        }

        public Admin2ViewModel Update(Admin2ViewModel obj)
        {
            BeginTransaction();
            _adminService.Update(Mapper.Map<Admin2ViewModel, Admin>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _adminService.Remove(id);
            Commit();
        }

        public IEnumerable<Admin2ViewModel> Search(Expression<Func<Admin, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<Admin>, IEnumerable<Admin2ViewModel>>(_adminService.Search(predicate));
        }

		public Admin2ViewModel GetOne(Expression<Func<Admin, bool>> predicate)
		{
			return Mapper.Map<Admin, Admin2ViewModel>(_adminService.GetOne(predicate));
		}
	}
}