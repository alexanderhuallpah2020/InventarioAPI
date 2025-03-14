using DataConsulting.Inventory.Domain.Abstractions;
using DataConsulting.Inventory.Domain.Primitives;
using DataConsulting.Inventory.Domain.Products.Events;
using DataConsulting.Inventory.Domain.Products.ValueObjects;
using DataConsulting.Inventory.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Products
{
    public sealed class Product : Entity<ProductId>
    {
        public byte[]? Version { get; set; }
        public UserId? UserId { get; private set; }
        public Code? Code { get; private set; }
        public Name? Name { get; private set; }
        public Description? Description { get; private set; }
        public BaseUnit? BaseUnit { get; private set; }
        public ProductType? ProductType { get; private set; }
        public Category? Category { get; private set; }
        public Caliber? Caliber { get; private set; }
        public bool IsActive { get; private set; }


        public GeneralProperties? GeneralProperties { get; private set; }
        public LogisticsProperties? LogisticsProperties { get; private set; }
        public AdjustmentFactors? AdjustmentFactors { get; private set; }
        public PhysicalProperties? PhysicalProperties { get; private set; }
        public Expiration? Expiration { get; private set; }
        public Taxation? Taxation { get; private set; }


        private Product() { }
        private Product(
            ProductId id,
            UserId userId,
            Code code,
            Name name,
            Description description,
            BaseUnit baseUnit,
            ProductType productType,
            Category category,
            Caliber caliber,
            bool isActive,
            GeneralProperties generalProperties,
            LogisticsProperties logisticsProperties,
            AdjustmentFactors adjustmentFactors,
            PhysicalProperties physicalProperties,
            Expiration expiration,
            Taxation taxation
            ) : base(id)
        {
            UserId = userId;
            Code = code;
            Name = name;
            Description = description;
            BaseUnit = baseUnit;
            ProductType = productType;
            Category = category;
            Caliber = caliber;
            IsActive = isActive;

            GeneralProperties = generalProperties;
            LogisticsProperties = logisticsProperties;
            AdjustmentFactors = adjustmentFactors;
            PhysicalProperties = physicalProperties;
            Expiration = expiration;
            Taxation = taxation;

        }
       

        public static Product Create(
            UserId UserId,
            Code Code,
            Name Name,
            Description Description,
            BaseUnit BaseUnit,
            ProductType ProductType,
            Category Category,
            Caliber Caliber,
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
                ProductId.New(),
                UserId,
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


            product.RaiseDomainEvent(new ProductCreatedDomainEvent(product.Id!));

            return product;
        }



        public void Update(
            Code code,
            Name name,
            Description description,
            BaseUnit baseUnit,
            ProductType productType,
            Category category,
            Caliber caliber,
            bool isActive,
            GeneralProperties generalProperties,
            LogisticsProperties logisticsProperties,
            AdjustmentFactors adjustmentFactors,
            PhysicalProperties physicalProperties,
            Expiration expiration,
            Taxation taxation
        )
        {
            Code = code;
            Name = name;
            Description = description;
            BaseUnit = baseUnit;
            ProductType = productType;
            Category = category;
            Caliber = caliber;
            IsActive = isActive;
            GeneralProperties = generalProperties;
            LogisticsProperties = logisticsProperties;
            AdjustmentFactors = adjustmentFactors;
            PhysicalProperties = physicalProperties;
            Expiration = expiration;
            Taxation = taxation;

            RaiseDomainEvent(new ProductUpdatedDomainEvent(Id!));
        }
    }
}
