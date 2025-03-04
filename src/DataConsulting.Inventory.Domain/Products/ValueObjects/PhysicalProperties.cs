using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Products.ValueObjects
{
    public record PhysicalProperties(
        decimal Weight, 
        decimal Volume
    );
}
