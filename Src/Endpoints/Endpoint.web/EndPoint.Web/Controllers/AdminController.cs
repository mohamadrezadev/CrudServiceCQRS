using Application.Entities.Products.Handlers;
using Application.Entities.Products.Queries;
using Application.Entities.Users.Commands;
using Application.Entities.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Web.Controllers
{
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



	}
}
