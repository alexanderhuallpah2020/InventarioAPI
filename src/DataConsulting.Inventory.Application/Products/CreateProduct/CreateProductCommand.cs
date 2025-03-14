﻿using DataConsulting.Inventory.Application.Abstractions.Messaging;
using DataConsulting.Inventory.Domain.Products.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Application.Products.CreateProduct
{
    public sealed record CreateProductCommand
    (
        Guid UserId,
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

    ) : ICommand<Guid>;
}
