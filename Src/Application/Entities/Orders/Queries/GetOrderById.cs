using Application.Entities.Dtos;
using MediatR;

namespace Application.Entities.Orders.Queries
{
    public class GetOrderById : IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}
