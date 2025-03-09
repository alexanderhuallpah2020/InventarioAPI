﻿using DataConsulting.Inventory.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Persistence
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {


        }

    }
}
