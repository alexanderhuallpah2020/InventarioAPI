using DataConsulting.Inventory.Application.Abstractions.Messaging;
using DataConsulting.Inventory.Domain.Products.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Application.Abstractions.Products.CreateProduct
{
    public sealed record CreateProductCommand
    (
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
    ) : ICommand<Guid>;
}
