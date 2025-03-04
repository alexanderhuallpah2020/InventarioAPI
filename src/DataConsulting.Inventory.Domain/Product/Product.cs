using DataConsulting.Inventory.Domain.Abstractions;
using DataConsulting.Inventory.Domain.Primitives;
using DataConsulting.Inventory.Domain.Product.Events;
using DataConsulting.Inventory.Domain.Product.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Product
{
    public sealed class Product : AggregateRoot
    {
        private Product() { }
        public Product(
            Guid id,
            string Code,
            string Name,
            string Description,
            string BaseUnit,
            string ProductType,
            string Category,
            string Caliber,
            bool IsActive,
            GeneralProperties GeneralProperties,
            LogisticsProperties LogisticsProperties,
            AdjustmentFactors AdjustmentFactors,
            PhysicalProperties PhysicalProperties,
            Expiration Expiration,
            Taxation Taxation
            ) : base(id)
        {
            Id = id;
        }

        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? BaseUnit { get; private set; }
        public string? ProductType { get; private set; }
        public string? Category { get; private set; }
        public string? Caliber { get; private set; }
        public bool IsActive { get; private set; }


        public GeneralProperties? GeneralProperties { get; private set; }
        public LogisticsProperties? LogisticsProperties { get; private set; }
        public AdjustmentFactors? AdjustmentFactors { get; private set; }
        public PhysicalProperties? PhysicalProperties { get; private set; }
        public Expiration? Expiration { get; private set; }
        public Taxation? Taxation { get; private set; }


        public static Result<Product> Create(
            string Code,
            string Name,
            string Description,
            string BaseUnit,
            string ProductType,
            string Category,
            string Caliber,
            bool IsActive,
            GeneralProperties GeneralProperties,
            LogisticsProperties LogisticsProperties,
            AdjustmentFactors AdjustmentFactors,
            PhysicalProperties PhysicalProperties,
            Expiration Expiration,
            Taxation Taxation
            )
        {
            var product = new Product
            (
                Guid.NewGuid(),
                Code,
                Name,
                Description,
                BaseUnit,
                ProductType,
                Category,
                Caliber,
                IsActive,
                GeneralProperties,
                LogisticsProperties,
                AdjustmentFactors,
                PhysicalProperties,
                Expiration,
                Taxation
            );


            product.RaiseDomainEvent(new ProductCreatedDomainEvent(product.Id));

            return Result.Success(product);
        }

    }
}
