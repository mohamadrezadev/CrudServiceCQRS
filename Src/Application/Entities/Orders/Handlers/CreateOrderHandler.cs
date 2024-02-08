using Application.Entities.Orders.Commands;
using Application.Interface.Common;
using AutoMapper;
using Domain.Entities.Orders;
using MediatR;

namespace Application.Entities.Orders.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrder, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateOrder request, CancellationToken cancellationToken)
        {

            var finduser = await _unitOfWork.UserManager.FindByIdAsync(request.UserId.ToString());
            if (finduser !=null)
            {
                var neworder = _mapper.Map<Order>(request.Order);
                neworder.orderDetails=_mapper.Map<List<OrderDetail>>(request.Order.orderDetails);
                neworder.UserId = finduser.Id;
                await _unitOfWork.OrderRepository.AddAsync(neworder, cancellationToken);
                return true;
            }

            return false;
        }
    }
}
