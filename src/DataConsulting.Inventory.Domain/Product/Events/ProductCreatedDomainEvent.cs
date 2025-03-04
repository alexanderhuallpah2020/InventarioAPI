using DataConsulting.Inventory.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Product.Events
{
    public sealed record ProductCreatedDomainEvent(Guid ProductId) : IDomainEvent;
}
