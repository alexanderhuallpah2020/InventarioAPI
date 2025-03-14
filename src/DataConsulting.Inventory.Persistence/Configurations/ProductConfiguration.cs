using DataConsulting.Inventory.Domain.Products;
using DataConsulting.Inventory.Domain.Products.ValueObjects;
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
            builder.Property(product => product.Id)
       .HasConversion(product => product!.Value, value => new ProductId(value));


            builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(product => product.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);


            builder.Property(product => product.Code)
            .HasMaxLength(500)
            .HasConversion(code => code!.Value, value => new Code(value));

            builder.Property(product => product.Name)
           .HasMaxLength(500)
           .HasConversion(name => name!.Value, value => new Name(value));

            builder.Property(product => product.Description)
           .HasMaxLength(500)
           .HasConversion(description => description!.Value, value => new Description(value));


            builder.Property(product => product.BaseUnit)
           .HasMaxLength(500)
           .HasConversion(baseUnit => baseUnit!.Value, value => new BaseUnit(value));


            builder.Property(product => product.ProductType)
           .HasMaxLength(500)
           .HasConversion(productType => productType!.Value, value => new ProductType(value));


            builder.Property(product => product.Category)
           .HasMaxLength(500)
           .HasConversion(category => category!.Value, value => new Category(value));


            builder.Property(product => product.Caliber)
           .HasMaxLength(500)
           .HasConversion(caliber => caliber!.Value, value => new Caliber(value));




            builder.Property(product => product.IsActive).HasDefaultValue(false);

            builder.OwnsOne(product => product.GeneralProperties);
            builder.OwnsOne(product => product.LogisticsProperties);
            builder.OwnsOne(product => product.AdjustmentFactors);
            builder.OwnsOne(product => product.PhysicalProperties);
            builder.OwnsOne(product => product.Expiration);
            builder.OwnsOne(product => product.Taxation);

            builder.Property(c => c.Version)
            .HasColumnName("Version")
            .IsRowVersion();
        }
    }
}
