using AdminDashboard.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminDashboard.Infrastructure.EF.Config
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(a => a.ProductID);
            builder.Property(a => a.ProductName).HasColumnType("nvarchar(60)").IsRequired();
            builder.HasOne(a => a.Store).WithMany().HasForeignKey(a => a.StoreID);
            builder.HasOne(a => a.SellManagement).WithMany().HasForeignKey(a => a.FactorID);
        }
    }
}
