using DataConsulting.Inventory.Application.Abstractions.Common;
using DataConsulting.Inventory.Application.Abstractions.Messaging;
using DataConsulting.Inventory.Application.Exceptions;
using DataConsulting.Inventory.Domain.Abstractions;
using DataConsulting.Inventory.Domain.Errors;
using DataConsulting.Inventory.Domain.Primitives;
using DataConsulting.Inventory.Domain.Products;
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

        public CreateProductCommandHandler(
            IUnitOfWork unitOfWork, 
            IDateTimeProvider dateTimeProvider, 
            IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _productRepository = productRepository;
        }

        public async Task<Result<Guid>> Handle(
            CreateProductCommand request, 
            CancellationToken cancellationToken)
        {

            try
            {
                var result = Product.Create(
                    request.UserId,
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


                _productRepository.Add(result.Value);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success(result.Value.Id);


            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(ErrorsProduct.ConcurrencyConflict);
            }
        }
    }
}
