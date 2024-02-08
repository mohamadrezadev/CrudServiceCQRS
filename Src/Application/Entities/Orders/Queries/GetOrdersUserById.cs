using Application.Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Orders.Queries
{
    public class GetOrdersUserById:IRequest<List< OrderDto>>
    {
        public Guid UserId { get; set; }
    }
}
