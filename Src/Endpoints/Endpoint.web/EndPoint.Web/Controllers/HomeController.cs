using Application.Entities.Products.Queries;
using EndPoint.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EndPoint.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController( ILogger<HomeController> logger ,IMediator mediator )
        {
            _logger = logger;
            _mediator = mediator;
        }


        public async  Task<IActionResult> Index(CancellationToken cancellationToken )
        {
           var products= await  _mediator.Send(new GetProductList(),cancellationToken);
            return View(products);
        }

        public IActionResult Privacy( )
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error( )
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
