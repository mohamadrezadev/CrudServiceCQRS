using Application.Entities.Dtos;
using Application.Entities.Orders.Queries;
using Application.Interface.Common;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Orders.Handlers
{
    public class GetOrdersUserByIdHandler : IRequestHandler<GetOrdersUserById, List<OrderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrdersUserByIdHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List< OrderDto>> Handle( GetOrdersUserById request, CancellationToken cancellationToken )
        {
          var userwithOrders=  await _unitOfWork.UserRepository.Entities
              .Include(u => u.Orders)                            
                .ThenInclude(o => o.orderDetails)              
            .Where(u => u.Id.Equals(request.UserId))                    
            .FirstOrDefaultAsync();


             var response=  _mapper.Map<List<OrderDto>>(userwithOrders.Orders.ToList());

            return response;
        }
    }
}
