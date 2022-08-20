using AdminDashboard.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminDashboard.Infrastructure.EF.Config
{
    public class SellManagementConfiguration : IEntityTypeConfiguration<SellManagement>
    {
        public void Configure(EntityTypeBuilder<SellManagement> builder)
        {
            builder.HasKey(a => a.SellManagementID);
            builder.Property(a => a.FactorID);
            builder.Property(a => a.SoldDate).HasColumnType("datetime").IsRequired();
            builder.Property(a => a.CustomerName).HasColumnType("nvarchar(60)").IsRequired();
            builder.HasOne(a => a.Products).WithMany().HasForeignKey(a => a.ProductID);
        }
    }
}
