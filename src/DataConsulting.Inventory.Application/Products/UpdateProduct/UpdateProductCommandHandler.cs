﻿using DataConsulting.Inventory.Application.Abstractions.Messaging;
using DataConsulting.Inventory.Application.Exceptions;
using DataConsulting.Inventory.Domain.Abstractions;
using DataConsulting.Inventory.Domain.Primitives;
using DataConsulting.Inventory.Domain.Products;
using DataConsulting.Inventory.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Application.Products.UpdateProduct
{
    internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<Guid>> Handle(
    UpdateProductCommand request,
    CancellationToken cancellationToken)
        {
            try
            {
                var userId = new UserId(request.UserId);
                var user = await _userRepository.GetByIdAsync(userId, cancellationToken);

                if (user is null)
                    return Result.Failure<Guid>(UserErrors.NotFound);

                // 🔍 Buscar el producto existente en la BD
                var product = await _productRepository.GetByIdAsync(new ProductId(request.Id), cancellationToken);

                if (product is null)
                    return Result.Failure<Guid>(ErrorsProduct.NotFound);

                // 🔄 Llamar a `Update()` en la misma instancia de `Product`
                product.Update(
                    request.Code,
                    request.Name,
                    request.Description,
                    request.BaseUnit,
                    request.ProductType,
                    request.Category,
                    request.Caliber,
                    request.IsActive,
                    request.GeneralProperties,
                    request.LogisticsProperties,
                    request.AdjustmentFactors,
                    request.PhysicalProperties,
                    request.Expiration,
                    request.Taxation
                );

                _productRepository.Update(product);

                // 💾 Guardar cambios en la BD
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success(product.Id!.Value);
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(ErrorsProduct.ConcurrencyConflict);
            }
        }

    }
}
