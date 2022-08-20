using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Core.Contracts.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
