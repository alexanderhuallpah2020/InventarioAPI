using DataConsulting.Inventory.Application.Abstractions.Email;
using DataConsulting.Inventory.Domain.Products;
using DataConsulting.Inventory.Domain.Products.Events;
using DataConsulting.Inventory.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Application.Products.CreateProduct
{
    internal sealed class CreateProductDomainEventHandler : INotificationHandler<ProductCreatedDomainEvent>
    {
        private readonly IProductRepository _productRepository;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        public CreateProductDomainEventHandler(IProductRepository productRepository, IEmailService emailService, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _emailService = emailService;
            _userRepository = userRepository;
        }

        public async Task Handle(
            ProductCreatedDomainEvent notification, 
            CancellationToken cancellationToken)
        {

            var product = await _productRepository.GetByIdAsync(notification.ProductId, cancellationToken);

            if (product is null)
                return;

            var user = await _userRepository.GetByIdAsync(product.UserId, cancellationToken);

            await _emailService.SendAsync(
            user.Email!,
            "Producto creado",
            "El producto ha sido creado correctamente."
        );



        }
    }
}
