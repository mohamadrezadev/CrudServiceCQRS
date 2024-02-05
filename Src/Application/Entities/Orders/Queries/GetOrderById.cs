using Domain.Entities.Orders;
using Domain.Entities.Products;
using MediatR;

namespace Application.Entities.Orders.Queries
{
    public class GetOrderById : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
