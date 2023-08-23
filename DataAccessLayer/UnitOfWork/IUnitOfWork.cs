﻿using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        int Commit();
        Task<int> CommitAsync();
    }
}
