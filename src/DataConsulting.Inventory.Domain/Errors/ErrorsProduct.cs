using DataConsulting.Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Errors
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
    }
}
