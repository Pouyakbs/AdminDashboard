using AdminDashboard.Core.Contracts.Repository;
using AdminDashboard.Core.Contracts.UnitofWork;
using AdminDashboard.Infrastructure.Data;
using AdminDashboard.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Core.ApplicationService.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private DemoContext context;

        public UnitofWork(DemoContext context)
        {
            this.context = context;
            Products = new ProductsRepository(this.context);
            Store = new StoreRepository(this.context);
            SellManagement = new SellManagementRepository(this.context);
        }
        public IProductsRepository Products { get; private set; }

        public IStoreRepository Store { get; private set; }
        public ISellManagementRepository SellManagement { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
