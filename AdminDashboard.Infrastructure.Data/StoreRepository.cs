using AdminDashboard.Core.Contracts.Repository;
using AdminDashboard.Core.Domain.Entities;
using AdminDashboard.Infrastructure.Data.Common;
using AdminDashboard.Infrastructure.EF;

namespace AdminDashboard.Infrastructure.Data
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        public StoreRepository(DemoContext Context) : base(Context)
        {
        }
    }
}
