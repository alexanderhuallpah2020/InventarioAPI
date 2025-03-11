using DataConsulting.Inventory.Domain.Products;
using DataConsulting.Inventory.Domain.Shared;
using DataConsulting.Inventory.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Persistence.Configurations
{
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder.HasKey(product => product.Id);

            builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(product => product.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

            builder.Property(product => product.Code);
            builder.Property(product => product.Name);
            builder.Property(product => product.Description);
            builder.Property(product => product.BaseUnit);
            builder.Property(product => product.ProductType);
            builder.Property(product => product.Category);
            builder.Property(product => product.Caliber);
            builder.Property(product => product.IsActive).HasDefaultValue(false);

            builder.OwnsOne(product => product.GeneralProperties);
            builder.OwnsOne(product => product.LogisticsProperties);
            builder.OwnsOne(product => product.AdjustmentFactors);
            builder.OwnsOne(product => product.PhysicalProperties);
            builder.OwnsOne(product => product.Expiration);
            builder.OwnsOne(product => product.Taxation);



            builder.OwnsOne(product => product.GeneralProperties);

            builder.Property(c => c.Version)
            .HasColumnName("Version")
            .IsRowVersion();
        }
    }
}
