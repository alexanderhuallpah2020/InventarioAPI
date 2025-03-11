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
    public sealed class Product : Entity
    {
        public Product(Guid id, string code, string name, string description, string baseUnit, string productType, string category, string caliber, bool isActive, GeneralProperties generalProperties, LogisticsProperties logisticsProperties, AdjustmentFactors adjustmentFactors, PhysicalProperties physicalProperties, Expiration expiration, Taxation taxation)
        {
            Id = id;
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

        private Product() { }


        private Product(
            Guid id,
            Guid userId,
            string code,
            string name,
            string description,
            string baseUnit,
            string productType,
            string category,
            string caliber,
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
        public Guid Id { get; set; }
        public byte[] Version { get; set; }
        public Guid UserId { get; private set; }
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
            Guid UserId,
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


            product.RaiseDomainEvent(new ProductCreatedDomainEvent(product.Id));

            return Result.Success(product);
        }

        public Result Update(
            Guid id,
            string code,
            string name,
            string description,
            string baseUnit,
            string productType,
            string category,
            string caliber,
            bool isActive,
            GeneralProperties generalProperties,
            LogisticsProperties logisticsProperties,
            AdjustmentFactors adjustmentFactors,
            PhysicalProperties physicalProperties,
            Expiration expiration,
            Taxation taxation
        )
        {
            var product = new Product(
                id,
                code,
                name,
                description,
                baseUnit,
                productType,
                category,
                caliber,
                isActive,
                generalProperties,
                logisticsProperties,
                adjustmentFactors,
                physicalProperties,
                expiration,
                taxation
            );
            

            // 🛠️ Generar evento de dominio si es necesario
            RaiseDomainEvent(new ProductUpdatedDomainEvent(product.Id));

            return Result.Success(product);
        }


    }
}
