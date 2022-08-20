using AdminDashboard.Core.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Core.Contracts.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        public IProductsRepository Products { get; }
        public IStoreRepository Store { get; }
        public ISellManagementRepository SellManagement { get; }
        int Save();
    }
}
