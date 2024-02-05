using Domain.Entities.Products;
using MediatR;

namespace Application.Entities.Orders.Commands
{
    public class DeleteOrder : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
