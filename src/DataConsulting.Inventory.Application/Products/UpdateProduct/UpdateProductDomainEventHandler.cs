using DataConsulting.Inventory.Application.Abstractions.Email;
using DataConsulting.Inventory.Domain.Products.Events;
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
    internal sealed class UpdateProductDomainEventHandler : INotificationHandler<ProductUpdatedDomainEvent>
    {
        private readonly IProductRepository _productRepository;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        public UpdateProductDomainEventHandler(IProductRepository productRepository, IEmailService emailService, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _emailService = emailService;
            _userRepository = userRepository;
        }

        public async Task Handle(ProductUpdatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(notification.ProductId, cancellationToken);

            if (product is null)
                return;

            var user = await _userRepository.GetByIdAsync(product.UserId, cancellationToken);

            await _emailService.SendAsync(
            user?.Email!,
            "Producto modificado",
            "El producto ha sido modificado correctamente."
            );
        }
    }
}
