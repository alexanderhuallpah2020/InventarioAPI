﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Application.Abstractions.Common
{
    public interface IDateTimeProvider
    {
        DateTime currentTime { get; }
    }
}
