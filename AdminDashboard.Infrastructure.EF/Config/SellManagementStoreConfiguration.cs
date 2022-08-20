using AdminDashboard.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminDashboard.Infrastructure.EF.Config
{
    public class SellManagementStoreConfiguration : IEntityTypeConfiguration<SellManagementStore>
    {
        public void Configure(EntityTypeBuilder<SellManagementStore> builder)
        {
            builder.HasKey(a => a.SellManagementStoreID);
            builder.HasOne(a => a.Store).WithMany().HasForeignKey(a => a.StoreID);
            builder.HasOne(a => a.SellManagement).WithMany().HasForeignKey(a => a.SellManagementID);
        }
    }
}
