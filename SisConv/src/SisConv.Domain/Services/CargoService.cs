using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Repositories;
using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoService(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public void Dispose()
        {
            _cargoRepository.Dispose();
        }

        public Cargo Add(Cargo obj)
        {
            return _cargoRepository.Add(obj);
        }

        public Cargo GetById(Guid id)
        {
            return _cargoRepository.GetById(id);
        }

        public IEnumerable<Cargo> GetAll()
        {
            return _cargoRepository.GetAll();
        }

        public Cargo Update(Cargo obj)
        {
            return _cargoRepository.Update(obj);
        }

        public void Remove(Guid id)
        {
            _cargoRepository.Remove(id);
        }

        public IEnumerable<Cargo> Search(Expression<Func<Cargo, bool>> predicate)
        {
            return _cargoRepository.Search(predicate);
        }
    }
}