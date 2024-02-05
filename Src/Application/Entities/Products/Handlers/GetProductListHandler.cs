using Application.Entities.Products.Queries;
using Application.Interface.Common;
using AutoMapper;
using Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Entities.Products.Handlers
{
    public class GetProductListHandler : IRequestHandler<GetProductList, List<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductListHandler( IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Product>> Handle( GetProductList request, CancellationToken cancellationToken )
        {
          return  await _unitOfWork.ProductRepository.Entities.ToListAsync(cancellationToken);
        }
    }
}
