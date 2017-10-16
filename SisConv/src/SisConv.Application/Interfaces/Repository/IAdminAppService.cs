using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.Interfaces.Repository
{
    public interface IAdminAppService : IDisposable
    {
        Admin2ViewModel Add(Admin2ViewModel obj);
        Admin2ViewModel GetById(Guid id);
        IEnumerable<Admin2ViewModel> GetAll();
        Admin2ViewModel Update(Admin2ViewModel obj);
        void Remove(Guid id);
        IEnumerable<Admin2ViewModel> Search(Expression<Func<Admin, bool>> predicate);
    }
}