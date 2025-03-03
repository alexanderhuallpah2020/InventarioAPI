using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Product.ValueObjects
{
    public record Taxation(
        bool ForeignVAT, 
        bool ICBPERApplicable, 
        bool VATApplicable, 
        decimal VATPercentage,
        bool ISCApplicable,
        decimal ISCPercentage,
        decimal Perception,
        decimal Withholding
    );
}
