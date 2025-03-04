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
    }
}
