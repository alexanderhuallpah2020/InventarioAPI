using DataConsulting.Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Products
{
    public static class ErrorsProduct
    {
        public static readonly Error NotFound = new Error(
           "Product.Found",
           "El producto con el Id especificado no fue encontrado"
        );

        public static readonly Error ConcurrencyConflict = new Error(
        "Product.ConcurrencyConflict",
        "Se detectó un conflicto de concurrencia. El producto ha sido modificado por otro proceso."
        );

        public static readonly Error NonImportedCannotHaveDrawback = new Error(
        "Product.NonImportedCannotHaveDrawback",
        "Un producto no importado no puede tener drawback."
        );

        public static readonly Error CompositeProductMustBeImported = new Error(
            "Product.CompositeProductMustBeImported",
            "Un producto compuesto debe ser importado."
        );

    }
}
