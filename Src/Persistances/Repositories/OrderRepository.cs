using Application.Interface;
using Domain.Entities.Orders;
using Persistances.Common;
using Persistances.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistances.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository( AppDbContext dbContext ) : base(dbContext)
        {
        }
    }
}
