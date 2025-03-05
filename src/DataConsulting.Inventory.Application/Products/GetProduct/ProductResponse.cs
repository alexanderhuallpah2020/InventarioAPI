using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Application.Products.GetProduct
{
    public sealed class ProductResponse
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public string? Code { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }

    }
}
