using Application.Entities.Products.Commands;
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
        [HttpGet(Name ="GetProducts")]
        public async Task<IActionResult> GetProductsAsync(CancellationToken cancellationToken )
        {
            var studentDetails = await _mediator.Send(new GetProductList(),cancellationToken);

            return Ok(studentDetails);
        }
        [HttpPost(Name ="AddNew")]
        public async Task<IActionResult> CreateProduct(CreateProduct createProduct,CancellationToken cancellationToken )
        {
            var res= await _mediator.Send(createProduct,cancellationToken);
            return Created("",res);
        }
        [HttpPut(Name ="Update")]
        public async Task<IActionResult> Update(UpdateProduct  updateProduct,CancellationToken cancellationToken)
        {
             var res= await _mediator.Send(updateProduct,cancellationToken);
             return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProduct deleteProduct,CancellationToken cancellationToken  )
        {
             var res=await _mediator.Send(deleteProduct,cancellationToken);
            return Ok(res);
        }
    }
}
