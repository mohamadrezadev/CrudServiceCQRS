using Application.Entities.Dtos;
using MediatR;


namespace Application.Entities.Orders.Commands
{
    public class CreateOrder : IRequest<bool>
    {
        public CreateOrder(Guid userId,OrderDto orderDto)
        {
              this.UserId = userId;
                this.Order = orderDto; 
        }
        public Guid UserId { get; set; }
        public OrderDto Order { get; set; }

    }
    
}
