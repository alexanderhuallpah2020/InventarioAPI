using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Products
{
    public record ProductId(Guid Value)
    {
        public static ProductId New() => new(Guid.NewGuid());
    }
}
