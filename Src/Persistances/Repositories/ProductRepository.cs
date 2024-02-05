using Application.Interface;
using Domain.Entities.Products;
using Persistances.Common;
using Persistances.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistances.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository( AppDbContext dbContext ) : base(dbContext)
        {
        }
    }
}
