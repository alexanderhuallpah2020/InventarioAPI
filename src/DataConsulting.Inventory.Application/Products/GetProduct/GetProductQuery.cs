using DataConsulting.Inventory.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Application.Products.GetProduct
{
    public sealed record GetProductQuery(Guid ProductId) : IQuery<ProductResponse>;
}
