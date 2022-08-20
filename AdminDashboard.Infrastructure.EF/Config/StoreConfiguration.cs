using AdminDashboard.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminDashboard.Infrastructure.EF.Config
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(a => a.StoreID);
            builder.Property(a => a.Stock).HasColumnType("int").IsRequired();
            builder.HasMany(a => a.Products);
        }
    }
}
