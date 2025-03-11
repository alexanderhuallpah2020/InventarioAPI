using DataConsulting.Inventory.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Products.Events
{
    public sealed record ProductUpdatedDomainEvent(Guid ProductId) : IDomainEvent;
}
