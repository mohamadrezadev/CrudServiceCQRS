using Application.Entities.Orders.Commands;
using Application.Interface;
using Application.Interface.Common;
using AutoMapper;
using Domain.Entities.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Orders.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrder, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
             var order= _mapper.Map<Order>(request);
             await _unitOfWork.OrderRepository.AddAsync(order, cancellationToken);
            return order.Id;
        }
    }
}
