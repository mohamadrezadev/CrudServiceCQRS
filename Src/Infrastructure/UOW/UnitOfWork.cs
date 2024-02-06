using Application.Interface;
using Application.Interface.Common;
using Persistances.Contexts;
using Persistances.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;


        

        public IOrderRepository OrderRepository { get; }

        public IProductRepository ProductRepository { get; }

        public UnitOfWork( AppDbContext dbContext)
        {
            ProductRepository = new ProductRepository(dbContext);
            OrderRepository = new OrderRepository(dbContext);
        }

        public  void Dispose( )
        {
           
            
        }
        public async Task SaveAsync(CancellationToken cancellationToken )
        {
            await _context.SaveChangesAsync();
        }
    }
}
