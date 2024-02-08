using Application.Interface.Common;
using Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IOrderRepository : IRepository<Order>
	{
        Task CreateNewOrder(Order order,CancellationToken cancellationToken);
    }
}
