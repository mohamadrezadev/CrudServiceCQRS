﻿using Application.Entities.Dtos;
using Application.Entities.Orders.Queries;
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
    public class GetOrderByIdHandler : IRequestHandler<GetOrderById, OrderDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler( IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderDto> Handle( GetOrderById request, CancellationToken cancellationToken )
        {
           var result= await _unitOfWork.OrderRepository.GetByIdAsync(cancellationToken, request.Id);
            if ( result is not null )
            {
               
                   return _mapper.Map<OrderDto>(result);
            }
            return new();
        }
    }
}
