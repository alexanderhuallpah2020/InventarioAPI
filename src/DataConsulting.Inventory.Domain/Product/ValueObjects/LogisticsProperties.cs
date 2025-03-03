using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Product.ValueObjects
{
    public record LogisticsProperties(
        string TrackingType, 
        string CatalogType
    );
}
