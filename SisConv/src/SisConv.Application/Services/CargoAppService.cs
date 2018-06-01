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
    public class CargoAppService : ApplicationService, ICargoAppService
    {
        private readonly ICargoService _cargoService;
	 

		public CargoAppService(IUnitOfWork unitOfWork, ICargoService cargoService) : base(unitOfWork)
		{
			_cargoService = cargoService;
			
		}

        public void Dispose()
        {
            _cargoService.Dispose();
        }

        public CargoViewModel Add(CargoViewModel obj)
        {
            var cargo = Mapper.Map<CargoViewModel, Cargo>(obj);
            BeginTransaction();
            _cargoService.Add(cargo);
            Commit();
            return obj;
        }

        public CargoViewModel GetById(Guid id)
        {
            return Mapper.Map<Cargo, CargoViewModel>(_cargoService.GetById(id));
        }

        public IEnumerable<CargoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Cargo>,IEnumerable<CargoViewModel>>(_cargoService.GetAll());
        }

        public CargoViewModel Update(CargoViewModel obj)
        {
            BeginTransaction();
            _cargoService.Update(Mapper.Map<CargoViewModel, Cargo>(obj));
            Commit();
            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _cargoService.Remove(id);
            Commit();
        }

        public IEnumerable<CargoViewModel> Search(Expression<Func<Cargo, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<Cargo>, IEnumerable<CargoViewModel>>(_cargoService.Search(predicate));
        }

		public CargoViewModel GetOne(Expression<Func<Cargo, bool>> predicate)
		{
			return Mapper.Map<Cargo, CargoViewModel>(_cargoService.GetOne(predicate));
		}
	}
}