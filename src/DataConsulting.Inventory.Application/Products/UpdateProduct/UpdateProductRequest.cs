using DataConsulting.Inventory.Domain.Products.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Application.Products.UpdateProduct
{
    public record UpdateProductRequest(
        Guid Id, // ID del producto a actualizar
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
    );
}
