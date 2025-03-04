using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity() { }

        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity other)
                return false;

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
