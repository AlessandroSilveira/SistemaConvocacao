using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Application.Services;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;

namespace SisConv.Application.Interfaces.Repository
{
    public interface ICargoAppService : IDisposable
    {
        CargoViewModel Add(CargoViewModel obj);
        CargoViewModel GetById(Guid id);
        IEnumerable<CargoViewModel> GetAll();
        CargoViewModel Update(CargoViewModel obj);
        void Remove(Guid id);
        IEnumerable<CargoViewModel> Search(Expression<Func<Cargo, bool>> predicate);
		CargoViewModel GetOne(Expression<Func<Cargo, bool>> predicate);
	}
}