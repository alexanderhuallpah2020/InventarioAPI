using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Primitives
{
    public record Error(string Code, string Message)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
        public static readonly Error NullValue = new("Error.NullValue", "Un valor Null fue ingresado.");
        public static readonly Error Validation = new("Error.Validation", "Se produjo un error de validación.");
        public static readonly Error NotFound = new("Error.NotFound", "El recurso no fue encontrado.");
        public static readonly Error AlreadyExists = new("Error.AlreadyExists", "El recurso ya existe.");
    }
}
