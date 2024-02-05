using Application.Entities.Orders.Commands;
using Application.Interface.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Orders.Handlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrder, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderHandler( IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
       
        public async Task<bool> Handle( DeleteOrder request, CancellationToken cancellationToken )
        {
           var ExistOrder= await _unitOfWork.OrderRepository.GetByIdAsync(cancellationToken, request.Id);
            if (ExistOrder is not null)
            {
                await _unitOfWork.OrderRepository.DeleteAsync(ExistOrder, cancellationToken);
                return true;
            }
            return false;
          
        }
    }
}
