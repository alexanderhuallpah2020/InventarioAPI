using DataConsulting.Inventory.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Persistence.Repositories
{
    internal abstract class Repository<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
        where TEntityId : class
    {
        protected readonly ApplicationDbContext DbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<TEntity?> GetByIdAsync(
           TEntityId id,
           CancellationToken cancellationToken = default
        )
        {
            return await DbContext.Set<TEntity>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Add(TEntityId entity)
        {
            DbContext.Add(entity);
        }

        public void Update(TEntityId entity)
        {
            DbContext.Set<TEntityId>().Update(entity);
        }

    }

}
