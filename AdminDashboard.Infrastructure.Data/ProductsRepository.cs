using AdminDashboard.Core.Contracts.Repository;
using AdminDashboard.Core.Domain.Entities;
using AdminDashboard.Infrastructure.Data.Common;
using AdminDashboard.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Infrastructure.Data
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {
        public ProductsRepository(DemoContext Context) : base(Context)
        {
        }
    }
}
