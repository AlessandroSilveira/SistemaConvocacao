﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SisConv.Domain.Entities;

namespace SisConv.Domain.Interfaces.Services
{
    public interface IConvocadoService : IDisposable
    {
        Convocado Add(Convocado obj);
        Convocado GetById(Guid id);
        IEnumerable<Convocado> GetAll();
        Convocado Update(Convocado obj);
        void Remove(Guid id);
        IEnumerable<Convocado> Search(Expression<Func<Convocado, bool>> predicate);
        Convocado GetOne(Expression<Func<Convocado, bool>> predicate);
        bool VerificaSeHaSobrenome(string nome);
    }
}