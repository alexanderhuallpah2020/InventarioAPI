using DataConsulting.Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Errors
{
    public static class ErrorsUser
    {

        public static Error NotFound = new(
            "User.Found",
            "No existe el usuario buscado por este id"
        );

        public static Error InvalidCredentials = new(
            "User.InvalidCredentials",
            "Las credenciales son incorrectas"
        );


    }
}
