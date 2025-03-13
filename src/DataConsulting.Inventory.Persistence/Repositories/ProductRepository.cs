using DataConsulting.Inventory.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Persistence.Repositories
{
    internal sealed class ProductRepository : Repository<Product, ProductId>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void Add(Product product)
        {
            DbContext.Add(product);
        }

        public void Update(Product product)
        {
            DbContext.Update(product);
        }
    }
}
