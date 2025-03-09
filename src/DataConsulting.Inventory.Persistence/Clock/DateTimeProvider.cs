using DataConsulting.Inventory.Application.Abstractions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Persistence.Clock
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime currentTime => DateTime.UtcNow;
    }
}
