using AdminDashboard.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Core.Contracts.Facade
{
    public interface IProductsFacade
    {
        ProductsDTO GetById(int id);
        IEnumerable<ProductsDTO> GetAll();
        int Add(ProductsDTO entity);
        void Remove(ProductsDTO entity);
        void Update(ProductsDTO entity);
    }
}
