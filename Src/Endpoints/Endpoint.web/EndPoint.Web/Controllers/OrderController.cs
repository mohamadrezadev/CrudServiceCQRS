using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Web.Controllers
{
    [Authorize(Roles ="User")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index( )
        {
            return View();
        }
        public async Task<IActionResult> MyOrder( )
        {
            await _mediator.Send();
            return View();
        }
    }
}
