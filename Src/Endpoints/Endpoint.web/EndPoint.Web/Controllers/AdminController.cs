using Application.Entities.Products.Commands;
using Application.Entities.Products.Handlers;
using Application.Entities.Products.Queries;
using Application.Entities.Users.Commands;
using Application.Entities.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index( )
        {
            return View();
        }
        public async Task<IActionResult> Users( CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetListUsers(),cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> Products(CancellationToken cancellationToken )
        {
            var products = await _mediator.Send(new GetProductList());
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> AccessAdmin(Guid Iduser )
        {
            var result=  await _mediator.Send(new AccessAdminToUser() { UserId = Iduser });
			return RedirectToAction(nameof(Users));
		}
        [HttpPost]
        public async Task<IActionResult> AddNewProduct(CreateProduct createProduct,CancellationToken cancellationToken )
        {
             await _mediator.Send(createProduct,cancellationToken);
            return RedirectToAction(nameof(Products));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(DeleteProduct deleteProduct,CancellationToken cancellationToken )
        {
            await _mediator.Send(deleteProduct,cancellationToken);
            return RedirectToAction(nameof(Products));
        }
        [HttpPost]
        public async Task<IActionResult>UpdateProduct(UpdateProduct updateProduct,CancellationToken cancellationToken )
        {
            await _mediator.Send(updateProduct, cancellationToken);
			return RedirectToAction(nameof(Products));

		}


	}
}
