using DataConsulting.Inventory.Application.Products.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Application.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            //RuleFor(c => c.FechaInicio).LessThan(c => c.FechaFin); Valida fecha
        }
    }
}
