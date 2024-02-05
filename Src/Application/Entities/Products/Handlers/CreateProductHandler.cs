using Application.Entities.Products.Commands;
using Application.Interface.Common;
using AutoMapper;
using Domain.Entities.Products;
using MediatR;

namespace Application.Entities.Products.Handlers
{

    public class CreateProductHandler : IRequestHandler<CreateProduct, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductHandler( IUnitOfWork unitOfWork,IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle( CreateProduct request, CancellationToken cancellationToken )
        {
            var product=_mapper.Map<Product>( request );
            await _unitOfWork.ProductRepository.AddAsync(product, cancellationToken );
           return product.Id;
        }
    }
}
