﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.Abstractions
{
    public interface IEntity
    {

        IReadOnlyList<IDomainEvent> GetDomainEvents();

        void ClearDomainEvents();

    }
}
