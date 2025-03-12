using DataConsulting.Inventory.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Products.ValueObjects
{
    public record GeneralProperties
    {
        public bool IsImported { get; }
        public bool HasDrawback { get; }
        public bool IsCompositeProduct { get; }

        public GeneralProperties(bool isImported, bool hasDrawback, bool isCompositeProduct)
        {
            // Validación de reglas de negocio (si aplica)
            if (!isImported && hasDrawback)
            {
                throw new DomainValidationException(ErrorsProduct.NonImportedCannotHaveDrawback);
            }

            if (isCompositeProduct && !isImported)
            {
                throw new DomainValidationException(ErrorsProduct.CompositeProductMustBeImported);
            }


            IsImported = isImported;
            HasDrawback = hasDrawback;
            IsCompositeProduct = isCompositeProduct;
        }
    }
}

