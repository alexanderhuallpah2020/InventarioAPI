using DataConsulting.Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Exceptions
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(Error error)
            : base(error.Message)
            => Error = error;
        public Error Error { get; }
    }
}
