﻿using DataConsulting.Inventory.Application.Abstractions.Common;
using DataConsulting.Inventory.Application.Abstractions.Messaging;
using DataConsulting.Inventory.Application.Exceptions;
using DataConsulting.Inventory.Domain.Abstractions;
using DataConsulting.Inventory.Domain.Primitives;
using DataConsulting.Inventory.Domain.Products;
using DataConsulting.Inventory.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Application.Products.CreateProduct
{
    internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider, IProductRepository productRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<Guid>> Handle(
            CreateProductCommand request, 
            CancellationToken cancellationToken)
        {
            var userId = new UserId(request.UserId);
            var user = await _userRepository.GetByIdAsync(userId, cancellationToken);

            if (user is null)
                return Result.Failure<Guid>(UserErrors.NotFound);



            try
            {
                var result = Product.Create(
                    user.Id!,
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


                _productRepository.Add(result);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return result.Id!.Value;


            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(ErrorsProduct.ConcurrencyConflict);
            }
        }
    }
}
