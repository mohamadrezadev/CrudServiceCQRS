using Application.Entities.Products.Queries;
using Application.Interface.Common;
using Domain.Entities.Products;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController( IMediator mediator )
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<Product>> GetProductsAsync( )
        {
            var studentDetails = await _mediator.Send(new GetProductList());

            return studentDetails;
        }
    }
}
